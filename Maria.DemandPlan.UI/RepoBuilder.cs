using Maria.DemandPlan.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maria.DemandPlan.UI
{
    public static class RepoBuilder
    {
        public static IDemandRepo DemandRepo => new DemandRepo();

        public static ICalendarRepo CalendarRepo => new CalendarRepo();
    }
}
