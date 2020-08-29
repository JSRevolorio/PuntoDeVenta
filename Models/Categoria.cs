using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPV.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Producto = new HashSet<Producto>();
        }

        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        
        [Required]
        [Column("nombre", TypeName = "varchar(50)")]
        public string Nombre { get; set; }

        [InverseProperty("_Categoria")]
        public virtual ICollection<Producto> Producto { get; set; }
    }
}
