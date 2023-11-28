using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Doctor
    {
        public int IdDoctor { get; set;}
        public string? Nombre { get; set; }
        public string? Especialidad { get; set; }
        public List<object>? Doctores { get; set; }
    }
}
