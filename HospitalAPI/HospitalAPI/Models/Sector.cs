using System;
using System.Collections.Generic;

namespace HospitalAPI.Models;

public partial class Sector
{
    public int SectorId { get; set; }

    public int SectorNumber { get; set; }

    public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
}
