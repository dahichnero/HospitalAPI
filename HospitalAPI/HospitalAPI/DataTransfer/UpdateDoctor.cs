using HospitalAPI.Models;
using System.Net;

namespace HospitalAPI.DataTransfer
{
    public class UpdateDoctor
    {

        public string DoctorLastName { get; set; } = null!;

        public string DoctorName { get; set; } = null!;

        public string DoctorSurname { get; set; } = null!;

        public int Cabinet { get; set; }

        public int Specialization { get; set; }

        public int? Sector { get; set; }

        public Doctor ToDoctor()
        {
            return new Doctor
            {
                DoctorName=DoctorName,
                DoctorLastName=DoctorLastName,
                DoctorSurname=DoctorSurname,
                Cabinet = Cabinet,
                Specialization=Specialization,
                Sector=Sector,
            };
        }
    }
}
