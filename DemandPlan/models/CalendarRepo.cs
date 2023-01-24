using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemandPlan.models
{
    public class CalendarRepo : ICalendarRepo
    {
        private readonly ObservableCollection<DemandDate> calendar;

        public CalendarRepo()
        {
            // генерация данных
            // для каждого города - 10 дней, начиная с завтрашнего
            // максимальное количество замеров от 1 до 10
            Random rnd = new();

            calendar = new();

            for (int i = 0; i < 10; i++)
            {
                DateTime startDate = DateTime.Now.AddDays(1);

                for (int j = 0; j < 10; j++)
                {
                    DemandDate obj = new()
                    {
                        City = $"city_{i + 1}",
                        Date = startDate.AddDays(j)
                    };

                    // интервалы времени
                    int hour = 10;

                    for (int k = 0; k < 5; k++)
                    {
                        hour += 2;

                        DateTime startInterval = obj.Date.Date + TimeSpan.FromHours(hour);
                        DateTime endInterval = obj.Date.Date + TimeSpan.FromHours(hour + 2);

                        TimeInterval interval = new()
                        {
                            StartTime = startInterval,
                            EndTime = endInterval,
                            Count = (short)rnd.Next(1, 10)
                        };

                        obj.Intervals.Add(interval);
                    }

                    calendar.Add(obj);
                }
            }
        }

        public ObservableCollection<DemandDate> GetList(string city, short maxDays = 7)
        {
            // период
            // отбираются только доступные (количество больше нуля)
            DateTime minDate = DateTime.Now.Date, maxDate = minDate.AddDays(maxDays);

            return new ObservableCollection<DemandDate>(
                calendar
                .Where(
                    x => x.City == city && 
                    x.Date.Date >= minDate &&
                    x.Date.Date <= maxDate &&
                    x.Count > 0)
                .OrderBy(x => x.Date));
        }

        public DemandDate GetByCityOnDate(string city, DateTime date)
        {
            return calendar.Where(
                x => x.City == city && 
                    x.Date.Date == date.Date)
                .FirstOrDefault();
        }
    }
}
