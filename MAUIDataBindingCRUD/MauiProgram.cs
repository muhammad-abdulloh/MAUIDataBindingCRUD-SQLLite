using MAUIDataBindingCRUD.Services;
using Microsoft.Extensions.Logging;

namespace MAUIDataBindingCRUD
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
                });

            // SOLID

            // Single Responsibility Prinspl
            // har bir method bir dona ish qilish kerak

            // Open Closed Prinspl
            // qo'shish uchun ochiq - O'zgartirish uchun yopiq

            // Liskov Substition Prinspl
            // 

            // Interface Segregation Prinspl
            // D => Dependency Inversion Prinspl

            // IoC => Invertion of Control
            // Depencency Injection => DI Container => LifeSycle => Transient, Scoped, Singleton

            // Dependency inversion
            builder.Services.AddSingleton<CustomerDBService>();
            builder.Services.AddTransient<MainPage>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
