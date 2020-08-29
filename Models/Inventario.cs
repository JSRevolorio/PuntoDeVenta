using System;
using System.Collections.Generic;

namespace SPV.Models
{
    public partial class Inventario
    {
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public int? Iva { get; set; }

        public virtual Producto IdProductoNavigation { get; set; }
    }
}
