using System;
using System.Collections.Generic;

namespace SPV.Models
{
    public partial class Factura
    {
        public int Id { get; set; }
        public string Serie { get; set; }
        public string Numero { get; set; }
        public DateTime Fecha { get; set; }
        public int? Estado { get; set; }

        public virtual Venta Venta { get; set; }
    }
}
