using C1.WPF;
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
using Telerik.Windows.Controls;

namespace RadSetting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RadRibbonView_CollapsedChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
        }

        private void btn_attributes_Click(object sender, RoutedEventArgs e)
        {
            C1TabItem rt = new C1TabItem();
            rt.Header = "سرویس گیرنده ها";
            rt.Content = new Nases();
            tabcontrol1.Items.Add(rt);
        }
    }
}
