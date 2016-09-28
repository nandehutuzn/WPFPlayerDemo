using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.ComponentModel;
using System.Collections;
using System.Windows.Media.Effects;
using System.Windows.Interop;
using System.Windows.Threading;
using System.Reflection;
using Un4seen.Bass;
using Microsoft.Windows.Shell;

namespace WPFPlayerDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window, IDisposable
    {
        public  readonly log4net.ILog _log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// 当前实例
        /// </summary>
        public static MainWindow _this = null;

        /// <summary>
        /// 歌词开关按钮
        /// </summary>
        private static CheckBox LrcButton;

        /// <summary>
        /// 打开文件按钮
        /// </summary>
        private static Button OpenButton;

        /// <summary>
        /// 菜单
        /// </summary>
        private static ContextMenu menu;

        /// <summary>
        /// 菜单播放项
        /// </summary>
        private static MenuItem menuPlay;

        /// <summary>
        /// 菜单暂停项
        /// </summary>
        private static MenuItem menuPause;

        /// <summary>
        /// 菜单桌面歌词开关项
        /// </summary>
        private static MenuItem menuDesktopLyric;

        /// <summary>
        /// 窗口句柄
        /// </summary>
        public IntPtr Handle { get { return new WindowInteropHelper(this).Handle; } }

        /// <summary>
        /// 播放列表按钮效果
        /// </summary>
        private DropShadowEffect shadow = new DropShadowEffect();
        
        /// <summary>
        /// 播放进度时钟
        /// </summary>
        private DispatcherTimer progressClock = new DispatcherTimer();

        /// <summary>
        /// 总时间标签、当前时间标签
        /// </summary>
        private Run time_total = new Run("/00:00"), time_now = new Run("00:00");

        /// <summary>
        /// 进度条拖动状态
        /// </summary>
        private bool draggingProgress = false;

        /// <summary>
        /// 进度时间颜色
        /// </summary>
        private Brush propressColor = new SolidColorBrush(Colors.White);

        /// <summary>
        /// 进度时间拖动时颜色
        /// </summary>
        private Brush draggingProgressColor = new SolidColorBrush(Colors.Orange);

        /// <summary>
        /// 后台频谱操作线程
        /// </summary>
        private BackgroundWorker spectrumWorker = new BackgroundWorker();

        /// <summary>
        /// 频谱线、频谱条
        /// </summary>
        private Rectangle[] spectrum_t = new Rectangle[42], spectrum_x = new Rectangle[42];

        /// <summary>
        /// 频谱数据
        /// </summary>
        private int[] spectrum_position_t = new int[42], spectrum_position_x = new int[42];

        /// <summary>
        /// 频谱线下落速度
        /// </summary>
        private int[] spectrum_fall_rate = new int[42];

        /// <summary>
        /// 用于频谱线程访问的player对象
        /// </summary>
        private Player playerForSpectrum;

        /// <summary>
        /// 播放列表
        /// </summary>
        private Playlist play_list;

        /// <summary>
        /// 歌词对象
        /// </summary>
        public static Lyric lyric = null;

        /// <summary>
        /// 后台歌词处理线程
        /// </summary>
        private BackgroundWorker lyricWorker = new BackgroundWorker();

        /// <summary>
        /// 用于歌词线程访问的player对象
        /// </summary>
        private Player playerForLyric;

        #region  歌词数据
        private bool addedLyric = false;
        private int indexLyric;
        private string lrcLyric;
        private double lenLyric, progressLyric, valueLyric;
        #endregion

        /// <summary>
        /// 默认黑色背景
        /// </summary>
        private SolidColorBrush defaultBackground = new SolidColorBrush(Colors.Black);

        /// <summary>
        /// 歌手图片背景对象
        /// </summary>
        private ImageBrush singerBackground = new ImageBrush();

        /// <summary>
        /// 任务栏预览按钮
        /// </summary>
        private TaskbarItemInfo tii = new TaskbarItemInfo();

        /// <summary>
        /// 桌面歌词窗口
        /// </summary>
        public DesktopLyric desktopLyric = null;

        /// <summary>
        /// 托盘图标
        /// </summary>
        private System.Windows.Forms.NotifyIcon notifyIcon = new System.Windows.Forms.NotifyIcon();

        #region
        private bool disposedValue = false;//要检测冗余调用

        /// <summary>
        /// 资源释放
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    //托管资源释放
                    this.spectrumWorker.Dispose();
                    this.lyricWorker.Dispose();
                    if (this.desktopLyric != null)
                        this.desktopLyric.Dispose();
                    this.notifyIcon.Dispose();
                }
                //未托管资源释放
                disposedValue = true;
            }
        }
        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        // ~MainWindow() {
        //   Dispose(false);
        // }
        /// <summary>
        /// 实现IDisposable接口
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion  IDisposable Support
        
        /// <summary>
        /// 构造函数  初始化程序
        /// </summary>
        public MainWindow()
        {
            _this = this;
            //加载配置
            Config.loadConfig(App.workPath + "\\config.db");
            //窗口初始化事件
            this.Loaded += initialize;
            InitializeComponent();
            //初始化背景图片对象
            singerBackground.Stretch = Stretch.UniformToFill;
            singerBackground.AlignmentX = AlignmentX.Center;
            singerBackground.AlignmentY = AlignmentY.Center;

            //if (!Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_CPSPEAKERS, IntPtr.Zero))
            //    MessageBox.Show("Bass 初始化失败 " + Bass.BASS_ErrorGetCode().ToString());
            //string file = @"E:\KuGou\Christina Aguilera - We Remain.mp3";
            //int stream = Bass.BASS_StreamCreateFile(file, 0L, 0L, BASSFlag.BASS_SAMPLE_FLOAT);
            //Bass.BASS_ChannelPlay(stream, true);
        }

        /// <summary>
        /// 窗口初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void initialize(object sender, RoutedEventArgs e)
        {
            //标题栏版本号
            this.Title = this.Title.Replace("{$Version}", App.version);
            //窗口样式模板
            ControlTemplate baseWindowTemplate = (ControlTemplate)this.Resources["mainWindowTemplate"];
            //关闭按钮
            Button closeButton = (Button)baseWindowTemplate.FindName("closeButton", this);
            closeButton.Click += close;  //关闭窗口
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void dragEnter(object sender, DragEventArgs e)
        {

        }

        private void drop(object sender, DragEventArgs e)
        {

        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LastButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PlayListButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MuteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void VolumeButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void VolumeBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void Model_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void menuPlay_Click(object sender, RoutedEventArgs e)
        {

        }

        private void menuDesktopLyric_Click(object sender, RoutedEventArgs e)
        {

        }

        private void about(object sender, RoutedEventArgs e)
        {

        }

        private void exit(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// 窗口最小化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void minimize(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// 窗口关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void close(object sender, RoutedEventArgs e)
        {
            //保存配置
            Config.saveConfig(App.workPath + "\\config.db");
            //停止频谱
            spectrumWorker.CancelAsync();
            //窗口歌词
            lyricWorker.CancelAsync();
            //yincan窗口
            this.Hide();
        }

        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setting(object sender, RoutedEventArgs e)
        {
            //弹出设置窗口
            Setting setting = new Setting();
            setting.Owner = this;
            setting.ShowDialog();
        }

        /// <summary>
        /// 歌词提前
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lrcAdvance(object sender, RoutedEventArgs e)
        {
            if (lyric != null)
                lyric.Offset += 100;
        }

        /// <summary>
        /// 歌词延后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lrcDelay(object sender, RoutedEventArgs e)
        {
            if (lyric != null)
                lyric.Offset -= 100;
        }

        /// <summary>
        /// 桌面歌词开关切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void lrcSwitch(object sender, RoutedEventArgs e)
        {
            Config config = Config.getInstance();
            if (!(sender is Setting))
                config.showDesktopLyric = !config.showDesktopLyric;

            LrcButton.IsChecked = menuDesktopLyric.IsChecked = config.showDesktopLyric;
            if (config.showDesktopLyric)
            {
                //载入桌面歌词
                if (desktopLyric == null)
                    desktopLyric = new DesktopLyric();
                desktopLyric.Show();
            }
            else if (desktopLyric != null)
            { 
                //关闭桌面歌词
                desktopLyric.Close();
                desktopLyric.Dispose();
            }
        }

        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFile(object sender, RoutedEventArgs e)
        {
            //打开文件对话框
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            //标题
            ofd.Title = "打开音乐";
            //检查文件必须存在
            ofd.CheckFileExists = true;
            //允许多选（所以文件加入播放列表，自动播放第一首）
            ofd.Multiselect = true;
            //快捷方式返回引用的文件
            ofd.DereferenceLinks = true;
            //文件筛选过滤器
            ofd.Filter = "音乐文件|*.mp3;*.mp2;*.mp1;*.ogg;*.wav;*.aiff"
                + "|MP3|*.mp3"
                + "|OGG|*.ogg"
                + "|WAV|*.wav"
                + "|AIFF|*.aiff"
                + "|MP2|*.mp2"
                + "|MP1|*.mp1"
                + "|所有文件|*";
            //文件筛选索引
            ofd.FilterIndex = 1;
            //打开文件
            if (ofd.ShowDialog() == true)
            {
                //文件列表
                string[] files = ofd.FileNames;
                List.SelectedIndex = addToPlaylist(files);
                //打开第一个文件
                PlaylistOpen(sender, null);
            }
        }

        /// <summary>
        /// 向播放列表插入文件
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        private int addToPlaylist(string[] files)
        {
            int lastid = List.Items.Count - 2, count = -1;
            foreach (string file in files)
            {
                //检验音乐文件合法性并获取音乐信息
                MusicID3? info = Player.getInformation(file);
                if (info == null)
                    continue;  //音乐文件无法打开
                //删除已存在项
                ArrayList deleted = new ArrayList();
                foreach (ListBoxItem lbi in List.Items)
                {
                    if (((string)lbi.ToolTip) == file)
                        deleted.Add(lbi);
                }
                foreach (ListBoxItem lbi in deleted)
                    List.Items.Remove(lbi);

                deleted.Clear();
                foreach (Playlist.Music music in play_list.list)
                    if (music.path == file)
                        deleted.Add(music);

                foreach (Playlist.Music music in deleted)
                    play_list.list.Remove(music);

                //添加到列表
                TextBlock textblock = new TextBlock();
                textblock.TextTrimming = TextTrimming.WordEllipsis;
                //歌曲名
                Run title = new Run(info.Value.title);
                title.FontSize = 20;
                title.FontWeight = FontWeights.Bold;
                textblock.Inlines.Add(title);
                //时长
                Run duration = new Run(" - " + info.Value.duration);
                duration.FontSize = 16;
                duration.FontStyle = FontStyles.Italic;
                textblock.Inlines.Add(duration);
                textblock.Inlines.Add(new LineBreak());
                //艺术家
                Run artist = new Run(info.Value.artist == "" ? file : info.Value.artist);
                artist.FontSize = 14;
                textblock.Inlines.Add(artist);
                //专辑
                Run album = new Run(info.Value.album == "" ? "" : (" - " + info.Value.album));
                album.FontSize = 14;
                textblock.Inlines.Add(album);
                //宽度
                textblock.Width = 725;
                StackPanel stackPanel = new StackPanel();
                stackPanel.Orientation = Orientation.Horizontal;
                stackPanel.Children.Add(textblock);
                ListBoxItem item = new ListBoxItem();
                item.Content = stackPanel;
                item.ToolTip = file;
                item.IsTabStop = false;
                item.MouseDoubleClick += PlaylistOpen;
                //统计
                lastid = List.Items.Add(item);
                count++;
                //添加到列表
                play_list.list.Add(new Playlist.Music
                {
                    title = info.Value.title,
                    artist = info.Value.artist,
                    album = info.Value.album,
                    duration = info.Value.duration,
                    path = file
                });
            }
            //保存播放列表
            Playlist.saveFile(ref play_list, App.workPath + "\\Playlist.db");
            //返回插入的第一条文字id
            return lastid - count;
        }

        /// <summary>
        /// 播放列表打开文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlaylistOpen(object sender, MouseButtonEventArgs e)
        {
            if (List.Items.Count <= 0)
            {
                openFile(sender, e);
                return;
            }
            Player player = Player.getInstance(Handle);
            Config config = Config.getInstance();
            //打开文件
            if (List.SelectedIndex < 0)
                List.SelectedIndex = 0;
            string file = (string)((ListBoxItem)List.Items.GetItemAt(List.SelectedIndex)).ToolTip;
            List.ScrollIntoView(List.SelectedItem);
            player.openFile(file);
            if (player.play(true))
            {
                //清楚背景图片
                this.Background = defaultBackground;
                //记录
                config.playlistIndex = List.SelectedIndex;
                //进度条最大值
                Progress.Maximum = player.length;
                //音乐长度
                time_total.Text = "/" + Helper.Seconds2Time(Progress.Maximum);
                //暂停播放按钮
                PauseButton.Visibility = System.Windows.Visibility.Visible;
                PlayButton.Visibility = System.Windows.Visibility.Hidden;
                menuPause.Visibility = System.Windows.Visibility.Visible;
                menuPlay.Visibility = System.Windows.Visibility.Collapsed;
                tii.ThumbButtonInfos[1].ImageSource = (DrawingImage)Resources["PauseButtonImage"];
                tii.ThumbButtonInfos[1].Command = MediaCommands.Pause;
                //任务栏进度条
                tii.ProgressState = TaskbarItemProgressState.Normal;
                //音乐信息
                MusicID3 information = player.information;
                TitleLabel.Content = information.title;
                SingerLabel.Content = information.artist;
                AlbumLabel.Content = information.album;
                //任务栏描述
                tii.Description = information.title + " - " + information.artist;
                //歌词
                loadLyric(information.title, information.artist, Helper.GetHash(file), (int)Math.Round(player.length * 1000), file);
                //时钟们
                clocks(true);
                //加载背景图片
                loadImage(information.artist);
            }
        }

        /// <summary>
        /// 加载歌词到窗口显示
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="artist">艺术家</param>
        /// <param name="hash">文件Hash</param>
        /// <param name="time">音乐时长</param>
        /// <param name="path">文件路径</param>
        private void loadLyric(string title, string artist, string hash, int time, string path)
        {
            //删除歌词
            lyric = null;
            Lrc.Children.Clear();
            addedLyric = false;
            //序列化路径不存在
            if (!Directory.Exists(App.workPath + "\\lyrics"))
                Directory.CreateDirectory(App.workPath + "\\lyrics");
            string t = Helper.pathClear(title);
            string a = Helper.pathClear(artist);
            //查找歌词文件
            if (File.Exists(App.workPath + "\\lyrics\\" + a + " - " + t + ".srcx"))
            {
                lyric = Lyric.loadSRCX(App.workPath + "\\lyrics\\" + a + " - " + t + ".srcx");
                if (lyric != null)
                    return;
            }
            if (File.Exists(App.workPath + "\\lyrics\\" + a + " - " + t + ".src"))
            {
                lyric = new Lyric(App.workPath + "\\lyrics\\" + a + " - " + t + ".src");
                //序列化保存
                Lyric.saveSRCX(App.workPath + "\\lyrics\\" + a + " - " + t + ".srcx", lyric);
            }
            else if (File.Exists(App.workPath + "\\lyrics\\" + a + " - " + t + ".lrc"))
            {
                lyric = new Lyric(App.workPath + "\\lyrics\\" + a + " - " + t + ".lrc");
                //序列化保存
                Lyric.saveSRCX(App.workPath + "\\lyrics\\" + a + " - " + t + ".srcx", lyric);
            }
            else if (File.Exists(path.Remove(path.LastIndexOf('.') + 1) + "src"))
            {
                lyric = new Lyric(path.Remove(path.LastIndexOf('.') + 1) + "src");
                //序列化保存
                Lyric.saveSRCX(App.workPath + "\\lyrics\\" + a + " - " + t + ".srcx", lyric);
            }
            else if (File.Exists(path.Remove(path.LastIndexOf('.') + 1) + "lrc"))
            {
                lyric = new Lyric(path.Remove(path.LastIndexOf('.') + 1) + "lrc");
                //序列化保存
                Lyric.saveSRCX(App.workPath + "\\lyrics\\" + a + " - " + t + ".srcx", lyric);
            }
            else
                lyric = new Lyric(title, artist, hash, time, App.workPath + "\\lyrics\\" + a + " - " + t + ".src");
            //序列化保存
            lyric.srcxPath = App.workPath + "\\lyrics\\" + a + " - " + t + ".srcx";
        }

        /// <summary>
        /// 启动/停止时钟们
        /// </summary>
        /// <param name="start"></param>
        private void clocks(bool start)
        {
            if (start)
                progressClock.Start();
            else
                progressClock.Stop();
        }

        /// <summary>
        /// 加载歌手图片到窗口显示
        /// </summary>
        /// <param name="artist"></param>
        private void loadImage(string artist)
        { 
        
        }

    }
}
