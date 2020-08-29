using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPV.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Venta = new HashSet<Venta>();
        }

        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }

        [Required]
        [Column("nombre", TypeName = "varchar(50)")]
        public string Nombre { get; set; }

        [Required]
        [Column("noNit", TypeName = "varchar(10)")]
        public string NoNit { get; set; }

        [Required]
        [Column("noTelefono", TypeName = "varchar(10)")]
        public string NoTelefono { get; set; }

        [Required]
        [Column("correoElectronico", TypeName = "varchar(50)")]
        public string CorreoElectronico { get; set; }

        [Required]
        [Column("direccion", TypeName = "varchar(150)")]
        public string Direccion { get; set; }

        [Column("estado", TypeName = "int(11)")]
        public int? Estado { get; set; }

        [InverseProperty("_Cliente")]
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
