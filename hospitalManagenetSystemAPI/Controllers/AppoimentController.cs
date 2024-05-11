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
        public IActionResult AddAppoiment([FromBody] AppoinmentRequest appoinmentRequest, [FromQuery] int doctorId, [FromQuery] int roomId)
        {
            if(appoinmentRequest == null)
            {
                return BadRequest("not data found");
            }

            try
            {
                var doctor = _context.doctors.FirstOrDefault(d => d.DoctorId == doctorId);

                if(doctor == null)
                {
                    return NotFound();
                }

                var room = _context.rooms.FirstOrDefault(r => r.RoomId == roomId);
                if(room == null)
                {
                    return NotFound();
                }
                Appoiment data = new Appoiment()
                {
                    TimeStart = appoinmentRequest.TimeStart,
                    TimeEnd = appoinmentRequest.TimeEnd,
                    Status = appoinmentRequest.Status,
                    IsCompleted = appoinmentRequest.IsComplete,
                    Sapacity = appoinmentRequest.Sapacity,

                    Room = room,
                    Doctor = doctor,
                };
                _context.Appoiments.Add(data);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetAppoiment), new { id = appoinmentRequest.AppoimentId }, appoinmentRequest);

            } catch(Exception ex) { 
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult EditAppointment(int id, [FromBody] AppoinmentEdit appointmentEdit, [FromQuery] int doctorID, [FromQuery] int roomID)
        {
            var appointment = _context.Appoiments.Find(id);

            if (appointment == null)
            {
                return NotFound();
            }
            
            var doctor = _context.doctors.FirstOrDefault(d => d.DoctorId == doctorID);
            if (doctor == null)
            {
                return NotFound();
            }

            var room = _context.rooms.FirstOrDefault(r => r.RoomId ==  roomID);
            if(room == null)
            {
                return NotFound();
            }

            

            appointment.TimeStart = appointmentEdit.TimeStart;
            appointment.TimeEnd = appointmentEdit.TimeEnd;
            appointment.Status = appointmentEdit.Status;
            appointment.IsCompleted = appointmentEdit.IsCompleted;
            appointment.Sapacity = appointmentEdit.Sapacity;
            appointment.Room = room;
            appointment.Doctor = doctor;

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
