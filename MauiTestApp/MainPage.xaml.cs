using System.Diagnostics;

namespace MauiTestApp;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object? sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);

        AbsoluteLayout a = new();
        Debug.WriteLine(a.SafeAreaEdges);

        ContentPage p = new();
        Debug.WriteLine(p.SafeAreaEdges);
    }
}
