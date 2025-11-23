using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using BlazorCalculator.Services;

namespace BlazorCalculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddWpfBlazorWebView();
            serviceCollection.AddSingleton<CalculatorService>();
            Resources.Add("services", serviceCollection.BuildServiceProvider());
        }
    }
}