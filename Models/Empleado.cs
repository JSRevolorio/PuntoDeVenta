using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPV.Models
{
    public partial class Empleado
    {
        public Empleado()
        {
            Compra = new HashSet<Compra>();
            RolEmpleado = new HashSet<RolEmpleado>();
            Venta = new HashSet<Venta>();
        }

        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }

        [Required]
        [Column("nombre", TypeName = "varchar(50)")]
        public string Nombre { get; set; }

        [Required]
        [Column("apellido", TypeName = "varchar(50)")]
        public string Apellido { get; set; }

        [Column("idGenero", TypeName = "int(11)")]
        public int IdGenero { get; set; }

        [Required]
        [Column("correoElectronico", TypeName = "varchar(50)")]
        public string CorreoElectronico { get; set; }

        [Column("noTelefono", TypeName = "varchar(10)")]
        public string NoTelefono { get; set; }

        [Required]
        [Column("noCelular", TypeName = "varchar(10)")]
        public string NoCelular { get; set; }

        [Required]
        [Column("direccion", TypeName = "varchar(150)")]
        public string Direccion { get; set; }

        [Required]
        [Column("noDPI", TypeName = "varchar(13)")]
        public string NoDpi { get; set; }

        [Required]
        [Column("noNit", TypeName = "varchar(10)")]
        public string NoNit { get; set; }

        [Column("fechaDeNacimiento", TypeName = "date")]
        public DateTime FechaDeNacimiento { get; set; }

        [Column("fechaIngreso", TypeName = "date")]
        public DateTime FechaIngreso { get; set; }

        [Column("estado", TypeName = "int(11)")]
        public int? Estado { get; set; }

        [ForeignKey(nameof(IdGenero))]
        [InverseProperty(nameof(Genero.Empleado))]
        public virtual Genero _Genero { get; set; }

        [InverseProperty("_Empleado")]
        public virtual Usuario Usuario { get; set; }

        [InverseProperty("_Empleado")]
        public virtual ICollection<Compra> Compra { get; set; }

        [InverseProperty("_Empleado")]
        public virtual ICollection<RolEmpleado> RolEmpleado { get; set; }

        [InverseProperty("_Empleado")]
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
