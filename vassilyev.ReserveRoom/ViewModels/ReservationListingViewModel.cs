using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using vassilyev.ReserveRoom.Commands;
using vassilyev.ReserveRoom.Models;

namespace vassilyev.ReserveRoom.ViewModels
{
    public class ReservationListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ReservationViewModel> _reservations;

        public IEnumerable<ReservationViewModel> Reservations => _reservations;
        public ICommand MakeReservationCommand { get; }

        public ReservationListingViewModel()
        {
            _reservations = new ObservableCollection<ReservationViewModel>();
            MakeReservationCommand = new NavigateCommand();

            _reservations.Add(new ReservationViewModel(new Reservation(new RoomID(1, 2), "John", DateTime.MinValue, DateTime.MaxValue)));
            _reservations.Add(new ReservationViewModel(new Reservation(new RoomID(3, 2), "James", DateTime.MinValue, DateTime.MaxValue)));
            _reservations.Add(new ReservationViewModel(new Reservation(new RoomID(2, 4), "Vanda", DateTime.MinValue, DateTime.MaxValue)));
        }
    }
}
