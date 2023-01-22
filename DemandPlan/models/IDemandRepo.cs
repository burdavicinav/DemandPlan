using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemandPlan.models
{
    public interface IDemandRepo
    {
        ObservableCollection<Demand> GetList();

        int Count();

        Demand GetByNum(string num);

        ObservableCollection<Demand> GetByClient(string client);

        ObservableCollection<Demand> GetByCity(string city);

        void Add(Demand demand);

        void Remove(Demand demand);

        void Clear();
    }
}
