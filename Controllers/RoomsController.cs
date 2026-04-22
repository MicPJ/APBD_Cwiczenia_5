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
        public ActionResult<IEnumerable<Room>> GetAllRooms()
        {
            return Ok(DataContext.Rooms);
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
    }
}
