using System;
using System.Collections.Generic;

namespace SPV.Models
{
    public partial class Venta
    {
        public Venta()
        {
            DetalleVenta = new HashSet<DetalleVenta>();
        }

        public int Id { get; set; }
        public int IdFactura { get; set; }
        public int IdCliente { get; set; }
        public int IdEmpleado { get; set; }
        public decimal PrecioTota { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Empleado IdEmpleadoNavigation { get; set; }
        public virtual Factura IdFacturaNavigation { get; set; }
        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; }
    }
}
