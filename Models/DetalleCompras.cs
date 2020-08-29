using System;
using System.Collections.Generic;

namespace SPV.Models
{
    public partial class DetalleCompras
    {
        public int Id { get; set; }
        public int IdCompra { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioCantidad { get; set; }
        public int? Iva { get; set; }

        public virtual Compra IdCompraNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
    }
}
