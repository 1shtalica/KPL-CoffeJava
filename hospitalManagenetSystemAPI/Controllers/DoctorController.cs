using hospitalManagenetSystemAPI.Data;
using hospitalManagenetSystemAPI.DTO;
using hospitalManagenetSystemAPI.Models;
using hospitalManagenetSystemAPI.NewFolder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using Library;
using static hospitalManagenetSystemAPI.Runtime.DashboardConfigParse;

namespace hospitalManagenetSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DoctorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddDoctor([FromBody] DoctorDto doctorDto, [FromQuery] int specializationId)
        {
            try
            {
                if (doctorDto == null)
                {
                    return BadRequest("Invalid doctor data");
                }

                
                var specialization = _context.specializations.FirstOrDefault(s => s.SpecializationId == specializationId);
                if (specialization == null)
                {
                    return NotFound($"Specialization with ID {specializationId} not found.");
                }

                
                var existingDoctor = _context.doctors.FirstOrDefault(d => d.Email == doctorDto.Email);
                if (existingDoctor != null)
                {
                    return BadRequest("Doctor with this email already exists.");
                }

                byte[] salt = GenerateSalt(16);
                string hashedPassword = HashPassword(doctorDto.Password, salt);
                var doctor = new Doctor
                {
                    firstName = doctorDto.firstName,
                    lastName = doctorDto.lastName,
                    Address = doctorDto.Address,
                    BirthDate = doctorDto.BirthDate,
                    PhoneNumber = doctorDto.PhoneNumber,
                    Email = doctorDto.Email,
                     Password = hashedPassword,
                    Salt = Convert.ToBase64String(salt),
                    Specialization = specialization, 
                };

                
                _context.doctors.Add(doctor);
                _context.SaveChanges();

                return CreatedAtAction(nameof(AddDoctor), "doctor successfully add");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding the doctor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetDoctorById(int id)
        {
            try
            {
                var doctor = _context.doctors
                    .Include(d => d.Specialization)
                    .FirstOrDefault(d => d.DoctorId == id);

                if (doctor == null)
                {
                    return NotFound($"Doctor with ID {id} not found.");
                }
                var doctorDto = new 
                {
                    firstName = doctor.firstName,
                    lastName = doctor.lastName,
                    specialization = _context.specializations.FirstOrDefault(s => s.SpecializationId == doctor.Specialization.SpecializationId)?.Name,
                    Address = doctor.Address, 
                    BirthDate = doctor.BirthDate, PhoneNumber = doctor.PhoneNumber,
                    email = doctor.Email,
                };
                return Ok(doctorDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching doctor details: {ex.Message}");
            }
        }
        [HttpGet]
        public IActionResult GetAllDoctors()
        {
            try
            {
                var doctors = _context.doctors
                    .Include(d => d.Specialization)
                    .Select(d => new
                    {
                        Id = d.DoctorId,
                        FirstName = d.firstName,
                        LastName = d.lastName,
                        Specialization = d.Specialization != null ? d.Specialization.Name : "",
                        Address = d.Address,
                        BirthDate = d.BirthDate,
                        PhoneNumber = d.PhoneNumber,
                        Email = d.Email
                    })
                    .ToList();

                if (doctors == null || doctors.Count == 0)
                {
                    return NotFound("No doctors found.");
                }

                return Ok(doctors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching doctors: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDoctor(int id, [FromBody] DoctorUpdateDto doctorUpdateDto, [FromQuery] int? specializationId)
        {
            try
            {
                var existingDoctor = _context.doctors
                    .Include(d => d.Specialization)
                    .FirstOrDefault(d => d.DoctorId == id);

                if (existingDoctor == null)
                {
                    return NotFound($"Doctor with ID {id} not found.");
                }

                if (!string.IsNullOrEmpty(doctorUpdateDto.firstName))
                {
                    existingDoctor.firstName = doctorUpdateDto.firstName;
                }
                if (!string.IsNullOrEmpty(doctorUpdateDto.lastName))
                {
                    existingDoctor.lastName = doctorUpdateDto.lastName;
                }
                if (!string.IsNullOrEmpty(doctorUpdateDto.Address))
                {
                    existingDoctor.Address = doctorUpdateDto.Address;
                }
                if (doctorUpdateDto.BirthDate.HasValue)
                {
                    existingDoctor.BirthDate = doctorUpdateDto.BirthDate.Value;
                }
                if (!string.IsNullOrEmpty(doctorUpdateDto.PhoneNumber))
                {
                    existingDoctor.PhoneNumber = doctorUpdateDto.PhoneNumber;
                }
                if (!string.IsNullOrEmpty(doctorUpdateDto.Email))
                {
                    var emailExists = _context.doctors.Any(d => d.Email == doctorUpdateDto.Email && d.DoctorId != id);
                    if (emailExists)
                    {
                        return BadRequest("Email already exists.");
                    }
                    existingDoctor.Email = doctorUpdateDto.Email;
                }

                if (specializationId.HasValue)
                {
                    var specialization = _context.specializations.FirstOrDefault(s => s.SpecializationId == specializationId);
                    if (specialization == null)
                    {
                        return NotFound($"Specialization with ID {specializationId} not found.");
                    }
                    existingDoctor.Specialization = specialization;
                }

                _context.SaveChanges();

                var response = new
                {
                    message = "Doctor updated successfully."
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the doctor: {ex.Message}");
            }
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            try
            {
                var doctor = _context.doctors.FirstOrDefault(d => d.DoctorId == id);
                if (doctor == null)
                {
                    return NotFound($"Doctor with ID {id} not found.");
                }

                _context.doctors.Remove(doctor);
                _context.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting the doctor: {ex.Message}");
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Login login)
        {
            try
            {
                if (string.IsNullOrEmpty(login.Email) || string.IsNullOrEmpty(login.Email))
                {
                    return BadRequest("Invalid data: email or password is null or empty.");
                }

                // Pisahkan query untuk debugging
                var doctor = _context.doctors.Include(d => d.Specialization)
                    .FirstOrDefault(d => d.Email == login.Email);
                

                if (doctor == null)
                {
                    return NotFound("Doctor not found.");
                }

                // Debugging tambahan
                Console.WriteLine($"Doctor found: {doctor.firstName} {doctor.lastName}");
                Console.WriteLine(doctor.Specialization);

                if (ComparePassword(login.Password, doctor.Password, doctor.Salt))
                {
                    
                    
                    var doctorDto = new
                    {
                        firstName = doctor.firstName,
                        lastName = doctor.lastName,
                        specialization = doctor.Specialization,
                        Address = doctor.Address,
                        BirthDate = doctor.BirthDate,
                        PhoneNumber = doctor.PhoneNumber,
                        email = doctor.Email,
                    };
                    Console.WriteLine(doctorDto.email);
                    return Ok(doctorDto);
                }
                else
                {
                    return BadRequest("Invalid credentials.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception message with inner exception details
                Console.WriteLine($"Exception: {ex.Message}, Inner Exception: {ex.InnerException?.Message}");
                return StatusCode(500, $"An error occurred while logging in: {ex.Message}");
            }
        }




        private byte[] GenerateSalt(int size)
        {
            byte[] salt = new byte[size];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        private string HashPassword(string password, byte[] salt)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000))
            {
                byte[] hash = pbkdf2.GetBytes(20);
                return Convert.ToBase64String(hash);
            }
        }
        private bool ComparePassword(string inputPassword, string hashedPassword, string saltBase64)
        {
            byte[] salt = Convert.FromBase64String(saltBase64);
            string hashedInputPassword = HashPassword(inputPassword, salt);
            return hashedPassword == hashedInputPassword;


        }

    }
}
