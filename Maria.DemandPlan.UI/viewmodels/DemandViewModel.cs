using Maria.DemandPlan.Models;
using Maria.DemandPlan.Models.Repo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Maria.DemandPlan.UI.Commands;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace Maria.DemandPlan.UI.ViewModels
{
    public class DemandViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Demand> Demands => demands;

        public ObservableCollection<DemandDate> Calendar => calendar;

        public ObservableCollection<TimeInterval> Intervals => intervals;

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
                    OnPropertyChanged("Calendar");

                    intervals = null;
                    OnPropertyChanged("Intervals");
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

                if (selectedDemandDate != null && value != null)
                {
                    intervals = selectedDemandDate.Intervals;
                    OnPropertyChanged("Intervals");
                }
            }
        }

        public TimeInterval SelectedTimeInterval
        {
            get => selectedTimeInterval;

            set
            {
                selectedTimeInterval = value;
                OnPropertyChanged("SelectedTimeInterval");

                if (selectedTimeInterval != null)
                {
                    if (selectedDemand.Date != null)
                    {
                        DemandDate demandDate = calendarRepo.GetByCityOnDate(selectedDemand.City, selectedDemand.Date.Value);

                        foreach (TimeInterval interval in demandDate.Intervals)
                        {
                            if (interval.Period == selectedDemand.Interval)
                            {
                                interval.Count++;
                            }
                        }
                    }

                    selectedDemand.Date = selectedTimeInterval.StartTime.Date;
                    selectedDemand.Interval = selectedTimeInterval.Period;

                    if (selectedTimeInterval.Count > 0)
                    {
                        selectedTimeInterval.Count--;
                    }
                    
                    calendar = calendarRepo.GetList(SelectedDemand.City);
                    OnPropertyChanged("Calendar");
                }
            }
        }

        public DemandFilter DemandFilter { get; set; }

        public RelayCommand AddCommand { get; set; }

        public RelayCommand RemoveCommand { get; set; }

        public RelayCommand ClearCommand { get; set; }

        public RelayCommand FilterByCityCommand { get; set; }

        public DemandViewModel()
        {
            ServiceProvider provider = Injection.Injection.Services
                .BuildServiceProvider();

            // репозитории
            demandRepo = provider.GetService<IDemandRepo>();
            calendarRepo = provider.GetService<ICalendarRepo>();

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

        private IDemandRepo demandRepo;

        private ICalendarRepo calendarRepo;

        private Demand selectedDemand;

        private DemandDate selectedDemandDate;

        private TimeInterval selectedTimeInterval;

        private ObservableCollection<Demand> demands;

        private ObservableCollection<DemandDate> calendar;

        private ObservableCollection<TimeInterval> intervals;
    }
}
