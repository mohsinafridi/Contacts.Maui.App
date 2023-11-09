using CommunityToolkit.Maui;
using Contacts.Maui.Database;
using Contacts.Maui.ViewModel;
using Contacts.Maui.ViewModel.DepartmentViewModels;
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

            builder.Services.AddSingleton<AppDbContext>();

            // Add ViewModels
            builder.Services.AddTransient<DepartmentViewModel>();

            //builder.Services.AddTransient<AddDepartmentViewModel>();
            //builder.Services.AddSingleton<GetDepartmentsViewModel>();

            // Add Views
            builder.Services.AddTransient<CreateDepartmentPage>();
            builder.Services.AddSingleton<DepartmentsPage>();

            return builder.Build();
        }
    }
}