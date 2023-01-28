using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Maria.DemandPlan.Models
{
    public class DemandFilter : INotifyPropertyChanged
    {
        public string City
        {
            get => city;

            set
            {
                city = value;
                OnPropertyChanged("City");
            }
        }

        public string Client
        {
            get => client;

            set
            {
                client = value;
                OnPropertyChanged("Client");
            }
        }

        public bool IsShowEmptyDate
        {
            get => isShowEmptyDate;

            set
            {
                isShowEmptyDate = value;
                OnPropertyChanged("IsShowEmptyDate");
            }
        }

        public DateTime? StartDate
        {
            get => startDate;

            set
            {
                startDate = value;
                OnPropertyChanged("StartDate");
            }
        }

        public DateTime? EndDate
        {
            get => endDate;

            set
            {
                endDate = value;
                OnPropertyChanged("EndDate");
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

        private string city;

        private string client;

        private bool isShowEmptyDate;

        private DateTime? startDate;

        private DateTime? endDate;
    }
}
