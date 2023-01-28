using Maria.DemandPlan.Models;
using Maria.DemandPlan.Models.Repo;
using Maria.DemandPlan.BLL.Commands;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using Microsoft.Extensions.DependencyInjection;

namespace Maria.DemandPlan.BLL
{
    public class DemandViewModel : IDemandViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

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

        public RelayCommand ClearCommand { get; set; }

        public RelayCommand FilterByCityCommand { get; set; }

        public DemandViewModel()
        {
            ServiceProvider provider = Models.Injection.Services.BuildServiceProvider();

            // репозитории
            demandRepo = provider.GetService<IDemandRepo>();
            calendarRepo = provider.GetService<ICalendarRepo>();

            demands = demandRepo.GetList();

            // команды
            FilterByCityCommand = new(o =>
            {
                DemandFilter filter = o as DemandFilter;

                demands = demandRepo.GetList(filter);
                OnPropertyChanged("demands");
            }
            );

            DemandFilter = new();
        }

        private readonly IDemandRepo demandRepo;

        private readonly ICalendarRepo calendarRepo;

        private Demand selectedDemand;

        private DemandDate selectedDemandDate;

        private TimeInterval selectedTimeInterval;

        private ObservableCollection<Demand> demands;

        private ObservableCollection<DemandDate> calendar;

        private ObservableCollection<TimeInterval> intervals;
    }
}
