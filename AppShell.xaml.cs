using Planilla_Crud.Views;

namespace Planilla_Crud
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(NevoEmpleado), typeof(NevoEmpleado));
        }
    }
}
