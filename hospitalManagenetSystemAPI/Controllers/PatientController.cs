using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using hospitalManagementSystemAPI.Models;
using hospitalManagenetSystemAPI.Data;
using hospitalManagenetSystemAPI.Models;
using hospitalManagenetSystemAPI.NewFolder;
using Microsoft.AspNetCore.Mvc;

namespace hospitalManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PatientsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddPatient([FromBody] PatientDto patientDto, [FromQuery] string gender, [FromQuery] string bloodtype)
        {
            try
            {
                if (patientDto == null)
                {
                    return BadRequest("Invalid patient data.");
                }

                bool emailExists = _context.patients.Any(p => p.Email == patientDto.Email);
                bool phoneExists = _context.patients.Any(p => p.PhoneNumber == patientDto.PhoneNumber);

                if (emailExists)
                {
                    return BadRequest("Email already exists.");
                }

                if (phoneExists)
                {
                    return BadRequest("Phone number already exists.");
                }

                var genderEntity = _context.genders.FirstOrDefault(g => g.Name == gender);
                if (genderEntity == null)
                {
                    return BadRequest("Invalid gender name.");
                }

                var bloodTypeEntity = _context.bloodTypes.FirstOrDefault(bt => bt.bloodType == bloodtype);
                if (bloodTypeEntity == null)
                {
                    return BadRequest("Invalid blood type name.");
                }

                byte[] salt = GenerateSalt(16);
                string hashedPassword = HashPassword(patientDto.Password, salt);

                Patient newPatient = new Patient
                {
                    FirstName = patientDto.FirstName,
                    LastName = patientDto.LastName,
                    Address = patientDto.Address,
                    PhoneNumber = patientDto.PhoneNumber,
                    Email = patientDto.Email,
                    Password = hashedPassword,
                    BirthDate = patientDto.BirthDate,
                    Gender = genderEntity,
                    BloodType = bloodTypeEntity,
                    Salt = Convert.ToBase64String(salt)
                };

                _context.patients.Add(newPatient);
                _context.SaveChanges();

                var response = new
                {
                    Message = "Patient successfully added.",
                    PatientId = newPatient.PatientId,
                    Patient = new
                    {
                        newPatient.PatientId,
                        newPatient.FirstName,
                        newPatient.LastName,
                        newPatient.Address,
                        newPatient.PhoneNumber,
                        newPatient.Email,
                        BirthDate = newPatient.BirthDate.ToString("yyyy-MM-dd"),
                        GenderName = newPatient.Gender.Name,
                        BloodType = newPatient.BloodType.bloodType
                    }
                };

                return CreatedAtAction(nameof(AddPatient), new { id = newPatient.PatientId }, response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding the patient: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetPatientById(int id)
        {
            try
            {
                var patient = _context.patients
                    .Where(p => p.PatientId == id)
                    .Select(p => new
                    {
                        p.PatientId,
                        p.FirstName,
                        p.LastName,
                        p.Address,
                        p.PhoneNumber,
                        p.Email,
                        BirthDate = p.BirthDate.ToString("yyyy-MM-dd"),
                        GenderName = p.Gender.Name,
                        BloodType = p.BloodType.bloodType
                    })
                    .FirstOrDefault();

                if (patient == null)
                {
                    return NotFound($"Patient with ID {id} not found.");
                }

                return Ok(patient);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching patient details: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePatient(int id, [FromBody] PatientUpdateDto patientUpdateDto, [FromQuery] string? gender = null, [FromQuery] string? bloodtype = null)
        {
            try
            {
                var existingPatient = _context.patients.FirstOrDefault(p => p.PatientId == id);
                if (existingPatient == null)
                {
                    return NotFound($"Patient with ID {id} not found.");
                }

                if (!string.IsNullOrEmpty(gender))
                {
                    var genderEntity = _context.genders.FirstOrDefault(g => g.Name == gender);
                    if (genderEntity == null)
                    {
                        return BadRequest("Invalid gender name.");
                    }
                    existingPatient.Gender = genderEntity;
                }

                if (!string.IsNullOrEmpty(bloodtype))
                {
                    var bloodTypeEntity = _context.bloodTypes.FirstOrDefault(bt => bt.bloodType == bloodtype);
                    if (bloodTypeEntity == null)
                    {
                        return BadRequest("Invalid blood type name.");
                    }
                    existingPatient.BloodType = bloodTypeEntity;
                }

                if (!string.IsNullOrEmpty(patientUpdateDto.FirstName))
                {
                    existingPatient.FirstName = patientUpdateDto.FirstName;
                }
                if (!string.IsNullOrEmpty(patientUpdateDto.LastName))
                {
                    existingPatient.LastName = patientUpdateDto.LastName;
                }
                if (!string.IsNullOrEmpty(patientUpdateDto.Address))
                {
                    existingPatient.Address = patientUpdateDto.Address;
                }
                if (!string.IsNullOrEmpty(patientUpdateDto.PhoneNumber))
                {
                    var phoneExists = _context.patients.Any(p => p.PhoneNumber == patientUpdateDto.PhoneNumber && p.PatientId != id);
                    if (phoneExists)
                    {
                        return BadRequest("Phone number already exists.");
                    }
                    existingPatient.PhoneNumber = patientUpdateDto.PhoneNumber;
                }
                if (!string.IsNullOrEmpty(patientUpdateDto.Email))
                {
                    var emailExists = _context.patients.Any(p => p.Email == patientUpdateDto.Email && p.PatientId != id);
                    if (emailExists)
                    {
                        return BadRequest("Email already exists.");
                    }
                    existingPatient.Email = patientUpdateDto.Email;
                }

                if (patientUpdateDto.BirthDate.HasValue)
                {
                    var birthDate = patientUpdateDto.BirthDate.Value;
                    existingPatient.BirthDate = new DateOnly(birthDate.Year, birthDate.Month, birthDate.Day);
                }

                _context.SaveChanges();

                var response = new
                {
                    message = "Patient updated successfully."
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the patient: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            try
            {
                var existingPatient = _context.patients.FirstOrDefault(p => p.PatientId == id);
                if (existingPatient == null)
                {
                    return NotFound($"Patient with ID {id} not found.");
                }

                _context.patients.Remove(existingPatient);
                _context.SaveChanges();

                var response = new
                {
                    message = "Patient deleted successfully."
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting the patient: {ex.Message}");
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
    }
}
