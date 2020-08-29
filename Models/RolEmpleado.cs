using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPV.Models
{
    public partial class RolEmpleado
    {
        [Key]
        [Column("idRol", TypeName = "int(11)")]
        public int IdRol { get; set; }

        [Key]
        [Column("idEmpleado", TypeName = "int(11)")]
        public int IdEmpleado { get; set; }

        [ForeignKey(nameof(IdEmpleado))]
        [InverseProperty(nameof(Empleado.RolEmpleado))]
        public virtual Empleado _Empleado { get; set; }

        [ForeignKey(nameof(IdRol))]
        [InverseProperty(nameof(Rol.RolEmpleado))]
        public virtual Rol _Rol { get; set; }
    }
}
