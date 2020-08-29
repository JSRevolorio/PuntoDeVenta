using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPV.Models
{
    public partial class Genero
    {
        public Genero()
        {
            Empleado = new HashSet<Empleado>();
        }

        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        
        [Column("sexo", TypeName = "enum('Masculino','Femenimo')")]
        public string Sexo { get; set; }

        [InverseProperty("_Genero")]
        public virtual ICollection<Empleado> Empleado { get; set; }
    }
}
