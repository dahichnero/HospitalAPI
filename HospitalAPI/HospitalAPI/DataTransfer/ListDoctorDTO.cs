using HospitalAPI.Models;

namespace HospitalAPI.DataTransfer
{
    public class ListDoctorDTO
    {
        public int DoctorId { get; set; }

        public string DoctorLastName { get; set; } = null!;

        public string DoctorName { get; set; } = null!;

        public string DoctorSurname { get; set; } = null!;

        public string CabinetNum { get; set; } = null!;

        public int? SectorNumber { get; set; }

        public string SpecializationName { get; set; } = null!;
    }
}
