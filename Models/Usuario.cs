using System;
using System.Collections.Generic;

namespace SPV.Models
{
    public partial class Usuario
    {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public string Sal { get; set; }
        public int? Estado { get; set; }

        public virtual Empleado IdEmpleadoNavigation { get; set; }
    }
}
