using System;
using System.Collections.Generic;

namespace DL;

public partial class Doctor
{
    public int IdDoctor { get; set; }

    public string? Nombre { get; set; }

    public string? Especialidad { get; set; }

    public virtual ICollection<Citum> Cita { get; set; } = new List<Citum>();
}
