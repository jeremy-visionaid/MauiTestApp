using System.Diagnostics;

namespace MauiTestApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            var settings = Properties.Settings.Default;

            if (settings.UpgradeRequired)
            {
                settings.Upgrade();
                settings.UpgradeRequired = false;
                settings.Save();

                HelloLabel.Text = "Settings updated";
            }
            else
            {
                HelloLabel.Text = "Settings are up-to-date";
            }
        }
    }

}
