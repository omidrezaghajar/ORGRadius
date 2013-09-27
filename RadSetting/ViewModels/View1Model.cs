using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using System.ComponentModel;

namespace RadSetting
{
	public class View1Model : INotifyPropertyChanged
	{
		public View1Model()
		{
			
		}
        private string ip;
        public float ip1
        {
            set
            {
                ip
                NotifyPropertyChanged("ip1");
            }
        }
		#region INotifyPropertyChanged
		public event PropertyChangedEventHandler PropertyChanged;

		private void NotifyPropertyChanged(String info)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(info));
			}
		}
		#endregion
	}
}