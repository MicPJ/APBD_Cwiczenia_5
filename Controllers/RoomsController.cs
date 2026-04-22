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
    }
}
