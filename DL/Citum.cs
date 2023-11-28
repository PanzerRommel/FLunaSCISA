using System;
using System.Collections.Generic;

namespace DL;

public partial class Citum
{
    public int IdCita { get; set; }

    public DateTime? FechaCita { get; set; }

    

    public int? IdDoctor { get; set; }

    public int? IdPaciente { get; set; }
    public string? NombreDoctor { get; set; }
    public string? Especialidad { get; set; }
    public string? NombrePaciente { get; set; }
    public string? EdadPaciente { get; set; }

    public virtual Doctor? IdDoctorNavigation { get; set; }

    public virtual Paciente? IdPacienteNavigation { get; set; }
}
