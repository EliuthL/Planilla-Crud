namespace Planilla_Crud.Views;
using Planilla_Crud.Views;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    private async void nuevoButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(NevoEmpleado));

    }
}