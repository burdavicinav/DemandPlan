using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maria.DemandPlan.Models.Repo
{
    public interface IDemandRepo
    {
        ObservableCollection<Demand> GetList();

        int Count();

        Demand GetByNum(string num);

        ObservableCollection<Demand> GetByClient(string client);

        ObservableCollection<Demand> GetByCity(string city);

        ObservableCollection<Demand> GetList(DemandFilter filter);

        void Add(Demand demand);

        void Remove(Demand demand);

        void Clear();
    }
}
