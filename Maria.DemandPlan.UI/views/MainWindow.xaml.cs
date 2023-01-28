using Maria.DemandPlan.BLL;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Maria.DemandPlan.UI.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ServiceProvider provider = 
                Injection.Services.BuildServiceProvider();

            DataContext = provider.GetService<IDemandViewModel>();
        }
    }
}
