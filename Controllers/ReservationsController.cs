using Microsoft.AspNetCore.Mvc;
using TrainingCenterApp.Models;
using System.Collections.Generic;

namespace TrainingCenterApp.Controllers
{
    [ApiController]
    [Route("api/reservations")]
    public class ReservationsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Reservation>> GetAllReservations()
        {
            return Ok(DataContext.Reservations);
        }
    }
}
