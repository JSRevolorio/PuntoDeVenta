using System;
using System.Collections.Generic;

namespace SPV.Models
{
    public partial class Genero
    {
        public Genero()
        {
            Empleado = new HashSet<Empleado>();
        }

        public int Id { get; set; }
        public string Sexo { get; set; }

        public virtual ICollection<Empleado> Empleado { get; set; }
    }
}
