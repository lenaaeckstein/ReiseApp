using ReiseApp.Core.ViewModels;

namespace ReiseApp.Gui;


public partial class MainPage : ContentPage
{
    public MainPage(ReiseViewModel viewmodel)
    {
        InitializeComponent();
        this.BindingContext = viewmodel;
    }

}