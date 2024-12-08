namespace MauiTestApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("newPage", typeof(NewPage1));
        }
    }
}
