using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPV.Models
{
    public partial class Compra
    {
        public Compra()
        {
            DetalleCompras = new HashSet<DetalleCompras>();
        }

        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }

        [Column("idProveedor", TypeName = "int(11)")]
        public int IdProveedor { get; set; }

        [Column("idEmpleado", TypeName = "int(11)")]
        public int IdEmpleado { get; set; }

        [Required]
        [Column("numeroFactura", TypeName = "varchar(15)")]
        public string NumeroFactura { get; set; }

        [Column("fecha", TypeName = "date")]
        public DateTime Fecha { get; set; }

        [Column("precioTotal", TypeName = "decimal(10,2)")]
        public decimal PrecioTotal { get; set; }

        [ForeignKey(nameof(IdEmpleado))]
        [InverseProperty(nameof(Empleado.Compra))]
        public virtual Empleado _Empleado { get; set; }

        [ForeignKey(nameof(IdProveedor))]
        [InverseProperty(nameof(Proveedor.Compra))]
        public virtual Proveedor _Proveedor { get; set; }

        [InverseProperty("_Compra")]
        public virtual ICollection<DetalleCompras> DetalleCompras { get; set; }
    }
}
