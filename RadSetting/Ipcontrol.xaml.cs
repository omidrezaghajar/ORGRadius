using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
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

namespace RadSetting
{
    /// <summary>
    /// Interaction logic for Ipcontrol.xaml
    /// </summary>
    public partial class Ipcontrol : UserControl
    {
        public Ipcontrol()
        {
            InitializeComponent();
        }
        [Bindable(true)]
        public IPAddress ip
        {
            get
            {
                return IPAddress.Parse(Txt_ip1.Value.ToString() + "." + Txt_ip2.Value.ToString() + "." + Txt_ip3.Value.ToString() + "." + Txt_ip4.Value.ToString());

            }
            set
            {
                string[] ipn = value.ToString().Split('.');
                Txt_ip1.Value = double.Parse(ipn[0]);
                Txt_ip2.Value = double.Parse(ipn[1]);
                Txt_ip3.Value = double.Parse(ipn[2]);
                Txt_ip4.Value = double.Parse(ipn[3]);
            }
        }
    }
}
