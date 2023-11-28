using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Cita
    {
        public int IdCita { get; set; }
        public DateTime FechaCita { get; set; }
        public ML.Doctor doctor { get; set; }
        public string? Nombre { get; set; }
        public string? Especialidad { get; set; }
        public ML.Paciente Paciente { get; set; }
        public string? NombrePaciente { get; set; }
        public int EdadPaciente { get; set; }

        public List<object>? Citas { get; set; }
    }
}
