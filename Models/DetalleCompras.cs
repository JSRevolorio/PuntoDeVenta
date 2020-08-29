using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPV.Models
{
    public partial class DetalleCompras
    {
        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }

        [Column("idCompra", TypeName = "int(11)")]
        public int IdCompra { get; set; }

        [Column("idProducto", TypeName = "int(11)")]
        public int IdProducto { get; set; }

        [Column("cantidad", TypeName = "int(11)")]
        public int Cantidad { get; set; }

        [Column("precioCantidad", TypeName = "decimal(10,2)")]
        public decimal PrecioCantidad { get; set; }

        [Column("iva", TypeName = "int(11)")]
        public int? Iva { get; set; }

        [ForeignKey(nameof(IdCompra))]
        [InverseProperty(nameof(Compra.DetalleCompras))]
        public virtual Compra _Compra { get; set; }

        [ForeignKey(nameof(IdProducto))]
        [InverseProperty(nameof(Producto.DetalleCompras))]
        public virtual Producto _Producto { get; set; }
    }
}
