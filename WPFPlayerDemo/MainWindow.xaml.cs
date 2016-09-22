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
using Un4seen.Bass;

namespace WPFPlayerDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //if (!Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_CPSPEAKERS, IntPtr.Zero))
            //    MessageBox.Show("Bass 初始化失败 " + Bass.BASS_ErrorGetCode().ToString());
            //string file = @"E:\KuGou\Christina Aguilera - We Remain.mp3";
            //int stream = Bass.BASS_StreamCreateFile(file, 0L, 0L, BASSFlag.BASS_SAMPLE_FLOAT);
            //Bass.BASS_ChannelPlay(stream, true);
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
    }
}
