using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for Nases.xaml
    /// </summary>
    public partial class Nases : UserControl
    {
        int action = 0;
        int selectednasid = 0;
        public Nases()
        {
            InitializeComponent();
        }

        private void RadButton_Click(object sender, RoutedEventArgs e)
        {
            action = 1;
        }

        private void RadButton_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                selectednasid = int.Parse(((DataRow)RGRD_nases.SelectedCells[0].Item)["id"].ToString());
                DataClasses1DataContext dc = new DataClasses1DataContext();
                Nase n = (from x in dc.Nases where x.id == selectednasid select x).First();
                txt_ip.ip = IPAddress.Parse(n.ip.Split('/')[0]);
                txt_mask.ip = IPAddress.Parse(n.ip.Split('/')[1]);
                radComboBox.SelectedValue = n.NasType;
                txt_sharedsecret.Text = n.ShareSecret;
                action = 2;
            }
            catch { }
            
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            var c = from i in dc.NasTypes select i;
            radComboBox.DataContext = c;
            radComboBox.SelectedIndex = 0;
          //  RGRD_nases.DataContext = from f in dc.Nases select f;
            RGRD_nases.ItemsSource = from f in dc.Nases select new { f.id, f.ip, f.NasType1.VendorName,f.ShareSecret };
        }

        private void RadButton_Click_2(object sender, RoutedEventArgs e)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            if (action == 1)
            {
                Nase n = new Nase();
                n.ip = txt_ip.ip.ToString() + "/" + txt_mask.ip.ToString();
                n.NasType = (int)radComboBox.SelectedValue;
                n.ShareSecret = txt_sharedsecret.Text;
                dc.Nases.InsertOnSubmit(n);
                dc.SubmitChanges();
                action = 0;
                RGRD_nases.ItemsSource = from f in dc.Nases select new { f.id, f.ip, f.NasType1.VendorName, f.ShareSecret };
            }
            else if(action==2)
            {
                Nase n = (from x in dc.Nases where x.id == selectednasid select x).First();
                n.ip = txt_ip.ip.ToString() + "/" + txt_mask.ip.ToString();
                n.NasType = (int)radComboBox.SelectedValue;
                n.ShareSecret = txt_sharedsecret.Text;
                dc.SubmitChanges();
                action = 0;
                RGRD_nases.ItemsSource = from f in dc.Nases select new { f.id, f.ip, f.NasType1.VendorName, f.ShareSecret };
            }
        }
        private void RadButton_Click_3(object sender, RoutedEventArgs e)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            
            dynamic k2 = RGRD_nases.SelectedCells[0].Item;
            selectednasid = k2.id;
            action = 3;
            
            Nase n = (from x in dc.Nases where x.id == selectednasid select x).First();
            dc.Nases.DeleteOnSubmit(n);
            dc.SubmitChanges();
            action = 0;
            RGRD_nases.ItemsSource = from f in dc.Nases select new { f.id, f.ip, f.NasType1.VendorName, f.ShareSecret };
        }
    }
}
