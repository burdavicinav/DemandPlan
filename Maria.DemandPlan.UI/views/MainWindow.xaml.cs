﻿using Maria.DemandPlan.UI.ViewModels;
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
            
            DataContext = new DemandViewModel();
        }
    }
}
