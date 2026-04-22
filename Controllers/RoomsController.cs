using Microsoft.AspNetCore.Mvc;
using TrainingCenterApp.Models;
using System.Collections.Generic;

namespace TrainingCenterApp.Controllers
{
    [ApiController]
    [Route("api/rooms")]
    public class RoomsController : ControllerBase
            
    {
        [HttpGet]
        public ActionResult<IEnumerable<Room>> GetAllRooms(
            [FromQuery] int? minCapacity,
            [FromQuery] bool? hasProjector,
            [FromQuery] bool? activeOnly)
        {
            var rooms = DataContext.Rooms.AsEnumerable();

            if (minCapacity.HasValue)
                rooms = rooms.Where(r => r.Capacity >= minCapacity.Value);

            if (hasProjector.HasValue)
                rooms = rooms.Where(r => r.HasProjector == hasProjector.Value);

            if (activeOnly.HasValue && activeOnly.Value)
                rooms = rooms.Where(r => r.IsActive);

            return Ok(rooms.ToList());
        }

        
        [HttpGet("{id}")]
        public ActionResult<Room> GetRoomById(int id)
        {
            var room = DataContext.Rooms.FirstOrDefault(r => r.Id == id);
            if (room == null)
            {
                return NotFound();
            }
            return Ok(room);
        }

            
        [HttpGet("building/{buildingCode}")]
        public ActionResult<IEnumerable<Room>> GetRoomsByBuilding(string buildingCode)
        {
            var rooms = DataContext.Rooms.Where(r => r.BuildingCode == buildingCode).ToList();
            return Ok(rooms);
        }

        [HttpPost]
        public ActionResult<Room> AddRoom([FromBody] Room newRoom)
        {
            int newId = DataContext.Rooms.Any() ? DataContext.Rooms.Max(r => r.Id) + 1 : 1;
            newRoom.Id = newId;
            DataContext.Rooms.Add(newRoom);
            return CreatedAtAction(nameof(GetRoomById), new { id = newRoom.Id }, newRoom);
        }
        
        [HttpPut("{id}")]
        public ActionResult<Room> UpdateRoom(int id, [FromBody] Room updatedRoom)
        {
            var room = DataContext.Rooms.FirstOrDefault(r => r.Id == id);
            if (room == null)
            {
                return NotFound();
            }

            room.Name = updatedRoom.Name;
            room.BuildingCode = updatedRoom.BuildingCode;
            room.Floor = updatedRoom.Floor;
            room.Capacity = updatedRoom.Capacity;
            room.HasProjector = updatedRoom.HasProjector;
            room.IsActive = updatedRoom.IsActive;
            return Ok(room);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRoom(int id)
        {
            var room = DataContext.Rooms.FirstOrDefault(r => r.Id == id);
            if (room == null)
            {
                return NotFound();
            }
            DataContext.Rooms.Remove(room);
            return NoContent();
        }
    }
}
