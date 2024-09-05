using System;
using System.Collections.Generic;

namespace HospitalAPI.Models;

public partial class Doctor
{
    public int DoctorId { get; set; }

    public string DoctorLastName { get; set; } = null!;

    public string DoctorName { get; set; } = null!;

    public string DoctorSurname { get; set; } = null!;

    public int Cabinet { get; set; }

    public int Specialization { get; set; }

    public int? Sector { get; set; }

    public virtual Cabinet CabinetNavigation { get; set; } = null!;

    public virtual Sector? SectorNavigation { get; set; }

    public virtual Specialization SpecializationNavigation { get; set; } = null!;
}
