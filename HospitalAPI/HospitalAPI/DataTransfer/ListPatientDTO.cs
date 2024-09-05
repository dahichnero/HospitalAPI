using HospitalAPI.Models;

namespace HospitalAPI.DataTransfer
{
    public class ListPatientDTO
    {
        public int PatientId { get; set; }

        public string PatientLastName { get; set; } = null!;

        public string PatientName { get; set; } = null!;

        public string PatientSurName { get; set; } = null!;

        public string Address { get; set; } = null!;

        public DateOnly Birth { get; set; }

        public string GenderName { get; set; } = null!;

        public int SectorName { get; set; }
    }
}
