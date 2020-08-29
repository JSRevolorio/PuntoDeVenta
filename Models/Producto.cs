using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPV.Models
{
    public partial class Producto
    {
        public Producto()
        {
            DetalleCompras = new HashSet<DetalleCompras>();
            DetalleVenta = new HashSet<DetalleVenta>();
        }

        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }

        [Required]
        [Column("nombre", TypeName = "varchar(150)")]
        public string Nombre { get; set; }

        [Required]
        [Column("descripcion", TypeName = "varchar(500)")]
        public string Descripcion { get; set; }

        [Required]
        [Column("marca", TypeName = "varchar(50)")]
        public string Marca { get; set; }

        [Column("idCategoria", TypeName = "int(11)")]
        public int IdCategoria { get; set; }

        [Column("idProveedor", TypeName = "int(11)")]
        public int IdProveedor { get; set; }

        [Column("fechaDeVencimiento", TypeName = "date")]
        public DateTime FechaDeVencimiento { get; set; }

        [Column("estado", TypeName = "int(11)")]
        public int? Estado { get; set; }

        [ForeignKey(nameof(_Categoria))]
        [InverseProperty(nameof(Categoria.Producto))]
        public virtual Categoria _Categoria { get; set; }

        [ForeignKey(nameof(IdProveedor))]
        [InverseProperty(nameof(Proveedor.Producto))]
        public virtual Proveedor _Proveedor { get; set; }

        [InverseProperty("_Producto")]
        public virtual Inventario Inventario { get; set; }

        [InverseProperty("_Producto")]
        public virtual ICollection<DetalleCompras> DetalleCompras { get; set; }
        
        [InverseProperty("_Producto")]
        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; }
    }
}
