using TarefaPro.MAUI.MVVM.ViewModels;
using TarefaPro.MAUI.MVVM.Views;

namespace TarefaPro.MAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
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

            builder.Services.AddTransient<CategoriesViewModel>();
            builder.Services.AddTransient<AddCategoryViewModel>();


            return builder.Build();
        }
    }
}