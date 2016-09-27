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
        
    }
}
