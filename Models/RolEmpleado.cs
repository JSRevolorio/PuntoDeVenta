using System;
using System.Collections.Generic;

namespace SPV.Models
{
    public partial class RolEmpleado
    {
        public int IdRol { get; set; }
        public int IdEmpleado { get; set; }

        public virtual Empleado IdEmpleadoNavigation { get; set; }
        public virtual Rol IdRolNavigation { get; set; }
    }
}
