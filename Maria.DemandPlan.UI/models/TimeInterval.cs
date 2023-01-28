using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Maria.DemandPlan.UI.Models
{
    public class TimeInterval : INotifyPropertyChanged
    {
        private DateTime startTime;

        private DateTime endTime;

        private short count;

        public DateTime StartTime
        {
            get => startTime;

            set
            {
                startTime = value;
                OnPropertyChanged("StartTime");
            }
        }

        public DateTime EndTime
        {
            get => endTime;

            set
            {
                endTime = value;
                OnPropertyChanged("EndTime");
            }
        }

        public short Count
        {
            get => count;

            set
            {
                count = value;
                OnPropertyChanged("Count");
            }
        }

        public string Period
        {
            get
            {
                return StartTime.ToString("HH.mm.ss") + " - " + EndTime.ToString("HH.mm.ss");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
