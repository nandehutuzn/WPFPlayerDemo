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
using System.Windows.Shapes;
using System.ComponentModel;

namespace WPFPlayerDemo
{
    /// <summary>
    /// DesktopLyric.xaml 的交互逻辑
    /// </summary>
    public partial class DesktopLyric : Window, IDisposable
    {

        /// <summary>
        /// 歌词加载时钟
        /// </summary>
        private BackgroundWorker timer = new BackgroundWorker();

        /// <summary>
        /// 鼠标进入窗口延迟计算器
        /// </summary>
        private BackgroundWorker moveTimer = new BackgroundWorker();

        public DesktopLyric()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_SourceInitialized(object sender, EventArgs e)
        {

        }

        private bool disposedValue = false; // 要检测冗余调用

        /// <summary>
        /// 实现IDisposable接口
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

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
                    this.timer.Dispose();
                    this.moveTimer.Dispose();
                }
                //未托管资源释放
                disposedValue = true;
            }
        }
        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        // ~MainWindow() {
        //   Dispose(false);
        // }
    }
}
