namespace Planilla_Crud.Views;
using Planilla_Crud.Views;
using Planilla_Crud.Models;
using System.Collections.ObjectModel;
using Firebase.Database;
using System.Globalization;
using System.Collections.Specialized;

public partial class MainPage : ContentPage
{
    FirebaseClient client = new FirebaseClient("https://fir-crud-cbd6b-default-rtdb.firebaseio.com/");
    public ObservableCollection<Empleado> Lista { get; set; } = new();

    public MainPage()
    {
        InitializeComponent();
        CargarEmpleados();
        BindingContext = this;
    }

    private async void nuevoButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(NevoEmpleado));
    }

    public void CargarEmpleados()
    {
        client
            .Child("Empleados")
            .AsObservable<Empleado>()
            .Subscribe((empleado) =>
            {
                if (empleado != null)
                {
                    Lista.Add(empleado.Object);
                }
            });
    }

    public void filtro()
    {
        string filtro = filtroEntry.Text;
    }

    private void filtroEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        string filtro = filtroEntry.Text.ToLower();
        if (filtro.Length >0)
        {
            listaCollection.ItemsSource = Lista.Where(x => x.Nombre.ToLower().Contains(filtro));
        }
        else
        {
            listaCollection.ItemsSource = Lista;
        }

    }
}
