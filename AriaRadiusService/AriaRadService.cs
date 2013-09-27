using ORGRadiusBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace AriaRadiusService
{
    public partial class AriaRadService : ServiceBase
    {
        public AriaRadService()
        {
            InitializeComponent();
            if (!System.Diagnostics.EventLog.SourceExists("AriaPardazKoomeshRadius"))
                System.Diagnostics.EventLog.CreateEventSource("AriaPardazKoomeshRadius", "AriaPardazKoomeshLog");
            this.eventLog1.Source = "AriaPardazKoomeshRadius";
            this.eventLog1.Log = "AriaPardazKoomeshLog";
        }

        protected override void OnStart(string[] args)
        {

            try
            {
                ORGRadiuser or = new ORGRadiuser(1812, 1813);
                or.StartAuthenticationService();
                this.eventLog1.WriteEntry("Aria Pardaz Koomesh service start at : " + DateTime.Now.TimeOfDay);
            }
            catch (Exception ex)
            {

                //MessageBox.Show(ex.Message);
            }
        }

        protected override void OnStop()
        {
            this.eventLog1.WriteEntry("Aria Pardaz Koomesh service stop at: " + DateTime.Now.TimeOfDay);
        }
    }
}
