using System;
using System.Collections.Generic;

namespace SPV.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Venta = new HashSet<Venta>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NoNit { get; set; }
        public string NoTelefono { get; set; }
        public string CorreoElectronico { get; set; }
        public string Direccion { get; set; }
        public int? Estado { get; set; }

        public virtual ICollection<Venta> Venta { get; set; }
    }
}
