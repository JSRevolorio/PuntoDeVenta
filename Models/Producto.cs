using System;
using System.Collections.Generic;

namespace SPV.Models
{
    public partial class Producto
    {
        public Producto()
        {
            DetalleCompras = new HashSet<DetalleCompras>();
            DetalleVenta = new HashSet<DetalleVenta>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Marca { get; set; }
        public int IdCategoria { get; set; }
        public int IdProveedor { get; set; }
        public DateTime FechaDeVencimiento { get; set; }
        public int? Estado { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; }
        public virtual Proveedor IdProveedorNavigation { get; set; }
        public virtual Inventario Inventario { get; set; }
        public virtual ICollection<DetalleCompras> DetalleCompras { get; set; }
        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; }
    }
}
