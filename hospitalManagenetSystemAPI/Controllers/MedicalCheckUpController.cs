using hospitalManagenetSystemAPI.Data;
using hospitalManagenetSystemAPI.DTO;
using hospitalManagenetSystemAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using hospitalManagementSystemAPI.Models;

namespace hospitalManagenetSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalCheckUpController : ControllerBase
    {
        private readonly AppDbContext _context;
        public MedicalCheckUpController(AppDbContext context)
        {
            this._context = context;
        }

        // GET: api/MedicalCheckUp
        [HttpGet]
        public IActionResult GetMedicalCheckUps()
        {
            return Ok(this._context.medicalCheckUps.ToList());
        }

        // GET: api/MedicalCheckUp/5
        [HttpGet("{id}")]
        public IActionResult GetMedicalCheckUp(int id)
        {
            var medicalCheckUp = _context.medicalCheckUps.Find(id);

            if (medicalCheckUp == null)
            {
                return NotFound();
            } else
            {
                return (IActionResult)medicalCheckUp;
            }
        }

        // POST: api/MedicalCheckUp
        [HttpPost]
        public IActionResult PostMedicalCheckUp(MedicalCheckUpRequest medicalCheckUp)
        {
            if(medicalCheckUp == null)
            {
                BadRequest("data medical checkup is null");
            }
            try
            {
                MedicalCheckUp data = new MedicalCheckUp()
                {
                    date = medicalCheckUp.date,
                    NoteMedicalChekup = medicalCheckUp.NoteMedicalChekup,
                    Result = medicalCheckUp.Result,
                    Doctor = medicalCheckUp.Doctor,
                    Patient = medicalCheckUp.Patient,
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
        public IActionResult PutMedicalCheckUp(int id, MedicalCheckUp medicalCheckUp)
        {
            if (id != medicalCheckUp.MedicalChekUpId)
            {
                return BadRequest();
            }

            _context.Entry(medicalCheckUp).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
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
