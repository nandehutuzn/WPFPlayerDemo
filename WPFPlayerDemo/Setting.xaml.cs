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

namespace WPFPlayerDemo
{
    /// <summary>
    /// Setting.xaml 的交互逻辑
    /// </summary>
    public partial class Setting : Window
    {
        /// <summary>
        /// 关闭按钮
        /// </summary>
        private Button _closeButton;
        public Setting()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Initialize();
        }

        /// <summary>
        /// 控件初始化
        /// </summary>
        private void Initialize()
        {
            ControlTemplate baseWindowTemplate = this.Resources["settingTemplate"] as ControlTemplate;
            _closeButton = baseWindowTemplate.FindName("closeButton", this) as Button;
            _closeButton.Click += (sender, e) => this.Close();
        }

        private void save(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ok(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
