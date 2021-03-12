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

namespace Hosam_App.Adjust.Adjust_Resource.Component
{
    /// <summary>
    /// warringbox.xaml 的互動邏輯
    /// </summary>
    /// 

    public partial class warringbox : UserControl
    {

        public string content { get; set; }
        public adjust_Ctrl adjust_Ctrl;
        public warringbox()
        {
          InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            adjust_Ctrl.isWarring = false;
            adjust_Ctrl.Warring();
        }
    }
}
