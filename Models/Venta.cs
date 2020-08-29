using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPV.Models
{
    public partial class Venta
    {
        public Venta()
        {
            DetalleVenta = new HashSet<DetalleVenta>();
        }

        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }

        [Column("idFactura", TypeName = "int(11)")]
        public int IdFactura { get; set; }

        [Column("idCliente", TypeName = "int(11)")]
        public int IdCliente { get; set; }

        [Column("idEmpleado", TypeName = "int(11)")]
        public int IdEmpleado { get; set; }

        [Column("precioTota", TypeName = "decimal(10,2)")]
        public decimal PrecioTota { get; set; }

        [ForeignKey(nameof(IdCliente))]
        [InverseProperty(nameof(Cliente.Venta))]
        public virtual Cliente _Cliente { get; set; }

        [ForeignKey(nameof(IdEmpleado))]
        [InverseProperty(nameof(Empleado.Venta))]
        public virtual Empleado _Empleado { get; set; }

        [ForeignKey(nameof(IdFactura))]
        [InverseProperty(nameof(Factura.Venta))]
        public virtual Factura _Factura { get; set; }

        [InverseProperty("_Venta")]
        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; }
    }
}
