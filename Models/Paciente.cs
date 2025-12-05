using System;
using System.Collections.Generic;

namespace CRUDPacientes.Models;

public partial class Paciente
{
    public int Id { get; set; }

    public string? Nombres { get; set; }

    public string? Apellidos { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public string? Email { get; set; }

    public string? TelefonoCelular { get; set; }
}
