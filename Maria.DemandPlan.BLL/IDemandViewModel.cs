using Maria.DemandPlan.BLL.Commands;
using Maria.DemandPlan.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Maria.DemandPlan.BLL
{
    public interface IDemandViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Заявки на замеры.
        /// </summary>
        ObservableCollection<Demand> Demands { get; }

        /// <summary>
        /// Кладенарь замеров.
        /// </summary>
        ObservableCollection<DemandDate> Calendar { get; }

        /// <summary>
        /// Интервалы времени.
        /// </summary>
        ObservableCollection<TimeInterval> Intervals { get; }

        /// <summary>
        /// Текущая заявка.
        /// </summary>
        Demand SelectedDemand { get; set; }

        /// <summary>
        /// Текущая дата замера.
        /// </summary>
        DemandDate SelectedDemandDate { get; set; }

        /// <summary>
        /// Текущий временной интервал.
        /// </summary>
        TimeInterval SelectedTimeInterval { get; set; }

        /// <summary>
        /// Фильтр по замерам.
        /// </summary>
        DemandFilter DemandFilter { get; set; }

        /// <summary>
        /// Команда удаления всех заявок.
        /// </summary>
        RelayCommand ClearCommand { get; set; }

        /// <summary>
        /// Фильтр замера по городу.
        /// </summary>
        RelayCommand FilterByCityCommand { get; set; }
    }
}
