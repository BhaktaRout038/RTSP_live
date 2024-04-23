using LibVLCSharp.Shared;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RTSP_live
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string video_url = "rtsp://admin:rout@123@172.16.3.41:554/cam/realmonitor?channel=1&subtype=0";
        //const string video_url = "rtsp://UserID:Password@IpAddress:554/cam/realmonitor?channel=1&subtype=0";
        // readonly string video_url = ConfigurationManager.AppSettings["CPPlusRtspUrl"];
        readonly LibVLC _libvlc;
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                Core.Initialize();
                _libvlc = new LibVLC();

                VideoView0.MediaPlayer = new LibVLCSharp.Shared.MediaPlayer(_libvlc);
                var m = new Media(_libvlc, video_url, FromType.FromLocation);
                //The next step is to set the corresponding parameters and play the life of rtsp stream. There is a big gap between setting and not setting. You can comment the code to experience
                m.AddOption(":rtsp-tcp");
                m.AddOption(":clock-synchro=0");
                m.AddOption(":live-caching=0");
                m.AddOption(":network-caching=333");
                m.AddOption(":file-caching=0");
                m.AddOption(":grayscale");
                VideoView0.MediaPlayer.Play(m);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
