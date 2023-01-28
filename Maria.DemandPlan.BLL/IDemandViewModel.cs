using Maria.DemandPlan.BLL.Commands;
using Maria.DemandPlan.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Maria.DemandPlan.BLL
{
    public interface IDemandViewModel : INotifyPropertyChanged
    {
        ObservableCollection<Demand> Demands { get; }

        ObservableCollection<DemandDate> Calendar { get; }

        ObservableCollection<TimeInterval> Intervals { get; }

        Demand SelectedDemand { get; set; }

        DemandDate SelectedDemandDate { get; set; }

        TimeInterval SelectedTimeInterval { get; set; }

        DemandFilter DemandFilter { get; set; }

        RelayCommand ClearCommand { get; set; }

        RelayCommand FilterByCityCommand { get; set; }
    }
}
