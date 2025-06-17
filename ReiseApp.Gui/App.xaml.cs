using ReiseApp.Core.ViewModels;
using ReiseApp.Data.Services;

namespace ReiseApp.Gui;

public partial class App : Application
{
    public static string DbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "reise.db");

    public static ReiseRepository Repository { get; private set; }

    public App()
    {
        InitializeComponent();

        Repository = new ReiseRepository(DbPath);

        var viewModel = new ReiseViewModel(Repository);

        MainPage = new AppShell();

        // Falls du ViewModel an MainPage oder Shell übergeben willst,
        // musst du das explizit in den Pages machen (über Dependency Injection oder BindingContext).
    }


}
