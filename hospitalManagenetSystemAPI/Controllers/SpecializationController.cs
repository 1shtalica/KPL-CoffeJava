using hospitalManagenetSystemAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using hospitalManagenetSystemAPI.DTO;
using hospitalManagenetSystemAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;

namespace hospitalManagenetSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecializationController : ControllerBase
    {
        private readonly AppDbContext _context;
        public SpecializationController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllSpecializations()
        {
            try
            {
                var specializations = _context.specializations.ToList();
                if (specializations.Count == 0)
                {
                    return NotFound("Specialization data is still empty");
                }

                var specializationResponse = specializations.Select(s => new SpecializationDto
                {
                    SpecializationId = s.SpecializationId,
                    Name = s.Name,
                    Description = s.Description
                }).ToList();

                return Ok(specializationResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching specializations: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetSpecialization(int id)
        {
            try
            {
                var specialization = _context.specializations.FirstOrDefault(s => s.SpecializationId == id);
                if (specialization == null)
                {
                    return NotFound($"Specialization with ID {id} not found.");
                }

                var specializationResponse = new SpecializationDto
                {
                    SpecializationId = specialization.SpecializationId,
                    Name = specialization.Name,
                    Description = specialization.Description
                };

                return Ok(specializationResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching specialization details: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult AddSpecialization([FromBody] SpecializationDto specializationDto)
        {
            try
            {
                if (specializationDto == null)
                {
                    return BadRequest("Invalid specialization data");
                }

                bool nameExist = _context.specializations.Any(s => s.Name == specializationDto.Name);
                if (nameExist)
                {
                    return BadRequest("Specialization name already exists.");
                }

                Specialization specialization = new Specialization
                {
                    Name = specializationDto.Name,
                    Description = specializationDto.Description,
                };

                _context.specializations.Add(specialization);
                _context.SaveChanges();

                specializationDto.SpecializationId = specialization.SpecializationId;

                return CreatedAtAction(nameof(AddSpecialization), specializationDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding the specialization: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSpecialization(int id, [FromBody] SpecializationDtoUpdate specializationDto)
        {
            try
            {
                if (specializationDto == null)
                {
                    return BadRequest("Invalid specialization data");
                }

                var specialization = _context.specializations.FirstOrDefault(s => s.SpecializationId == id);
                if (specialization == null)
                {
                    return NotFound($"Specialization with ID {id} not found.");
                }

                if (!string.IsNullOrEmpty(specializationDto.Name))
                {
                    specialization.Name = specializationDto.Name;
                }

                if (!string.IsNullOrEmpty(specializationDto.Description))
                {
                    specialization.Description = specializationDto.Description;
                }

                _context.SaveChanges();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the specialization: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSpecialization(int id)
        {
            try
            {
                var specialization = _context.specializations.FirstOrDefault(s => s.SpecializationId == id);
                if (specialization == null)
                {
                    return NotFound($"Specialization with ID {id} not found.");
                }

                _context.specializations.Remove(specialization);
                _context.SaveChanges();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting the specialization: {ex.Message}");
            }
        }
    }
}
