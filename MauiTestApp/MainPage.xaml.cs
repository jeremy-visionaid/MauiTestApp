using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

namespace MauiTestApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        [RelayCommand]
        static async Task NavigateTo()
        {
            Debug.WriteLine("Before GoToAsync");
            await Shell.Current.GoToAsync("newPage");
            Debug.WriteLine("After GoToAsync");
        }
    }

}
