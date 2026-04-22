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
    }
}
