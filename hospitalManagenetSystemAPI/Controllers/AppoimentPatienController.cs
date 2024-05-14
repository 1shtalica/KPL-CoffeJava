using hospitalManagenetSystemAPI.Data;
using hospitalManagenetSystemAPI.DTO;
using hospitalManagenetSystemAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace hospitalManagenetSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppoimentPatienController : ControllerBase
    {
        private readonly AppDbContext _context;
        public AppoimentPatienController(AppDbContext context)
        {
            _context = context;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult GetAppoimentPatient()
        {
            try
            {
                var data = _context.AppoimentPatients.Select(p => new
                {
                    p.AppoimentId,
                    Appoiment = p.Appoiment.TimeStart + " " + p.Appoiment.TimeEnd,
                    p.PatientId,
                    Patient = p.Patient.FirstName
                }).ToList();
                return Ok(data);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IActionResult GetAppoimentPatientById(int id)
        {
            try
            {
                var data = _context.AppoimentPatients.Where(p => p.AppoimentId == id).Select(p => new
                {
                    p.AppoimentId,
                    Appoiment = p.Appoiment.TimeStart + " " + p.Appoiment.TimeEnd,
                    p.PatientId,
                    Patient = p.Patient.FirstName
                }).FirstOrDefault();
                if(data == null)
                {
                    return NotFound();
                } else
                {
                    return Ok(data);
                }

            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult StoreAppoimentPatient([FromQuery] int appoiment, [FromQuery] int patient)
        {
            try
            {
                var appoimentData = _context.Appoiments.FirstOrDefault(a => a.AppoimentId == appoiment);
                if (appoimentData == null)
                {
                    return NotFound();
                }

                var patientData = _context.patients.FirstOrDefault(p => p.PatientId == patient);
                if (patientData == null)
                {
                    return NotFound();
                }

                AppoimentPatient data = new AppoimentPatient
                {
                    Patient = patientData,
                    Appoiment = appoimentData,
                };

                _context.AppoimentPatients.Add(data);
                _context.SaveChanges();

                return CreatedAtAction(nameof(GetAppoimentPatient), new {id = data.AppoimentId}, data);
            } catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }
       

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateAppoimentPatient(int id, [FromQuery] int appoiment, [FromQuery] int patient)
        {
            var data = _context.AppoimentPatients.Find(id);
            if (data == null)
            {
                return BadRequest("data not found");
            }
            try
            {
                var appoimentData = _context.Appoiments.FirstOrDefault(a => a.AppoimentId == appoiment);
                if (appoimentData == null)
                {
                    return NotFound();
                }

                var patientData = _context.patients.FirstOrDefault(p => p.PatientId == patient);
                if (patientData == null)
                {
                    return NotFound();
                }
                data.Appoiment = appoimentData;
                data.Patient = patientData;

                _context.Entry(data).State = EntityState.Modified;
                _context.SaveChanges();

                return NoContent();
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
                
            
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = _context.AppoimentPatients.Where(a => a.AppoimentId == id).FirstOrDefault();
            try
            {
                if (data == null)
                {
                    return BadRequest("data not found");
                }

                _context.AppoimentPatients.Remove(data);
                _context.SaveChanges();
                return NoContent();
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            


        }
    }
}
