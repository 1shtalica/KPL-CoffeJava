using hospitalManagementSystemAPI.Models;
using hospitalManagenetSystemAPI.NewFolder;
using hospitalManagenetSystemAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using hospitalManagenetSystemAPI.Models;

namespace hospitalManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {

        private readonly AppDbContext _context;

        // Constructor untuk menyuntikkan konteks database
        public PatientsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddPatient([FromBody] PatientDto patientDto, [FromQuery] string gender, [FromQuery] string bloodtype)
        {
            // Validasi input DTO
            if (patientDto == null)
            {
                return BadRequest("Invalid patient data.");
            }

            try
            {
                // Pemeriksaan apakah email atau nomor telepon sudah ada
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

          
                Gender genderEntity = _context.genders.FirstOrDefault(g => g.Name == gender);
                if (genderEntity == null)
                {
                    return BadRequest("Invalid gender name.");
                }

   
                BloodType bloodTypeEntity = _context.bloodTypes.FirstOrDefault(bt => bt.bloodType == bloodtype);
                if (bloodTypeEntity == null)
                {
                    return BadRequest("Invalid blood type name.");
                }

               
                Patient newPatient = new Patient
                {
                    FirstName = patientDto.FirstName,
                    LastName = patientDto.LastName,
                    Address = patientDto.Address,
                    PhoneNumber = patientDto.PhoneNumber,
                    Email = patientDto.Email,
                    Password = patientDto.Password,
                    BirthDate = patientDto.BirthDate,
                    Gender = genderEntity,
                    BloodType = bloodTypeEntity
                };

                // Tambahkan pasien baru ke database
                _context.patients.Add(newPatient);
                _context.SaveChanges();

                // Mengembalikan respons Created dengan informasi pasien baru
                var response = new
                {
                    Message = "Patient successfully added.",
                    PatientId = newPatient.PatientId,
                    Patient = newPatient
                };

                return CreatedAtAction(nameof(AddPatient), new { id = newPatient.PatientId }, response);
            }
            catch (Exception ex)
            {
                // Tangani kesalahan yang tidak terduga
                // Sebaiknya log kesalahan menggunakan mekanisme logging yang disediakan oleh framework .NET
                return StatusCode(500, $"An error occurred while adding the patient: {ex.Message}");
            }
        }
    }
}
