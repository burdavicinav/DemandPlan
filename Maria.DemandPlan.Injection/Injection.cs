﻿using Maria.DemandPlan.BLL;
using Maria.DemandPlan.Models.Repo;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Maria.DemandPlan.Injection
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
                        .AddTransient<IDemandRepo, DemandRepo>()
                        .AddTransient<CalendarService>()
                        .AddTransient<DemandService>();
                }

                return _services;
            }
        }

        private static IServiceCollection _services;
    }
}
