using System;
using System.Collections.Generic;

namespace SPV.Models
{
    public partial class Empleado
    {
        public Empleado()
        {
            Compra = new HashSet<Compra>();
            RolEmpleado = new HashSet<RolEmpleado>();
            Venta = new HashSet<Venta>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int IdGenero { get; set; }
        public string CorreoElectronico { get; set; }
        public string NoTelefono { get; set; }
        public string NoCelular { get; set; }
        public string Direccion { get; set; }
        public string NoDpi { get; set; }
        public string NoNit { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int? Estado { get; set; }

        public virtual Genero IdGeneroNavigation { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Compra> Compra { get; set; }
        public virtual ICollection<RolEmpleado> RolEmpleado { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
