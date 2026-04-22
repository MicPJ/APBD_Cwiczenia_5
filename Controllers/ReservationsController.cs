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

        [HttpGet("{id}")]
        public ActionResult<Reservation> GetReservationById(int id)
        {
            var reservation = DataContext.Reservations.FirstOrDefault(r => r.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }
            return Ok(reservation);
        }

        [HttpPost]
        public ActionResult<Reservation> AddReservation([FromBody] Reservation newReservation)
        {
            if (string.IsNullOrWhiteSpace(newReservation.OrganizerName) ||
                string.IsNullOrWhiteSpace(newReservation.Topic) ||
                newReservation.RoomId <= 0 ||
                newReservation.Date == default ||
                newReservation.StartTime == default ||
                newReservation.EndTime == default ||
                string.IsNullOrWhiteSpace(newReservation.Status))
            {
                return BadRequest("Invalid input data.");
            }
            if (newReservation.EndTime <= newReservation.StartTime)
            {
                return BadRequest("EndTime must be later than StartTime.");
            }
            int newId = DataContext.Reservations.Any() ? DataContext.Reservations.Max(r => r.Id) + 1 : 1;
            newReservation.Id = newId;
            DataContext.Reservations.Add(newReservation);
            return CreatedAtAction(nameof(GetReservationById), new { id = newReservation.Id }, newReservation);
        }

        [HttpPut("{id}")]
        public ActionResult<Reservation> UpdateReservation(int id, [FromBody] Reservation updatedReservation)
        {
            if (string.IsNullOrWhiteSpace(updatedReservation.OrganizerName) ||
                string.IsNullOrWhiteSpace(updatedReservation.Topic) ||
                updatedReservation.RoomId <= 0 ||
                updatedReservation.Date == default ||
                updatedReservation.StartTime == default ||
                updatedReservation.EndTime == default ||
                string.IsNullOrWhiteSpace(updatedReservation.Status))
            {
                return BadRequest("Invalid input data.");
            }
            if (updatedReservation.EndTime <= updatedReservation.StartTime)
            {
                return BadRequest("EndTime must be later than StartTime.");
            }
            var reservation = DataContext.Reservations.FirstOrDefault(r => r.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }
            reservation.RoomId = updatedReservation.RoomId;
            reservation.OrganizerName = updatedReservation.OrganizerName;
            reservation.Topic = updatedReservation.Topic;
            reservation.Date = updatedReservation.Date;
            reservation.StartTime = updatedReservation.StartTime;
            reservation.EndTime = updatedReservation.EndTime;
            reservation.Status = updatedReservation.Status;
            return Ok(reservation);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteReservation(int id)
        {
            var reservation = DataContext.Reservations.FirstOrDefault(r => r.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }
            DataContext.Reservations.Remove(reservation);
            return NoContent();
        }
    }
}
