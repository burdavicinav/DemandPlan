using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DemandPlan.models
{
    public class DemandDate : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string city;

        private DateTime date;

        private short count;

        public string City
        {
            get
            {
                return city;
            }

            set
            {
                city = value;
                OnPropertyChanged("City");
            }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
                OnPropertyChanged("Date");
            }
        }

        public ObservableCollection<TimeInterval> Intervals { get; set; }

        public string DateStr
        {
            get
            {
                return date.ToString("dd.MM.yyyy");
            }
        }

        public short Count
        {
            get
            {
                count = 0;

                foreach (TimeInterval interval in Intervals)
                {
                    count += interval.Count;
                }

                return count;
            }
        }

        public DemandDate()
        {
            Intervals = new ObservableCollection<TimeInterval>();
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
