using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Timers;
namespace Hosam_App.Adjust
{
    /// <summary>
    /// adjust_Page.xaml 的互動邏輯
    /// </summary>
    public partial class adjust_Page : Page
    {
        public adjust_Ctrl _adjust_Ctrl;

        public adjust_Page()
        {
            InitializeComponent();

        }

        /// <summary>
        /// strength =強度 , Smooth = 平滑 , Amplitude =振福
        /// </summary>
        public void ReflashThePage(string Name,int StrengthValue, int SmoothValue,int AmplitudeValue)
        {
            this.title.Text = Name;
            Slider_Strength.Value = StrengthValue;
            Slider_Smooth.Value = SmoothValue;
            Slider_Amplitude.Value = AmplitudeValue;

        }
        /// <summary>
        /// 鉛筆的ICON更新位置
        /// </summary>


        private void Button_Click(object sender, RoutedEventArgs e)
        {
          
        }
    }
}
