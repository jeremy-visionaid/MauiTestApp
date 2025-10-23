using System.Diagnostics;

namespace MauiTestApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
            {
                Console.WriteLine($"Unhandled exception event");
                var ex = args.ExceptionObject as Exception;
            };
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            Console.WriteLine($"Throwing exception");
            throw new InvalidOperationException("Test exception.");
        }
    }
}
