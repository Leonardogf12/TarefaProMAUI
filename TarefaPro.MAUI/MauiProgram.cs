using CommunityToolkit.Maui;
using TarefaPro.MAUI.MVVM.ViewModels.Category;
using TarefaPro.MAUI.MVVM.ViewModels.Tasks;
using TarefaPro.MAUI.MVVM.Views.Category;
using TarefaPro.MAUI.MVVM.Views.Components.Category;
using TarefaPro.MAUI.MVVM.Views.Tasks;
using TarefaPro.MAUI.Services;

namespace TarefaPro.MAUI
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
                    fonts.AddFont("Montserrat-Regular.ttf", "MontserratRegular");
                    fonts.AddFont("Montserrat-Bold.ttf", "MontserratBold");
                    fonts.AddFont("Montserrat-SemiBold.ttf", "MontserratSemiBold");
                });

            builder.Services.AddTransient<CategoriesPage>();
            builder.Services.AddTransient<AddCategoryPage>();
            builder.Services.AddTransient<EditCategoryPage>();
            builder.Services.AddTransient<PopupCategoriesPage>();
            builder.Services.AddTransient<TaskiesPage>();
            builder.Services.AddTransient<AddTaskPage>();


            builder.Services.AddTransient<CategoriesViewModel>();
            builder.Services.AddTransient<AddCategoryViewModel>();
            builder.Services.AddTransient<EditCategoryViewModel>();
            builder.Services.AddTransient<PopupCategoriesViewModel>();
            builder.Services.AddTransient<TaskiesViewModel>();


            builder.Services.AddSingleton<INavigationService, NavigationService>();

            return builder.Build();
        }
    }
}