using System;
using System.Collections.Generic;

namespace SPV.Models
{
    public partial class Rol
    {
        public Rol()
        {
            RolEmpleado = new HashSet<RolEmpleado>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<RolEmpleado> RolEmpleado { get; set; }
    }
}
