using System;
using System.Collections.Generic;

namespace SPV.Models
{
    public partial class Compra
    {
        public Compra()
        {
            DetalleCompras = new HashSet<DetalleCompras>();
        }

        public int Id { get; set; }
        public int IdProveedor { get; set; }
        public int IdEmpleado { get; set; }
        public string NumeroFactura { get; set; }
        public DateTime Fecha { get; set; }
        public decimal PrecioTotal { get; set; }

        public virtual Empleado IdEmpleadoNavigation { get; set; }
        public virtual Proveedor IdProveedorNavigation { get; set; }
        public virtual ICollection<DetalleCompras> DetalleCompras { get; set; }
    }
}
