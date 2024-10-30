using Microsoft.Extensions.Logging;
using Firebase.Database;
using Planilla_Crud.Models;
using Firebase.Database.Query;

namespace Planilla_Crud
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

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            Registrar();
            return builder.Build();
        }

        public static void Registrar()
        {
            FirebaseClient client = new FirebaseClient("https://fir-crud-cbd6b-default-rtdb.firebaseio.com/");

            var cargos = client.Child("Cargos").OnceAsync<Cargo>();

            if (cargos.Result.Count == 0)
            {
                client.Child("Cargos").PostAsync(new Cargo { Nombre = "Gerente" });
                client.Child("Cargos").PostAsync(new Cargo { Nombre = "Supervisor" });
                client.Child("Cargos").PostAsync(new Cargo { Nombre = "Empleado" });
            }
        }
    }
}
