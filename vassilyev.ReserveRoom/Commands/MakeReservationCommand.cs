using System.ComponentModel;
using System.Windows;
using vassilyev.ReserveRoom.Exceptions;
using vassilyev.ReserveRoom.Models;
using vassilyev.ReserveRoom.ViewModels;

namespace vassilyev.ReserveRoom.Commands
{
    public class MakeReservationCommand : CommandBase
    {
        private readonly MakeReservationViewModel _makeReservationViewModel;
        private readonly Hotel _hotel;

        public MakeReservationCommand(MakeReservationViewModel makeReservationViewModel, Hotel hotel)
        {
            _makeReservationViewModel = makeReservationViewModel;
            _hotel = hotel;

            _makeReservationViewModel.PropertyChanged += _makeReservationViewModel_PropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_makeReservationViewModel.Username) &&
                _makeReservationViewModel.FloorNumber > 0 &&
                base.CanExecute(parameter);
        }

        private void _makeReservationViewModel_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MakeReservationViewModel.Username) ||
                e.PropertyName == nameof(MakeReservationViewModel.FloorNumber))
            {
                OnCanExecuteChanged();
            }
        }

        public override void Execute(object? parameter)
        {
            Reservation reservation = new Reservation(
                    new RoomID(_makeReservationViewModel.FloorNumber, _makeReservationViewModel.RoomNumber),
                    _makeReservationViewModel.Username,
                    _makeReservationViewModel.StartDate,
                    _makeReservationViewModel.EndDate);

            try
            {
                _hotel.MakeReservation(reservation);
                MessageBox.Show("Successfully reserved room.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (ReservationConflictException ex)
            {
                MessageBox.Show("This room is already taken.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
