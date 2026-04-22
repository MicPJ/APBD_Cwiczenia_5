using System;
using System.Collections.Generic;

namespace TrainingCenterApp.Models
{
    public static class DataContext
    {
        public static List<Room> Rooms = new List<Room>
        {
            new Room { Id = 1, Name = "Lab 101", BuildingCode = "A", Floor = 1, Capacity = 20, HasProjector = true, IsActive = true },
            new Room { Id = 2, Name = "Lab 204", BuildingCode = "B", Floor = 2, Capacity = 24, HasProjector = true, IsActive = true },
            new Room { Id = 3, Name = "Sala 12", BuildingCode = "A", Floor = 1, Capacity = 15, HasProjector = false, IsActive = true },
            new Room { Id = 4, Name = "Sala 22", BuildingCode = "C", Floor = 2, Capacity = 30, HasProjector = true, IsActive = false }
        };

        public static List<Reservation> Reservations = new List<Reservation>
        {
            new Reservation { Id = 1, RoomId = 1, OrganizerName = "Anna Kowalska", Topic = "Warsztaty z HTTP i REST", Date = new DateTime(2026, 5, 10), StartTime = new TimeSpan(10, 0, 0), EndTime = new TimeSpan(12, 30, 0), Status = "confirmed" },
            new Reservation { Id = 2, RoomId = 2, OrganizerName = "Jan Nowak", Topic = "Konsultacje projektowe", Date = new DateTime(2026, 5, 11), StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(10, 0, 0), Status = "planned" },
            new Reservation { Id = 3, RoomId = 3, OrganizerName = "Ewa Malinowska", Topic = "Spotkanie zespołu", Date = new DateTime(2026, 5, 12), StartTime = new TimeSpan(14, 0, 0), EndTime = new TimeSpan(15, 30, 0), Status = "confirmed" },
            new Reservation { Id = 4, RoomId = 1, OrganizerName = "Piotr Zieliński", Topic = "Szkolenie BHP", Date = new DateTime(2026, 5, 13), StartTime = new TimeSpan(8, 0, 0), EndTime = new TimeSpan(10, 0, 0), Status = "cancelled" }
        };
    }
}
