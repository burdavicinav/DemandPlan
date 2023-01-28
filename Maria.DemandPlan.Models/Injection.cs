using Maria.DemandPlan.Models.Repo;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Maria.DemandPlan.Models
{
    public class Injection
    {
        public static IServiceCollection Services
        {
            get
            {
                if (_services == null)
                {
                    _services = new ServiceCollection()
                        .AddTransient<ICalendarRepo, CalendarRepo>()
                        .AddTransient<IDemandRepo, DemandRepo>();
                }

                return _services;
            }
        }

        private static IServiceCollection _services;
    }
}
