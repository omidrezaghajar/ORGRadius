using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Security.Cryptography;
using ORGRadiusBase;

namespace ORG_Radius_Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
     //   public UdpClient client2;
        UdpClient client;

        public class UdpState
        {
            public IPEndPoint e;
            public UdpClient u;
        }
        
        /*
        for (int i = 20; i < req.Length; i++)
        {
            int AttrCode = Convert.ToInt32(req[i]);
            int AttrLengh = Convert.ToInt32(req[i + 1])-2;
            //tole moshakhase ro 2 vahed kam kardam be khatere in ke code va khode tol zidie rosh
            byte[] AttrArray = new byte[AttrLengh];
            for (int j = i + 2, c = 0; c < AttrLengh; c++,j++)
            {
                AttrArray[c] = req[j];
            }
            string Attr = Encoding.UTF8.GetString(AttrArray);
            string AttrType = string.Empty;
            string hashed;
            if (AttrCode == 1)
                AttrType = "User-Name";
            else if (AttrCode == 2)
            {
                AttrType = "password";
                hashed=HashPassword("WinRadius", reqauthenticator, "shaida");
                this.addtext("HashedPass=" + hashed);
            }
            else if (AttrCode == 6)
                AttrType = "Service-Type";
            this.addtext(AttrType + "=" + Attr);
            i += (AttrLengh+1);// dar asl bayad 2 ta ezafe beshe vali man bala ++ ham tarif kardam
            //-------------------sakhte access-accept-----------
            byte ResCode = 2;
            byte ResWelcomCode = 18;
            byte[] ResWelcomValue = Encoding.UTF8.GetBytes("Welcome user");
            byte ResWelcomlengh = Convert.ToByte(ResWelcomValue.Length + 2);
            int temp=20 + ResWelcomlengh;
            byte[] Reslengh = {Convert.ToByte(temp>>8),Convert.ToByte(temp)};
            byte[] Response=new byte[temp];
            byte[] welcomattr=new byte[2+ResWelcomlengh];
            welcomattr[0]=ResWelcomCode;
            welcomattr[1]=ResWelcomlengh;
            for(int j=2,k=0;k<ResWelcomlengh-2;k++,j++)
                welcomattr[j]=ResWelcomValue[k];
            Response[0]=ResCode;
            Response[1]=Convert.ToByte(identifier);
            Response[2]=Reslengh[0];
            Response[3]=Reslengh[1];
            byte[] ResponseRA=CalcResponseRA(Convert.ToByte(identifier),Reslengh,reqauthenticator,welcomattr,Encoding.UTF8.GetBytes("WinRadius"));
            for(int j=4,k=0;k<16;j++,k++)
            {
                Response[j]=ResponseRA[k];
            }
            for(int j=20,k=0;k<ResWelcomlengh;j++,k++)
            {
                Response[j]=welcomattr[k];
            }
                    
            client2.Send(Response, Response.Length, dummy);
            Thread.Sleep(3000);
            //--------------------------------------------------
        }*/
        //public static bool operator ==(byte[] s, byte[] d)
        //{
        //    if (s.Length != d.Length)
        //        return false;
        //    else
        //    {
        //        for (int i = 0; i < s.Length; i++)
        //            if (s[i] != d[i])
        //                return false;
        //        return true;
        //    }
        //}
        //public static bool operator !=(byte[] s,byte[] d)
        //{
        //    if (s.Length == d.Length)
        //        return false;
        //    else
        //    {
        //        for (int i = 0; i < s.Length; i++)
        //            if (s[i] == d[i])
        //                return false;
        //        return true;
        //    }
        //}
        //public static byte[] operator +(byte[] s1, byte[] s2)
        //{
        //    byte[] res = new byte[s1.Length + s2.Length];
        //    int i;
        //    for (i = 0; i < s1.Length; i++)
        //        res[i] = s1[i];
        //    for (int j = 0; i < res.Length; i++, j++)
        //        res[i] = s2[j];
        //    return res;
        //}


        private void radButton1_Click(object sender, EventArgs e)
        {
            try
            {
                ORGRadiuser or = new ORGRadiuser(1812, 1813);
                or.StartAuthenticationService();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        delegate void addtext_del(string text);
        
        private void addtext(string text)
        {
            if (radTextBox1.InvokeRequired)
            {
                addtext_del d = new addtext_del(addtext);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                radTextBox1.Text += text;
                radTextBox1.Text += "\r\n";
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
