using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planilla_Crud.Models
{
    internal class Empleado
    {
        public string? Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public double Salario { get; set; }
        public Cargo Cargo { get; set; } = null!;
    }
}
