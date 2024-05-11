using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using hospitalManagenetSystemAPI.Data;
using hospitalManagenetSystemAPI.DTO;
using hospitalManagenetSystemAPI.Models;
using System;
using System.Linq;

namespace hospitalManagenetSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RoomController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllRooms()
        {
            try
            {
                var rooms = _context.rooms.ToList();
                if (rooms.Count == 0)
                {
                    return NotFound("Rooms data is still empty");
                }

                var roomResponses = rooms.Select(r => new RoomDto
                {
                    RoomId = r.RoomId,
                    RoomName = r.RoomName,
                    RoomFloor = r.RoomFloor,
                    RoomNumber = r.RoomNumber
                }).ToList();

                return Ok(roomResponses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching rooms: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetRoomById(int id)
        {
            try
            {
                var room = _context.rooms.FirstOrDefault(r => r.RoomId == id);
                if (room == null)
                {
                    return NotFound($"Room with ID {id} not found.");
                }

                var roomResponse = new RoomDto
                {
                    RoomId = room.RoomId,
                    RoomName = room.RoomName,
                    RoomFloor = room.RoomFloor,
                    RoomNumber = room.RoomNumber
                };

                return Ok(roomResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching room details: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult AddRoom([FromBody] RoomDto roomDto)
        {
            try
            {
                if (roomDto == null)
                {
                    return BadRequest("Invalid room data");
                }

                var existingRoom = _context.rooms.FirstOrDefault(r => r.RoomName == roomDto.RoomName);
                if (existingRoom != null)
                {
                    return BadRequest("Room name already exists.");
                }

                var room = new Room
                {
                    RoomName = roomDto.RoomName,
                    RoomFloor = roomDto.RoomFloor,
                    RoomNumber = roomDto.RoomNumber
                };

                _context.rooms.Add(room);
                _context.SaveChanges();

                var roomResponse = new RoomDto
                {
                    RoomId = room.RoomId,
                    RoomName = room.RoomName,
                    RoomFloor = room.RoomFloor,
                    RoomNumber = room.RoomNumber
                };

                return CreatedAtAction(nameof(GetRoomById), new { id = room.RoomId }, roomResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding the room: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRoom(int id, [FromBody] RoomDtoUpdate roomDto)
        {
            try
            {
                var room = _context.rooms.FirstOrDefault(r => r.RoomId == id);
                if (room == null)
                {
                    return NotFound($"Room with ID {id} not found.");
                }

                if (roomDto.RoomName != null)
                {
                    var existingRoom = _context.rooms.FirstOrDefault(r => r.RoomName == roomDto.RoomName && r.RoomId != id);
                    if (existingRoom != null)
                    {
                        return BadRequest("Room name already exists.");
                    }
                    room.RoomName = roomDto.RoomName;
                }
                if (roomDto.RoomFloor != null)
                {
                    room.RoomFloor = (int)roomDto.RoomFloor;
                }
                if (roomDto.RoomNumber != null)
                {
                    room.RoomNumber = (int)roomDto.RoomNumber;
                }

                _context.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the room: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRoom(int id)
        {
            try
            {
                var room = _context.rooms.FirstOrDefault(r => r.RoomId == id);
                if (room == null)
                {
                    return NotFound($"Room with ID {id} not found.");
                }

                _context.rooms.Remove(room);
                _context.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting the room: {ex.Message}");
            }
        }
    }
}
