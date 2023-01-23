using DemandPlan.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using DemandPlan.commands;
using System.Windows;

namespace DemandPlan.viewmodels
{
    public class DemandViewModel : INotifyPropertyChanged
    {
        private IDemandRepo demandRepo;

        private ICalendarRepo calendarRepo;

        private Demand selectedDemand;

        private DemandDate selectedDemandDate;

        private ObservableCollection<Demand> demands;

        private ObservableCollection<DemandDate> calendar;

        public ObservableCollection<Demand> Demands => demands;

        public ObservableCollection<DemandDate> Calendar => calendar;

        public Demand SelectedDemand
        {
            get => selectedDemand;

            set
            {
                selectedDemand = value;
                OnPropertyChanged("SelectedDemand");

                if (selectedDemand != null)
                {
                    calendar = calendarRepo.GetList(value.City);
                    OnPropertyChanged("calendar");
                }
            }
        }

        public DemandDate SelectedDemandDate
        {
            get => selectedDemandDate;

            set
            {
                selectedDemandDate = value;
                OnPropertyChanged("SelectedDemandDate");

                if (selectedDemand != null && value != null)
                {
                    // если дата уже заполнена
                    if (selectedDemand.Date.HasValue)
                    {
                        DemandDate demandDate =
                            calendarRepo.GetByCityOnDate(
                                selectedDemand.City, selectedDemand.Date.Value);

                        // если дата не изменяется
                        if (value.Date.Date == selectedDemand.Date.Value.Date)
                        {
                            return;
                        }

                        // то количество замеров на старую дату увеличивается
                        calendarRepo.CountUp(demandDate);
                    }

                    selectedDemand.Date = value.Date;

                    // количетсов замеров на дату уменьшается
                    calendarRepo.CountDown(value);

                    calendar = calendarRepo.GetList(value.City);
                    OnPropertyChanged("calendar");
                }
            }
        }

        public DemandFilter DemandFilter { get; set; }

        public RelayCommand AddCommand { get; set; }

        public RelayCommand RemoveCommand { get; set; }

        public RelayCommand ClearCommand { get; set; }

        public RelayCommand FilterByCityCommand { get; set; }

        public DemandViewModel(IDemandRepo demandRepo, ICalendarRepo calendarRepo)
        {
            // репозитории
            this.demandRepo = demandRepo;

            this.calendarRepo = calendarRepo;

            demands = demandRepo.GetList();

            // команды
            AddCommand = new(o =>
            {
                Demand demand = new()
                {
                    Num = "test123",
                    ClientName = "cn1"
                };

                demandRepo.Add(demand);
                SelectedDemand = demand;
            });

            RemoveCommand = new(o =>
            {
                Demand demand = o as Demand;

                if (demand != null)
                {
                    demandRepo.Remove(demand);
                }
            },
            (o => demandRepo.Count() > 0)
            );

            ClearCommand = new(o =>
            {
                demandRepo.Clear();
            }
            );

            FilterByCityCommand = new(o =>
            {
                DemandFilter filter = o as DemandFilter;

                demands = demandRepo.GetList(filter);
                OnPropertyChanged("demands");
            }
            );

            DemandFilter = new();
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
