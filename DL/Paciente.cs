using System;
using System.Collections.Generic;

namespace DL;

public partial class Paciente
{
    public int IdPaciente { get; set; }

    public string Nombre { get; set; } = null!;

    public int? Edad { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public string? Telefono { get; set; }

    public virtual ICollection<Citum> Cita { get; set; } = new List<Citum>();
}
