using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPV.Models
{
    public partial class Factura
    {
        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }

        [Required]
        [Column("serie", TypeName = "varchar(5)")]
        public string Serie { get; set; }

        [Required]
        [Column("numero", TypeName = "varchar(10)")]
        public string Numero { get; set; }

        [Column("fecha", TypeName = "date")]
        public DateTime Fecha { get; set; }

        [Column("estado", TypeName = "int(11)")]
        public int? Estado { get; set; }

        [InverseProperty("_Factura")]
        public virtual Venta Venta { get; set; }
    }
}
