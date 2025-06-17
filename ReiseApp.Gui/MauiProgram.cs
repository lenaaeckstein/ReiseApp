using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using ReiseApp.Core.ViewModels;
using ReiseApp.Data.Services;
using ReiseApp.Gui.pages;

namespace ReiseApp.Gui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>().ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            }).UseMauiCommunityToolkit();

            System.Diagnostics.Debug.WriteLine("Path:");
            string path = FileSystem.Current.AppDataDirectory;
            string filename = "money.sqlite";

            string fullpath = System.IO.Path.Combine(path, filename);
            System.Diagnostics.Debug.WriteLine(fullpath);

            #region VmAndServices
            builder.Services.AddSingleton<ReiseViewModel>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<IRepository>(new ReiseRepository(fullpath));
            builder.Services.AddSingleton<AddPage>();
            builder.Services.AddSingleton<AddPageViewModel>();



            #endregion

#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}