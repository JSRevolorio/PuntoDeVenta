using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPV.Models
{
    public partial class Usuario
    {
        [Key]
        [Column("idEmpleado", TypeName = "int(11)")]
        public int IdEmpleado { get; set; }

        [Required]
        [Column("nombre", TypeName = "varchar(30)")]
        public string Nombre { get; set; }

        [Required]
        [Column("clave", TypeName = "varchar(50)")]
        public string Clave { get; set; }

        [Required]
        [Column("sal", TypeName = "varchar(30)")]
        public string Sal { get; set; }

        [Column("estado", TypeName = "int(11)")]
        public int? Estado { get; set; }

        [ForeignKey(nameof(IdEmpleado))]
        [InverseProperty(nameof(Empleado.Usuario))]
        public virtual Empleado _Empleado { get; set; }
    }
}
