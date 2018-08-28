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
        private int ParkingPlaces { get; set; } = 66;
        private List<Button> ListButtons { get; set; }
        Sector1 sector1;
        Sector2 sector2;
        //Sector3 sector3;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ListButtons = new List<Button>();
            
            RegisterWindForSectors();
            AddBtnToList();
            AddTextToButton();

            using (ParkingContext db = new ParkingContext())
            {
                //Car car = new Car { Manufacture = "Audi", Model = "200", Color = "Black", NumberCar = "АВ7633НП" };
                //Client client = new Client { FirstName = "Petr", LastName = "Petrov", MidleName = "Petrovich", Adress = "KrivoyRoh", Phone = 0983766543 };
                //ClientCarRelation rel = new ClientCarRelation { CarId = 4, ClientId = 2 };
                //db.Cars.Add(car);
                //db.Clients.Add(client);
                //db.ClientCarRelation.Add(rel);
                //BalanceParking bl = new BalanceParking { CarId = 4, ClientId = 2, DataAdded = DateTime.Now, Place = 4 };
                //db.BalanceParking.Add(bl);
                //db.SaveChanges();



            }
        }
        private void RegisterWindForSectors()
        {
            sector1 = new Sector1();
            sector1.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            sector1.Owner = this;
            sector2 = new Sector2();
            sector2.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            sector2.Owner = this;
        }


        private void FindButtonInForm()
        {
            //foreach (var butn in sector1)
            {

            }
        }

        private void AddBtnToList()
        {
            ListButtons.AddRange( new List<Button> { sector1.btnPlace1, sector1.btnPlace2, sector1.btnPlace3, sector1.btnPlace4, sector1.btnPlace5, sector1.btnPlace6, sector1.btnPlace7,
                sector1.btnPlace8, sector1.btnPlace9, sector1.btnPlace10, sector1.btnPlace11, sector1.btnPlace12, sector1.btnPlace13, sector1.btnPlace14, sector1.btnPlace15,
                sector1.btnPlace16, sector1.btnPlace17, sector1.btnPlace18, sector1.btnPlace19, sector1.btnPlace20, sector1.btnPlace21 });
                //, sector1.btnPlace22, sector1.btnPlace23,
                //sector1.btnPlace24, sector1.btnPlace25, sector1.btnPlace26, sector1.btnPlace27, sector1.btnPlace28, sector1.btnPlace29, sector1.btnPlace30, sector1.btnPlace31,
                //sector1.btnPlace32, sector1.btnPlace33, sector1.btnPlace34, sector1.btnPlace35, sector1.btnPlace36, sector1.btnPlace37, sector1.btnPlace38, sector1.btnPlace39,
                //sector1.btnPlace40, sector1.btnPlace41, sector1.btnPlace42, sector1.btnPlace43, sector1.btnPlace44, sector1.btnPlace45, sector1.btnPlace46, sector1.btnPlace47,
                //sector1.btnPlace48, sector1.btnPlace49, sector1.btnPlace50, sector1.btnPlace51, sector1.btnPlace52, sector1.btnPlace53, sector1.btnPlace54, sector1.btnPlace55,
                //sector1.btnPlace56, sector1.btnPlace57, sector1.btnPlace58, sector1.btnPlace59, sector1.btnPlace60, sector1.btnPlace61, sector1.btnPlace62, sector1.btnPlace63,
                //sector1.btnPlace64, sector1.btnPlace65, sector1.btnPlace66);*//
        }

        private void AddTextToButton()
        {
            for (int i = 0; i < ListButtons.Count; i++)
            {
                if ((ListButtons[i] as Button).Content == null || (ListButtons[i] as Button).Content.ToString() == string.Empty)
                    (ListButtons[i] as Button).Content = i + 1;
            }
        }

        /// <summary>
        /// Show sector 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSector1_Click(object sender, RoutedEventArgs e)
        {
            SetColorPlace();
            sector1.Show();
        }

        private void SetColorPlace()
        {
            List<int> Places = new List<int>();
            using (ParkingContext db = new ParkingContext())
            {
                Places = db.BalanceParking.Select(pl => pl.Place).ToList();
                List<int> tt = new List<int>();
                for (int i = 0; i < ListButtons.Count; i++)
                {
                    tt.Add(Int32.Parse(ListButtons[i].Content.ToString()));
                }
                IEnumerable<int> unique1 = tt.Except(Places);
                foreach (int item in unique1)
                {
                    ListButtons[item - 1].Background = Brushes.White;
                }
                foreach (int item in Places)
                {
                    ListButtons[item - 1].Background = Brushes.Red;
                }
            }
        }




    }
}
