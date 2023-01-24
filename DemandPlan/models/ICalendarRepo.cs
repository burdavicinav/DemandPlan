using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemandPlan.models
{
    /// <summary>
    /// Интерфейс для работы с календарем.
    /// </summary>
    public interface ICalendarRepo
    {
        /// <summary>
        /// Возвращает список доступных дат для заданного города в течение указанного количества дней.
        /// </summary>
        /// <param name="city">Город.</param>
        /// <param name="maxDays">Период в днях.</param>
        /// <returns></returns>
        ObservableCollection<DemandDate> GetList(string city, short maxDays = 7);

        /// <summary>
        /// Возвращает объект в разрезе города на заданную дату.
        /// </summary>
        /// <param name="city">Город.</param>
        /// <param name="date">Дата.</param>
        /// <returns></returns>
        DemandDate GetByCityOnDate(string city, DateTime date);
    }
}
