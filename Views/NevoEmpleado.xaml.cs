using Firebase.Database;
using Firebase.Database.Query;
using Planilla_Crud.Models;

namespace Planilla_Crud.Views;

public partial class NevoEmpleado : ContentPage
{
    FirebaseClient firebase = new FirebaseClient("https://fir-crud-cbd6b-default-rtdb.firebaseio.com/");
    public List<Cargo> Cargos { get; set; }
    public NevoEmpleado()
	{
		InitializeComponent();
        CargarCargos();
        BindingContext = this;
    }

    private void guardarButton_Clicked(object sender, EventArgs e)
    {

    }

    public void CargarCargos()
    {
        var cargos = firebase
            .Child("Cargos")
            .OnceAsync<Cargo>();

        Cargos = cargos.Result.Select(item => new Cargo
        {
            Nombre = item.Object.Nombre
        }).ToList();
    }
}