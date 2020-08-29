using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPV.Models
{
    public partial class DetalleVenta
    {
        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }

        [Column("idVenta", TypeName = "int(11)")]
        public int IdVenta { get; set; }

        [Column("idProducto", TypeName = "int(11)")]
        public int IdProducto { get; set; }

        [Column("cantidad", TypeName = "int(11)")]
        public int Cantidad { get; set; }

        [Column("precioCantidad", TypeName = "decimal(10,2)")]
        public decimal PrecioCantidad { get; set; }

        [ForeignKey(nameof(IdProducto))]
        [InverseProperty(nameof(Producto.DetalleVenta))]
        public virtual Producto _Producto { get; set; }

        [ForeignKey(nameof(IdVenta))]
        [InverseProperty(nameof(Venta.DetalleVenta))]
        public virtual Venta _Venta { get; set; }
    }
}
