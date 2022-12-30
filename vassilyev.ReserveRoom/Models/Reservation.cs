using System;

namespace vassilyev.ReserveRoom.Models
{
    public class Reservation
    {
        public Reservation(RoomID roomID, string username, DateTime startTime, DateTime endTime)
        {
            RoomID = roomID;
            Username = username;
            StartTime = startTime;
            EndTime = endTime;
        }

        public RoomID RoomID { get; }
        public string Username { get; }
        public DateTime StartTime { get; }
        public DateTime EndTime { get; }
        public TimeSpan Length => EndTime.Subtract(StartTime);

        /// <summary>
        /// Проверяет конфликт при резервации
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns>True/False for conflicts</returns>
        public bool Conflicts(Reservation reservation)
        {
            return reservation.StartTime < EndTime &&
                reservation.EndTime > StartTime;
        }


    }
}
