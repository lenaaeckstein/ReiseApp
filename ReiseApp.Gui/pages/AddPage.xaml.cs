using ReiseApp.Core.ViewModels;
namespace ReiseApp.Gui.pages;

public partial class AddPage : ContentPage
{
    public AddPage(AddPageViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = viewModel;
        }
}