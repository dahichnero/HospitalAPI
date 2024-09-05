using System;
using System.Collections.Generic;

namespace HospitalAPI.Models;

public partial class Cabinet
{
    public int CabinetId { get; set; }

    public string CabinetNum { get; set; } = null!;

    public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
}
