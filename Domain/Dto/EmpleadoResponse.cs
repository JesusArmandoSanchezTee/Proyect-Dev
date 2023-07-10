using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class EmpleadoResponse
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string direccion { get; set; }
        public string ciudad { get; set; }
        public int? FkPuesto { get; set; }
        public int? FkDepartamento { get; set; }
    }
}
