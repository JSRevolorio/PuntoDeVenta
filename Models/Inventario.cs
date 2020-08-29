using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPV.Models
{
    public partial class Inventario
    {
        [Key]
        [Column("idProducto", TypeName = "int(11)")]
        public int IdProducto { get; set; }

        [Column("cantidad", TypeName = "int(11)")]
        public int Cantidad { get; set; }

        [Column("precio", TypeName = "decimal(10,2)")]
        public decimal Precio { get; set; }

        [Column("iva", TypeName = "int(11)")]
        public int? Iva { get; set; }

        [ForeignKey(nameof(IdProducto))]
        [InverseProperty(nameof(Producto.Inventario))]
        public virtual Producto _Producto { get; set; }
    }
}
