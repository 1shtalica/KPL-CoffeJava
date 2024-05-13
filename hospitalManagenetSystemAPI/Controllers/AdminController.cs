using Microsoft.AspNetCore.Mvc;
using hospitalManagenetSystemAPI.Models;
using System;
using System.Linq;
using hospitalManagenetSystemAPI.Data;
using hospitalManagenetSystemAPI.DTO;
using System.Security.Cryptography;
using hospitalManagenetSystemAPI.NewFolder;


namespace hospitalManagenetSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        

        [HttpGet("{id}")]
        public IActionResult GetAdminById(int id)
        {
            try
            {
                var existingadmin = _context.Admins.FirstOrDefault(a => a.AdminId == id);
                if (existingadmin == null)
                {
                    return NotFound($"Admin with ID {id} not found.");
                }

                var admin = new AdminUpdateDto
                {
                    FirstName = existingadmin.FirstName,
                    LastName = existingadmin.LastName,
                    Email = existingadmin.Email,
                    PhoneNumber = existingadmin.PhoneNumber,
                 
                };
                return Ok(admin);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching admin details: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult AddAdmin([FromBody] AdminDto adminDto)
        {
            try
            {
                if (adminDto == null)
                {
                    return BadRequest("Invalid admin data");
                }

                var existingEmailAdmin = _context.Admins.FirstOrDefault(e => e.Email == adminDto.Email);
                var existingPhoneAdmin = _context.Admins.FirstOrDefault(p => p.PhoneNumber == adminDto.PhoneNumber);
                if (existingEmailAdmin != null)
                {
                    return BadRequest("Admin with this email already exists.");
                }

                if (existingPhoneAdmin != null)
                {
                    return BadRequest("Admin with this phoneNumber already exists.");
                }

                byte[] salt = GenerateSalt(16);
                string hashedPassword = HashPassword(adminDto.Password, salt);
                var newAdmin = new Admin
                {
                    FirstName = adminDto.FirstName,
                    LastName = adminDto.LastName,
                    Email = adminDto.Email,
                    PhoneNumber = adminDto.PhoneNumber,
                    Password = hashedPassword,
                    Salt = Convert.ToBase64String(salt)
                };

                _context.Admins.Add(newAdmin);
                _context.SaveChanges();

                return CreatedAtAction(nameof(GetAdminById), new { id = newAdmin.AdminId }, newAdmin);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding the admin: {ex.Message}");
            }
        }


        [HttpPut("{id}")]
        public IActionResult UpdateAdmin(int id, [FromBody] AdminUpdateDto admin)
        {
            try
            {
                var existingAdmin = _context.Admins.FirstOrDefault(a => a.AdminId == id);
                if (existingAdmin == null)
                {
                    return NotFound($"Admin with ID {id} not found.");
                }

                if (!string.IsNullOrEmpty(admin.FirstName))
                {
                    existingAdmin.FirstName = admin.FirstName;
                }
                if (!string.IsNullOrEmpty(admin.LastName))
                {
                    existingAdmin.LastName = admin.LastName;
                }
                if (!string.IsNullOrEmpty(admin.Email))
                {
                    var emailExists = _context.Admins.Any(a => a.Email == admin.Email && a.AdminId != id);
                    if (emailExists)
                    {
                        return BadRequest("Email already exists.");
                    }
                    existingAdmin.Email = admin.Email;
                }
                if (!string.IsNullOrEmpty(admin.PhoneNumber))
                {
                    var phoneExists = _context.Admins.Any(a => a.PhoneNumber == admin.PhoneNumber && a.AdminId != id);
                    if (phoneExists)
                    {
                        return BadRequest("Phone number already exists.");
                    }
                    existingAdmin.PhoneNumber = admin.PhoneNumber;
                }
                

                _context.SaveChanges();

                var response = new
                {
                    message = "Admin updated successfully.",
                   
                    
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the admin: {ex.Message}");
            }
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteAdmin(int id)
        {
            try
            {
                var admin = _context.Admins.FirstOrDefault(a => a.AdminId == id);
                if (admin == null)
                {
                    return NotFound($"Admin with ID {id} not found.");
                }

                _context.Admins.Remove(admin);
                _context.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting the admin: {ex.Message}");
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
