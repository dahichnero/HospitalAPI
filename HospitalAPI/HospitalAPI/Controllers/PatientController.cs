using Azure.Core;
using HospitalAPI.DataTransfer;
using HospitalAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Metadata.Ecma335;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly MedPatientContext _context;

        public PatientController(MedPatientContext context)
        {
            _context = context;
        }

        [HttpGet("listof/")]
        public IActionResult GetPatients(string? sort, int? page)
        {
            IQueryable<ListPatientDTO> patients = _context.Patients.Include(p => p.GenderNavigation).Include(p => p.SectorNavigation).Select(
                u => new ListPatientDTO 
                {
                    PatientId = u.PatientId,
                    PatientName=u.PatientName,
                    PatientLastName=u.PatientLastName,
                    PatientSurName=u.PatientSurName,
                    Address=u.Address,
                    Birth=u.Birth,
                    GenderName=u.GenderNavigation.GenderName,
                    SectorName=u.SectorNavigation.SectorNumber
                }).AsNoTracking().AsQueryable();
            switch (sort)
            {
                case "name":
                    patients = patients.OrderBy(z => z.PatientName);
                    break;

                case "lastname":
                    patients = patients.OrderBy(z => z.PatientLastName);
                    break;

                case "surname":
                    patients = patients.OrderBy(z => z.PatientSurName);
                    break;
                case "address":
                    patients = patients.OrderBy(z => z.Address);
                    break;
                case "birth":
                    patients = patients.OrderBy(z => z.Birth);
                    break;
                case "gender":
                    patients=patients.OrderBy(z => z.GenderName);
                    break;
                case "sector":
                    patients = patients.OrderBy(z => z.SectorName);
                    break;


            }
            int pageSize = 3;
            int pageNumber = page ?? 1;
            return Ok(patients.Skip((pageNumber-1)*pageSize).Take(pageSize));
        }

        [HttpGet("{id}")]
        public IActionResult GetPatientById(int id)
        {
            Patient patient= _context.Patients.FirstOrDefault(z => z.PatientId == id);
            if (patient == null)
            {
                return NotFound();
            }
            var result = new UpdatePatient
            {
                PatientName = patient.PatientName,
                PatientLastName = patient.PatientLastName,
                PatientSurName = patient.PatientSurName,
                Address = patient.Address,
                Birth = patient.Birth,
                Gender = patient.Gender,
                Sector = patient.Sector
            };
            return Ok(result);
        }

        [HttpPost("add patient")]
        public async Task<IActionResult> AddPatient(UpdatePatient patient)
        {
            if (!_context.Genders.Any(c => c.GenderId == patient.Gender))
            {
                return BadRequest("Invalid Gender");
            }
            if (!_context.Sectors.Any(c => c.SectorId == patient.Sector))
            {
                return BadRequest("Invalid Sector");
            }
            var newPatient = patient.ToPatient();
            _context.Patients.Add(newPatient);
            await _context.SaveChangesAsync();
            return Ok(patient);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdatePatient(UpdatePatient patient, int id)
        {
            if (!_context.Genders.Any(c => c.GenderId == patient.Gender))
            {
                return BadRequest("Invalid Gender");
            }
            if (!_context.Sectors.Any(c => c.SectorId == patient.Sector))
            {
                return BadRequest("Invalid Sector");
            }
            var changedPatient = _context.Patients.Find(id);
            if (changedPatient is null)
            {
                return BadRequest();
            }
            changedPatient.PatientName = patient.PatientName;
            changedPatient.PatientLastName=patient.PatientLastName;
            changedPatient.PatientSurName=patient.PatientSurName;
            changedPatient.Address=patient.Address;
            changedPatient.Birth=patient.Birth;
            changedPatient.Gender=patient.Gender;
            changedPatient.Sector=patient.Sector;
            await _context.SaveChangesAsync();
            return Ok(patient);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeletePatient(int id)
        {
            var patient = _context.Patients.Find(id);
            if (patient is null)
            {
                return BadRequest();
            }
            _context.Patients.Remove(patient);
            _context.SaveChanges();
            var result = new UpdatePatient
            {
                PatientName = patient.PatientName,
                PatientLastName = patient.PatientLastName,
                PatientSurName = patient.PatientSurName,
                Address = patient.Address,
                Birth = patient.Birth,
                Gender = patient.Gender,
                Sector = patient.Sector
            };
            return Ok(result);
        }

    }
}
