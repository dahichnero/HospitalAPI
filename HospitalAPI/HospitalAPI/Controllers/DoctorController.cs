using HospitalAPI.DataTransfer;
using HospitalAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly MedPatientContext _context;

        public DoctorController(MedPatientContext context)
        {
            _context = context;
        }

        [HttpGet("listOf")]
        public IActionResult GetDoctors(string? sort, int? page)
        {
            IQueryable<ListDoctorDTO> doctors = _context.Doctors.Include(p => p.CabinetNavigation).Include(p=>p.SpecializationNavigation).Include(p => p.SectorNavigation).Select(
                u => new ListDoctorDTO
                {
                    DoctorId = u.DoctorId,
                    DoctorName = u.DoctorName,
                    DoctorLastName = u.DoctorLastName,
                    DoctorSurname = u.DoctorSurname,
                    CabinetNum = u.CabinetNavigation.CabinetNum,
                    SpecializationName = u.SpecializationNavigation.SpecializationName,
                    SectorNumber = u.SectorNavigation.SectorNumber
                }).AsNoTracking().AsQueryable();
            switch (sort)
            {
                case "name":
                    doctors = doctors.OrderBy(z => z.DoctorName);
                    break;

                case "lastname":
                    doctors = doctors.OrderBy(z => z.DoctorLastName);
                    break;

                case "surname":
                    doctors = doctors.OrderBy(z => z.DoctorSurname);
                    break;
                case "cabinet":
                    doctors = doctors.OrderBy(z => z.CabinetNum);
                    break;
                case "specialization":
                    doctors = doctors.OrderBy(z => z.SpecializationName);
                    break;
                case "sector":
                    doctors = doctors.OrderBy(z => z.SectorNumber);
                    break;


            }
            int pageSize = 3;
            int pageNumber = page ?? 1;
            return Ok(doctors.Skip((pageNumber - 1) * pageSize).Take(pageSize));
        }

        [HttpGet("{id}")]
        public IActionResult GetDoctorById(int id)
        {
            Doctor doctor=_context.Doctors.FirstOrDefault(z=>z.DoctorId==id);
            if (doctor==null)
            {
                return NotFound();
            }
            var result = new UpdateDoctor
            {
                DoctorName=doctor.DoctorName,
                DoctorLastName=doctor.DoctorLastName,
                DoctorSurname = doctor.DoctorSurname,
                Cabinet = doctor.Cabinet,
                Specialization = doctor.Specialization,
                Sector=doctor.Sector
            };
            return Ok(result);
        }

        [HttpPost("addDoctor")]
        public async Task<IActionResult> AddDoctor(UpdateDoctor doctor)
        {
            if (!_context.Cabinets.Any(c => c.CabinetId == doctor.Cabinet))
            {
                return BadRequest("Invalid Cabinet");
            }
            if (!_context.Specializations.Any(c => c.SpecializationId == doctor.Specialization))
            {
                return BadRequest("Invalid Specialization");
            }
            if (!_context.Sectors.Any(c => c.SectorId == doctor.Sector))
            {
                return BadRequest("Invalid Sector");
            }
            var newDoctor=doctor.ToDoctor();
            _context.Doctors.Add(newDoctor);
            await _context.SaveChangesAsync();
            return Ok(doctor);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateDoctor(UpdateDoctor updateDoctor, int id)
        {
            if (!_context.Cabinets.Any(c=>c.CabinetId==updateDoctor.Cabinet))
            {
                return BadRequest("Invalid Cabinet");
            }
            if (!_context.Specializations.Any(c => c.SpecializationId == updateDoctor.Specialization))
            {
                return BadRequest("Invalid Specialization");
            }
            if (!_context.Sectors.Any(c => c.SectorId == updateDoctor.Sector))
            {
                return BadRequest("Invalid Sector");
            }
            var changedDoctor=_context.Doctors.Find(id);
            if (changedDoctor is null)
            {
                return BadRequest();
            }
            changedDoctor.DoctorName = updateDoctor.DoctorName;
            changedDoctor.DoctorLastName = updateDoctor.DoctorLastName;
            changedDoctor.DoctorSurname=updateDoctor.DoctorSurname;
            changedDoctor.Specialization=updateDoctor.Specialization;
            changedDoctor.Cabinet=updateDoctor.Cabinet;
            changedDoctor.Sector=updateDoctor.Sector;
            await _context.SaveChangesAsync();
            return Ok(updateDoctor);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            var doctor = _context.Doctors.Find(id);
            if (doctor is  null)
            {
                return BadRequest();
            }
            _context.Doctors.Remove(doctor);
            _context.SaveChanges();
            var result = new UpdateDoctor
            {
                DoctorName = doctor.DoctorName,
                DoctorLastName = doctor.DoctorLastName,
                DoctorSurname = doctor.DoctorSurname,
                Cabinet = doctor.Cabinet,
                Specialization = doctor.Specialization,
                Sector = doctor.Sector
            };
            return Ok(result);
        }

    }
}
