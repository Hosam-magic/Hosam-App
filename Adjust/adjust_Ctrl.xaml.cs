using System;
using System.Collections.Generic;
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

namespace Hosam_App
{
    /// <summary>
    /// adjust_Ctrl.xaml 的互動邏輯
    /// </summary>
    public partial class adjust_Ctrl : Page
    {
        public static readonly DependencyProperty BlurValue = DependencyProperty.Register("blurValue", typeof(float), typeof(adjust_Ctrl));

        public Adjust.adjust_Navigator adjust_Navigator;
        public Adjust.adjust_Page _adjust_Page;
       public bool isWarring;
        Grid alarm;
        Adjust.Adjust_Resource.Component.warringbox WarringBox;
        public adjust_Ctrl()
        {
            InitializeComponent();
            Initial();
            if (alarm == null) {

                alarm = Effect;
                WarringBox = AlramBox;
                WarringBox.adjust_Ctrl = this;
                isWarring = true;
                Warring();
            }
        }
        void Initial()
        {
            if (adjust_Navigator == null)
            {
                adjust_Navigator = new Adjust.adjust_Navigator();
                this.adjust_Navigation.Navigate(adjust_Navigator);
                adjust_Navigator._adjust_Ctrl = this;
            }
            else
            {
                this.adjust_Navigation.Navigate(adjust_Navigator);
            }
            if (_adjust_Page == null)
            {
                _adjust_Page = new Adjust.adjust_Page();
                this.Adjust_Page.Navigate(_adjust_Page);
                _adjust_Page._adjust_Ctrl = this;
            }
            else
            {
                this.adjust_Navigation.Navigate(adjust_Navigator);
            }
        }public void Warring() {
            switch (isWarring) {
                case true:
                    WarringBox.Visibility = Visibility.Visible;
                    blurValue = 40;
                    GrayBar.Visibility = Visibility.Visible;
                    break;
                case false:
                    WarringBox.Visibility = Visibility.Hidden;
                    blurValue = 0;
                    GrayBar.Visibility = Visibility.Hidden;
                    break;     
            }
        }
        public float blurValue { get {return (float)GetValue(BlurValue); } set{ SetValue(BlurValue, value); } }
    }
}
