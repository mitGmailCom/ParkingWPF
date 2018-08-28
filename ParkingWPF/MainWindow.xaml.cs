using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ParkingWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Number of plases in the parking
        /// </summary>
        public int ParkingPlaces { get; set; } = 66;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            
            using (ParkingContext db = new ParkingContext())
            {
                //Car car = new Car { Manufacture = "Audi", Model = "200", Color = "Black", NumberCar = "АВ7633НП" };
                //Client client = new Client { FirstName = "Petr", LastName = "Petrov", MidleName = "Petrovich", Adress = "KrivoyRoh", Phone = 0983766543 };
                //ClientCarRelation rel = new ClientCarRelation { CarId = 4, ClientId = 2 };
                //db.Cars.Add(car);
                //db.Clients.Add(client);
                //db.ClientCarRelation.Add(rel);
                //db.SaveChanges();
            }
        }

        private void AddBtnToList()
        {

        }

        private void AddTextToButton()
        {
            for (int i = 0; i < ParkingPlaces; i++)
            {

            }
        }

        /// <summary>
        /// Show sector 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSector1_Click(object sender, RoutedEventArgs e)
        {
            Sector1 sector1 = new Sector1();
            sector1.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            sector1.Owner = this;
            sector1.Show();
        }
    }
}
