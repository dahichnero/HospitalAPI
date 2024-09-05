using HospitalAPI.Models;

namespace HospitalAPI.DataTransfer
{
    public class UpdatePatient
    {

        public string PatientLastName { get; set; } = null!;

        public string PatientName { get; set; } = null!;

        public string PatientSurName { get; set; } = null!;

        public string Address { get; set; } = null!;

        public DateOnly Birth { get; set; }

        public int Gender { get; set; }

        public int Sector { get; set; }

        public Patient ToPatient()
        {
            return new Patient
            {
                PatientName = PatientName,
                PatientSurName = PatientSurName,
                PatientLastName = PatientLastName,
                Address = Address,
                Birth = Birth,
                Gender = Gender,
                Sector = Sector,
            };
        }
    }
}
