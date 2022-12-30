using System.Windows;
using vassilyev.ReserveRoom.Models;
using vassilyev.ReserveRoom.ViewModels;

namespace vassilyev.ReserveRoom
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly Hotel _hotel;
        public App()
        {
            _hotel = new Hotel("Hilton");
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_hotel)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }



    }
}
