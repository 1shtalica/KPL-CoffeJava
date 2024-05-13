using hospitalManagementSystemAPI.Models;
using hospitalManagenetSystemAPI.Data;
using hospitalManagenetSystemAPI.Models;
using hospitalManagenetSystemAPI.NewFolder;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

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

        // Metode POST untuk menambahkan pasien baru
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

                // Periksa gender dan blood type
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

                // Hash the password
                byte[] salt = GenerateSalt(16); // Membuat garam 16 byte
                string hashedPassword = HashPassword(patientDto.Password, salt);

                // Buat objek pasien baru dengan password yang sudah di-hash
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
                    Salt = Convert.ToBase64String(salt) // Simpan garam dalam format base64
                };

                // Tambahkan pasien baru ke database
                _context.patients.Add(newPatient);
                _context.SaveChanges();

                // Mengembalikan respons Created dengan informasi pasien baru
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
                // Tangani kesalahan yang tidak terduga
                return StatusCode(500, $"An error occurred while adding the patient: {ex.Message}");
            }
        }

        // Metode GET untuk mendapatkan informasi pasien berdasarkan PatientId
        [HttpGet("{id}")]
        public IActionResult GetPatientById(int id)
        {
            // Cari pasien berdasarkan PatientId
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

            // Jika pasien tidak ditemukan, kembalikan respon NotFound
            if (patient == null)
            {
                return NotFound($"Patient with ID {id} not found.");
            }

            // Mengembalikan informasi pasien dalam respon OK
            return Ok(patient);
        }

        // Metode PUT untuk memperbarui data pasien berdasarkan PatientId
        [HttpPut("{id}")]
        public IActionResult UpdatePatient(int id, [FromBody] PatientUpdateDto patientUpdateDto, [FromQuery] string? gender = null, [FromQuery] string? bloodtype = null)
        {
            // Cari pasien yang ada berdasarkan PatientId
            var existingPatient = _context.patients.FirstOrDefault(p => p.PatientId == id);
            if (existingPatient == null)
            {
                return NotFound($"Patient with ID {id} not found.");
            }

            // Jika parameter gender dan blood type diberikan, periksa kevalidannya
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

            // Perbarui data pasien berdasarkan data yang diberikan dalam PatientUpdateDto
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
                // Validasi nomor telepon untuk memastikan tidak ada duplikasi nomor
                var phoneExists = _context.patients.Any(p => p.PhoneNumber == patientUpdateDto.PhoneNumber && p.PatientId != id);
                if (phoneExists)
                {
                    return BadRequest("Phone number already exists.");
                }
                existingPatient.PhoneNumber = patientUpdateDto.PhoneNumber;
            }
            if (!string.IsNullOrEmpty(patientUpdateDto.Email))
            {
                // Validasi email untuk memastikan tidak ada duplikasi email
                var emailExists = _context.patients.Any(p => p.Email == patientUpdateDto.Email && p.PatientId != id);
                if (emailExists)
                {
                    return BadRequest("Email already exists.");
                }
                existingPatient.Email = patientUpdateDto.Email;
            }

            // Perbarui tanggal lahir jika diberikan
            if (patientUpdateDto.BirthDate.HasValue)
            {
                var birthDate = patientUpdateDto.BirthDate.Value;
                existingPatient.BirthDate = new DateOnly(birthDate.Year, birthDate.Month, birthDate.Day);
            }

            // Tidak memperbarui kata sandi jika `PatientUpdateDto` tidak mengizinkan perubahan kata sandi
            // Anda bisa menambahkan logika untuk memperbarui kata sandi di sini jika diperlukan

            // Simpan perubahan ke database
            _context.SaveChanges();

            // Mengembalikan respon No Content jika update berhasil
            var response = new
            {
                message = "Patient updated successfully."
            };

            return Ok(response);
        }

        // Metode DELETE untuk menghapus pasien berdasarkan PatientId
        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            // Cari pasien yang ada berdasarkan PatientId
            var existingPatient = _context.patients.FirstOrDefault(p => p.PatientId == id);
            if (existingPatient == null)
            {
                return NotFound($"Patient with ID {id} not found.");
            }

            // Hapus pasien dari database
            _context.patients.Remove(existingPatient);
            _context.SaveChanges();

            var response = new
            {
                message = "Patient deleted successfully."
            };

            return Ok(response);
        }

        // Fungsi untuk menghasilkan garam (salt)
        private byte[] GenerateSalt(int size)
        {
            byte[] salt = new byte[size];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        // Fungsi untuk meng-hash password menggunakan PBKDF2 dengan garam yang ditentukan
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
