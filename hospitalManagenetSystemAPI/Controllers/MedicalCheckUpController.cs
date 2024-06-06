using hospitalManagenetSystemAPI.Data;
using hospitalManagenetSystemAPI.DTO;
using hospitalManagenetSystemAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using hospitalManagementSystemAPI.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace hospitalManagenetSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalCheckUpController : ControllerBase
    {
        private readonly AppDbContext _context;
        public MedicalCheckUpController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/MedicalCheckUp
        [HttpGet]
        public IActionResult GetMedicalCheckUps()
        {
            var allMcu = _context.medicalCheckUps
                         .Select(m => new
                         {
                             m.MedicalChekUpId,
                             date = m.date.ToString("yyyy-MM-dd"),
                             m.NoteMedicalChekup,
                             m.Result,
                             Doctor = m.Doctor.firstName,
                             Patient = m.Patient.FirstName,
                             ApoimentId = m.Appoiment.AppoimentId

                         })
                         .ToList();
            MedicalCheckUp medicalCheckUp
                = new MedicalCheckUp();
            
            return Ok(allMcu);
        }

        // GET: api/MedicalCheckUp/5
        [HttpGet("{id}")]
        public IActionResult GetMedicalCheckUp(int id)
        {
            try
            {
                var medicalCheckUp = _context.medicalCheckUps.Where(m => m.MedicalChekUpId == id).Select(m => new
                {
                    m.MedicalChekUpId,
                    date = m.date.ToString("yyyy-MM-dd"),
                    m.NoteMedicalChekup,
                    m.Result,
                    Doctor = m.Doctor.firstName,
                    Patient = m.Patient.FirstName
                }).FirstOrDefault();

                if (medicalCheckUp == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(medicalCheckUp);
                }
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        // POST: api/MedicalCheckUp
        [HttpPost]
        public IActionResult PostMedicalCheckUp([FromQuery] int appoimentId,[FromBody] MedicalCheckUpRequest medicalCheckUp, [FromQuery] int patientID, [FromQuery] int doctorId)
        {
            if(medicalCheckUp == null)
            {
                BadRequest("data medical checkup is null");
            }
            try
            {
                var appoiment = _context.Appoiments.FirstOrDefault(a =>a.AppoimentId == appoimentId);
                var doctor = _context.doctors.FirstOrDefault(r => r.DoctorId == doctorId);
                if(appoiment == null)
                {
                    return NotFound();
                }
                if(doctor == null)
                {
                    return NotFound();
                }

                var patient = _context.patients.FirstOrDefault(p => p.PatientId == patientID);
                if(patient == null)
                {
                    return NotFound();
                }

                MedicalCheckUp data = new MedicalCheckUp()
                {
                    date = medicalCheckUp.date,
                    NoteMedicalChekup = medicalCheckUp.NoteMedicalChekup,
                    Result = medicalCheckUp.Result,
                    Doctor = doctor,
                    Patient = patient,
                    Appoiment = appoiment
                    
                };

                _context.medicalCheckUps.Add(data);
                _context.SaveChanges();

                return CreatedAtAction(nameof(GetMedicalCheckUp), new { id = medicalCheckUp.MedicalChekUpId }, medicalCheckUp);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        // PUT: api/MedicalCheckUp/5
        [HttpPut("{id}")]
        public IActionResult PutMedicalCheckUp(int id, [FromQuery] int appoimentId, [FromBody] MedicalCheckUpEdit medicalCheckUp, [FromQuery] int doctorID, [FromQuery] int patientID)
        {
            try
            {
                var data = _context.medicalCheckUps.Find(id);
                if (data == null)
                {
                    return NotFound();
                }

                var doctor = _context.doctors.FirstOrDefault(d => d.DoctorId == doctorID);
                if (doctor == null)
                {
                    return NotFound();
                }

                var patient = _context.patients.FirstOrDefault(p => p.PatientId == patientID);
                if (patient == null)
                {
                    return NotFound();
                }
                var appoiment  = _context.Appoiments.FirstOrDefault(p => p.AppoimentId == appoimentId);
                if (appoiment == null)
                {
                    return NotFound();
                }

                data.date = medicalCheckUp.date;
                data.Result = medicalCheckUp.Result;
                data.NoteMedicalChekup = medicalCheckUp.NoteMedicalChekup;
                data.Doctor = doctor;
                data.Patient = patient;
                data.Appoiment = appoiment;

                _context.Entry(medicalCheckUp).State = EntityState.Modified;
                _context.SaveChanges();

                return NoContent();
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // DELETE: api/MedicalCheckUp/5
        [HttpDelete("{id}")]
        public IActionResult DeleteMedicalCheckUp(int id)
        {
            var medicalCheckUp = _context.medicalCheckUps.Find(id);
            if (medicalCheckUp == null)
            {
                return NotFound();
            }

            _context.medicalCheckUps.Remove(medicalCheckUp);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
