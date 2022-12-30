using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using vassilyev.ReserveRoom.Exceptions;
using vassilyev.ReserveRoom.Models;

namespace vassilyev.ReserveRoom
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Hotel hotel = new Hotel("Hilton");

            try
            {
                hotel.MakeReservation(new Reservation(new RoomID(1, 3), "Hilton", new DateTime(1995, 1, 2), new DateTime(1999, 1, 3)));
                hotel.MakeReservation(new Reservation(new RoomID(1, 3), "Hilton", new DateTime(2000, 1, 1), new DateTime(2000, 1, 2)));
            }
            catch (ReservationConflictException ex)
            {

            }

            IEnumerable<Reservation> reservations = hotel.GetReservationForUser("Hilton");
            base.OnStartup(e);
        }

        

    }
}
