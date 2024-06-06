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
        private object appoimentRequest;

        public AppoimentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAppoiment()
        {
            try
            {
                var data = _context.Appoiments.Select(a => new
                {
                    a.AppoimentId,
                    a.TimeStart,
                    a.TimeEnd,
                    a.Status,
                    a.IsCompleted,
                    a.Sapacity,
                    Room = a.Room.RoomNumber,
                    Doctor = a.Doctor.firstName
                }).ToList();
                return Ok(data);
            } catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetAppoinmentById(int id)
        {
            try
            {
                var data = _context.Appoiments.Where(a => a.AppoimentId == id).Select(a => new
                {
                    a.AppoimentId,
                    a.TimeStart,
                    a.TimeEnd,
                    a.Status,
                    a.IsCompleted,
                    a.Sapacity,
                    Room = a.Room.RoomNumber,
                    Doctor = a.Doctor.firstName
                }).FirstOrDefault();
                if (data == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(data);
                }
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
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
                    IsCompleted = appoinmentRequest.IsComplete,
                    Sapacity = appoinmentRequest.Sapacity,
                    Date = appoinmentRequest.date,
                    Room = room,
                    Doctor = doctor,
                    Status = appoinmentRequest.Status
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
            try
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

                var room = _context.rooms.FirstOrDefault(r => r.RoomId == roomID);
                if (room == null)
                {
                    return NotFound();
                }



                appointment.TimeStart = appointmentEdit.TimeStart;
                appointment.TimeEnd = appointmentEdit.TimeEnd;
                appointment.IsCompleted = appointmentEdit.IsCompleted;
                appointment.Sapacity = appointmentEdit.Sapacity;
                appointment.Room = room;
                appointment.Doctor = doctor;
                appointment.Status = appointmentEdit.Status;

                _context.Entry(appointment).State = EntityState.Modified;
                _context.SaveChanges();

                return NoContent();
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAppointment(int id)
        {
            try
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

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }


    }


}
