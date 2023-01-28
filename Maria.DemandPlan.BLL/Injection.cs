using Microsoft.Extensions.DependencyInjection;

namespace Maria.DemandPlan.BLL
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
                        .AddTransient<IDemandViewModel, DemandViewModel>();
                }

                return _services;
            }
        }

        private static IServiceCollection _services;
    }
}
