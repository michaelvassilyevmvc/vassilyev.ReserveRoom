using System.Collections.Generic;

namespace vassilyev.ReserveRoom.Models
{
    public class Hotel
    {
        private readonly ReservationBook _reservationBook;
        public Hotel(string name)
        {
            Name = name;
            _reservationBook = new ReservationBook();
        }

        public string Name { get; set; }

        public IEnumerable<Reservation> GetAllReservations()
        {
            return _reservationBook.GetAllReservations();
        }

        public void MakeReservation(Reservation reservation)
        {
            _reservationBook.AddReservation(reservation);
        }

    }
}
