namespace MauiTestApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            ButtonFontImageSource.Glyph = count % 2 == 0 ? "&#xE73F;" : "&#xE740;";
        }
    }

}
