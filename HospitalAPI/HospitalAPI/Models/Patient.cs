using System;
using System.Collections.Generic;

namespace HospitalAPI.Models;

public partial class Patient
{
    public int PatientId { get; set; }

    public string PatientLastName { get; set; } = null!;

    public string PatientName { get; set; } = null!;

    public string PatientSurName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public DateOnly Birth { get; set; }

    public int Gender { get; set; }

    public int Sector { get; set; }

    public virtual Gender GenderNavigation { get; set; } = null!;

    public virtual Sector SectorNavigation { get; set; } = null!;
}
