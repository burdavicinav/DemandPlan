using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Maria.DemandPlan.Models
{
    /// <summary>
    /// Заявка на замер.
    /// </summary>
    public class Demand : INotifyPropertyChanged
    {
        public Demand()
        {
        }

        /// <summary>
        /// Номер.
        /// </summary>
        public string Num
        {
            get => num;

            set
            {
                num = value;

                OnPropertyChanged("Num");
            }
        }

        /// <summary>
        /// ФИО клиента.
        /// </summary>
        public string ClientName
        {
            get => clientName;

            set
            {
                clientName = value;

                OnPropertyChanged("ClientName");
            }
        }

        /// <summary>
        /// Город.
        /// </summary>
        public string City
        {
            get => city;

            set
            {
                city = value;

                OnPropertyChanged("City");
            }
        }

        /// <summary>
        /// Адрес.
        /// </summary>
        public string Address
        {
            get => address;

            set
            {
                address = value;

                OnPropertyChanged("Address");
            }
        }

        /// <summary>
        /// Телефон.
        /// </summary>
        public string Phone
        {
            get => phone;

            set
            {
                phone = value;

                OnPropertyChanged("Phone");
            }
        }

        /// <summary>
        /// Дата.
        /// </summary>
        public DateTime? Date
        {
            get => date;

            set
            {
                date = value;
                OnPropertyChanged("DateString");
            }
        }

        public string DateString
        {
            get
            {
                if (Date.HasValue)
                {
                    return Date.Value.ToString("dd.MM.yyyy");
                }

                return string.Empty;
            }
        }

        public string Interval
        {
            get => interval;

            set
            {
                interval = value;
                OnPropertyChanged("Interval");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private string num;

        private string clientName;

        private string city;

        private string address;

        private string phone;

        private string interval;

        private DateTime? date;
    }
}
