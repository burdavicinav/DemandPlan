using Maria.DemandPlan.UI.Exceptions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Maria.DemandPlan.UI.Models
{
    public class DemandRepo : IDemandRepo
    {
        private ObservableCollection<Demand> demands;

        public DemandRepo()
        {
            demands = new();

            for (int i = 0; i < 20; i++)
            {
                Random rnd = new Random();

                int[] phonePrefixes = { 499, 903, 905, 962 };

                int prefixIndex = rnd.Next(phonePrefixes.Length);

                int phoneMainPart = rnd.Next(1000000, 9999999);

                // номер телефона
                string phone = $"{8} {phonePrefixes[prefixIndex]} {phoneMainPart}";

                Demand demand = new()
                {
                    Num = (i + 1).ToString("000000"),
                    ClientName = $"client_{i + 1}",
                    City = $"city_{i + 1}",
                    Address = $"address_{i + 1}",
                    Phone = phone
                };

                Add(demand);
            }
        }
        public ObservableCollection<Demand> GetList()
        {
            return demands;
        }

        public Demand GetByNum(string num)
        {
            return demands.FirstOrDefault(x => x.Num == num);
        }

        public ObservableCollection<Demand> GetByClient(string client)
        { 
            return new ObservableCollection<Demand>(demands.Where(x => x.ClientName.Contains(client)));
        }

        public ObservableCollection<Demand> GetByCity(string city)
        {
            return new ObservableCollection<Demand>(demands.Where(x => x.City.Contains(city)));
        }

        public ObservableCollection<Demand> GetList(DemandFilter filter)
        {
            IEnumerable<Demand> _demands = demands;

            if (filter.City != null)
            {
                _demands = _demands.Where(x => x.City.Contains(filter.City));
            }

            if (filter.Client != null)
            {
                _demands = _demands.Where(x => x.ClientName.Contains(filter.Client));
            }

            if (filter.IsShowEmptyDate)
            {
                _demands = _demands.Where(x => !x.Date.HasValue);
            }

            if (filter.StartDate.HasValue)
            {
                _demands = _demands.Where(x => x.Date >= filter.StartDate);
            }

            if (filter.EndDate.HasValue)
            {
                _demands = _demands.Where(x => x.Date <= filter.EndDate);
            }

            return new ObservableCollection<Demand>(_demands);
        }

        public void Add(Demand demand)
        {
            // проверка формата номера заявки
            if (demand.Num.Length != 6)
            {
                throw new DemandNumFormatException();
            }

            Regex phonePattern = new(@"^8 (499|903|905|962) \d{7}$");

            // проверка формата номера телефона
            if (!phonePattern.IsMatch(demand.Phone))
            {
                throw new DemandPhoneFormatException();
            }

            demands.Add(demand);
        }

        public void Remove(Demand demand)
        {
            demands.Remove(demand);
        }

        public int Count()
        {
            return demands.Count;
        }

        public void Clear()
        {
            demands.Clear();
        }
    }
}
