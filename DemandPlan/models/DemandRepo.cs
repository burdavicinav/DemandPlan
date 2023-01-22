using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemandPlan.models
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

                int phoneMainPart = rnd.Next(9999999);

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
            return new ObservableCollection<Demand>(demands.Where(x => x.ClientName == client));
        }

        public ObservableCollection<Demand> GetByCity(string city)
        {
            return new ObservableCollection<Demand>(demands.Where(x => x.City == city));
        }

        public void Add(Demand demand)
        {
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
