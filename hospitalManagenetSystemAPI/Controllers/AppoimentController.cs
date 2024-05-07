using hospitalManagenetSystemAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using hospitalManagenetSystemAPI.DTO;
using hospitalManagenetSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace hospitalManagenetSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppoimentController : ControllerBase
    {
        private readonly AppDbContext _context;
        
        public AppoimentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAppoiment()
        {
            return Ok(_context.Appoiments.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetAppoinmentById(int id)
        {
            var data = _context.Appoiments.Find(id);
            if(data == null)
            {
                return NotFound();
            } else
            {
                return Ok(data);
            }

        }

        [HttpPost]
        public IActionResult AddAppoiment(AppoinmentRequest appoinmentRequest)
        {
            if(appoinmentRequest == null)
            {
                return BadRequest("not data found");
            }

            try
            {
                Appoiment data = new Appoiment()
                {
                    TimeStart = appoinmentRequest.TimeStart,
                    TimeEnd = appoinmentRequest.TimeEnd,
                    Status = appoinmentRequest.Status,
                    IsCompleted = appoinmentRequest.IsCompleted,
                    Sapacity = appoinmentRequest.Sapacity,

                    Room = appoinmentRequest.Room,
                    Patients = appoinmentRequest.Patients,
                    Doctor = appoinmentRequest.Doctor,
                };
                _context.Appoiments.Add(data);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetAppoiment), new { id = appoinmentRequest.AppoimentId }, appoinmentRequest);

            } catch(Exception ex) { 
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult EditAppointment(int id, AppoinmentEdit appointmentEdit)
        {
            var appointment = _context.Appoiments.Find(id);

            if (appointment == null)
            {
                return NotFound();
            }

            appointment.TimeStart = appointmentEdit.TimeStart;
            appointment.TimeEnd = appointmentEdit.TimeEnd;
            appointment.Status = appointmentEdit.Status;
            appointment.IsCompleted = appointmentEdit.IsCompleted;
            appointment.Sapacity = appointmentEdit.Sapacity;
            appointment.Room = appointmentEdit.Room;
            appointment.Patients = appointmentEdit.Patients;
            appointment.Doctor = appointmentEdit.Doctor;

            _context.Entry(appointment).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAppointment(int id)
        {
            var appointment = _context.Appoiments.Find(id);

            if (appointment == null)
            {
                return NotFound();
            }

            _context.Appoiments.Remove(appointment);
            _context.SaveChanges();

            return NoContent();
        }


    }


}
