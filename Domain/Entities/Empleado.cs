using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Empleado
    {
        [Key]
        public int PkEmpleado { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }

        [ForeignKey("puesto")]
        public int? FkPuesto { get; set; }
        [ForeignKey("departamento")]
        public int? FkDepartamento { get; set; }
        public Puesto puesto { get; set; }
        public Departamento departamento { get; set; }
    }
}
