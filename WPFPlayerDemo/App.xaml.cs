using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.IO;
using System.Reflection;
using System.Windows.Media.Animation;
using System.Diagnostics;

namespace WPFPlayerDemo
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    [System.Security.Permissions.EnvironmentPermission(System.Security.Permissions.SecurityAction.Demand)]
    public partial class App : Application
    {
        /// <summary>
        /// 启动参数
        /// </summary>
        private static string[] args;
        /// <summary>
        /// 启动参数
        /// </summary>
        public static string[] Args
        {
            get { return args; }
        }

        /// <summary>
        /// 启动目录
        /// </summary>
        public static string workPath
        {
            get { return Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName); }
        }

        /// <summary>
        /// 当前程序版本号
        /// </summary>
        public static string version
        {
            get { return Assembly.GetExecutingAssembly().GetName().Version.ToString(); }
        }

        /// <summary>
        /// 程序启动
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();
            args = e.Args;
            Timeline.DesiredFrameRateProperty.OverrideMetadata(typeof(Timeline), new FrameworkPropertyMetadata { DefaultValue = 25 });//设置WPF动画默认帧数
            base.OnStartup(e);
        }
    }
}
