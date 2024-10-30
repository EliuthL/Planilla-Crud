using Firebase.Database;
using Firebase.Database.Query;
using Planilla_Crud.Models;

namespace Planilla_Crud.Views;

public partial class NevoEmpleado : ContentPage
{
    FirebaseClient client = new FirebaseClient("https://fir-crud-cbd6b-default-rtdb.firebaseio.com/");
    public List<Cargo> Cargos { get; set; }
    public NevoEmpleado()
	{
		InitializeComponent();
        CargarCargos();
        BindingContext = this;
        
    }

    private void guardarButton_Clicked(object sender, EventArgs e)
    {
        SaveEmpleadoAsync();
    }

    public void CargarCargos()
    {
        var cargos = client
            .Child("Cargos")
            .OnceAsync<Cargo>();

        Cargos = cargos.Result.Select(item => new Cargo
        {
            Nombre = item.Object.Nombre
        }).ToList();
    }

    public async Task SaveEmpleadoAsync()
    {
        try
        {
            // Validar que los campos no est�n vac�os
            if (string.IsNullOrWhiteSpace(nombreEntry.Text) ||
                string.IsNullOrWhiteSpace(salaryEntry.Text) ||
                cargosPicker.SelectedItem == null)
            {
                await DisplayAlert("Error", "Por favor, completa todos los campos obligatorios.", "OK");
                return; // Salir si hay campos vac�os
            }

            // Intentar convertir el salario a double
            if (!double.TryParse(salaryEntry.Text, out double salario))
            {
                await DisplayAlert("Error", "Por favor, ingresa un salario v�lido (solo n�meros).", "OK");
                return; // Salir si el salario no es v�lido
            }

            // Crear el nuevo empleado
            Empleado empleado = new Empleado
            {
                Nombre = nombreEntry.Text,
                FechaInicio = datePicker.Date,
                Salario = salario,
                Cargo = (Cargo)cargosPicker.SelectedItem
            };

            // Guardar el empleado en la base de datos
            var resultado = await client.Child("Empleados").PostAsync(empleado);

            // Mostrar un mensaje de �xito
            await DisplayAlert("�xito", "Empleado guardado correctamente.", "OK");
            await Shell.Current.GoToAsync(".."); // Regresar a la p�gina anterior
        }
        catch (Exception ex)
        {
            // Manejar excepciones, mostrar mensaje de error
            await DisplayAlert("Error", $"Ocurri� un error al guardar el empleado: {ex.Message}", "OK");
        }
    }

}