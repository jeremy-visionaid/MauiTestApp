using System.Diagnostics;

namespace MauiTestApp
{
    public partial class MainPage : ContentPage
    {
        bool alerted = false;

        public MainPage()
        {
            InitializeComponent();
        }

        async void OnPinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
        {
            Debug.WriteLine($"Pinch Updated: Status: {e.Status}");
            if (e.Status == GestureStatus.Running)
            {
                if (!alerted)
                {
                    alerted = true;
                    await DisplayAlert("Pinch Updated", "Message", "OK");
                }
            }
        }
    }

}
