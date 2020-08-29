using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPV.Models
{
    public partial class Rol
    {
        public Rol()
        {
            RolEmpleado = new HashSet<RolEmpleado>();
        }

        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }

        [Required]
        [Column("nombre", TypeName = "varchar(30)")]
        public string Nombre { get; set; }

        [InverseProperty("_Rol")]
        public virtual ICollection<RolEmpleado> RolEmpleado { get; set; }
    }
}
