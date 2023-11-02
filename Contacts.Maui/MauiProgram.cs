using CommunityToolkit.Maui;
using Contacts.Maui.ViewModel;
using Contacts.Maui.Views.Department;
using Microsoft.Extensions.Logging;

namespace Contacts.Maui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif

            // Add ViewModels
            builder.Services.AddTransient<AddDepartmentViewModel>();

            // Add Views
            builder.Services.AddTransient<CreateDepartmentPage>();

            return builder.Build();
        }
    }
}