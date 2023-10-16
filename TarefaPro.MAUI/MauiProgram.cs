using CommunityToolkit.Maui;
using Plugin.LocalNotification;
using TarefaPro.MAUI.MVVM.ViewModels;
using TarefaPro.MAUI.MVVM.ViewModels.Category;
using TarefaPro.MAUI.MVVM.ViewModels.Tasks;
using TarefaPro.MAUI.MVVM.Views.Category;
using TarefaPro.MAUI.MVVM.Views.Components;
using TarefaPro.MAUI.MVVM.Views.Tasks;
using TarefaPro.MAUI.Services;
using TarefaPro.MAUI.Services.Firebase;
using Microsoft.Maui.LifecycleEvents;
using Plugin.Firebase.Auth;
using Plugin.Firebase.Shared;
#if IOS
using Plugin.Firebase.iOS;
#endif
#if ANDROID
using Plugin.Firebase.Android;
#endif

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
                .UseLocalNotification()
                .RegisterFirebaseServices()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Montserrat-Regular.ttf", "MontserratRegular");
                    fonts.AddFont("Montserrat-Bold.ttf", "MontserratBold");
                    fonts.AddFont("Montserrat-SemiBold.ttf", "MontserratSemiBold");
                });
           
            builder.Services.AddTransient<PopupActionsPage>();
            builder.Services.AddTransient<PopupActionsDetailPage>();

            builder.Services.AddTransient<CategoriesPage>();
            builder.Services.AddTransient<AddCategoryPage>();
            builder.Services.AddTransient<EditCategoryPage>();            
            builder.Services.AddTransient<TaskiesPage>();
            builder.Services.AddTransient<AddTaskPage>();
            builder.Services.AddTransient<EditTaskPage>();

            builder.Services.AddTransient<PopupActionsViewModel>();
            builder.Services.AddTransient<PopupActionsDetailViewModel>();
            builder.Services.AddTransient<CategoriesViewModel>();
            builder.Services.AddTransient<AddCategoryViewModel>();
            builder.Services.AddTransient<EditCategoryViewModel>();            
            builder.Services.AddTransient<TaskiesViewModel>();
            builder.Services.AddTransient<AddTaskViewModel>();
            builder.Services.AddTransient<EditTaskViewModel>();

            builder.Services.AddSingleton<INavigationService, NavigationService>();
            builder.Services.AddSingleton<INotificationFirebaseService, NotificationFirebaseService>();

            return builder.Build();
        }

        private static MauiAppBuilder RegisterFirebaseServices(this MauiAppBuilder builder)
        {
            builder.ConfigureLifecycleEvents(events =>
            {
#if IOS
                events.AddiOS(iOS => iOS.FinishedLaunching((app, launchOptions) =>
                {
                    CrossFirebase.Initialize(app, launchOptions, CreateCrossFirebaseSettings());
                    return false;
                }));
#else
                events.AddAndroid(android => android.OnCreate((activity, state) =>
                CrossFirebase.Initialize(activity, state, CreateCrossFirebaseSettings())));
#endif
            });

            builder.Services.AddSingleton(_ => CrossFirebaseAuth.Current);

            return builder;
        }

        private static CrossFirebaseSettings CreateCrossFirebaseSettings()
        {
            return new CrossFirebaseSettings(isAuthEnabled: true);
        }
    }
}