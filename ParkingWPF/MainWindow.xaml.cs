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
        private int ParkingPlaces { get; set; } = 69;
        protected internal List<Button> ListButtons { get; set; }
        protected internal List<int> ListPlaces;
        protected int CountPlacesSector1 { get; set; }
        protected int CountPlacesSector2 { get; set; }
        protected int CountPlacesSector3 { get; set; }
        Sector1 sector1;
        Sector2 sector2;
        Sector3 sector3;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ListButtons = new List<Button>();
            ListPlaces = new List<int>();
            StatisticsOfPlaces.StatisticOfPlacesLoad();
            StatisticsOfPlaces.ShowStatisticsInMainWind(this);

            RegisterWindForSectors();
            AddBtnToList();
            AddTextToButton();
        }


        /// <summary>
        /// Allocation memorry for sectors
        /// </summary>
        private void RegisterWindForSectors()
        {
            sector1 = new Sector1();
            sector1.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            sector1.Owner = this;
            sector2 = new Sector2();
            sector2.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            sector2.Owner = this;
            sector3 = new Sector3();
            sector3.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            sector3.Owner = this;
        }


        private void FindButtonInForm()
        {
            //foreach (var butn in sector1)
            {

            }
        }


        /// <summary>
        /// Add buttons to list
        /// </summary>
        private void AddBtnToList()
        {
            ListButtons.AddRange(new List<Button> { sector1.btnPlace1, sector1.btnPlace2, sector1.btnPlace3, sector1.btnPlace4, sector1.btnPlace5, sector1.btnPlace6, sector1.btnPlace7,
                sector1.btnPlace8, sector1.btnPlace9, sector1.btnPlace10, sector1.btnPlace11, sector1.btnPlace12, sector1.btnPlace13, sector1.btnPlace14, sector1.btnPlace15,
                sector1.btnPlace16, sector1.btnPlace17, sector1.btnPlace18, sector1.btnPlace19, sector1.btnPlace20, sector1.btnPlace21,
                sector2.btnPlace22, sector2.btnPlace23, sector2.btnPlace24, sector2.btnPlace25, sector2.btnPlace26, sector2.btnPlace27, sector2.btnPlace28, sector2.btnPlace29,
                sector2.btnPlace30, sector2.btnPlace31, sector2.btnPlace32, sector2.btnPlace33, sector2.btnPlace34, sector2.btnPlace35, sector2.btnPlace36, sector2.btnPlace37,
                sector2.btnPlace38, sector2.btnPlace39, sector2.btnPlace40, sector2.btnPlace41, sector2.btnPlace42, sector2.btnPlace43, sector2.btnPlace44, sector2.btnPlace45,
                sector3.btnPlace46, sector3.btnPlace47, sector3.btnPlace48, sector3.btnPlace49, sector3.btnPlace50, sector3.btnPlace51, sector3.btnPlace52, sector3.btnPlace53,
                sector3.btnPlace54, sector3.btnPlace55, sector3.btnPlace56, sector3.btnPlace57, sector3.btnPlace58, sector3.btnPlace59, sector3.btnPlace60, sector3.btnPlace61,
                sector3.btnPlace62, sector3.btnPlace63, sector3.btnPlace64, sector3.btnPlace65, sector3.btnPlace66 });
        }


        /// <summary>
        /// Add content to buttons in list of buttons
        /// </summary>
        private void AddTextToButton()
        {
            for (int i = 0; i < ListButtons.Count; i++)
            {
                if ((ListButtons[i] as Button).Content == null || (ListButtons[i] as Button).Content.ToString() == string.Empty)
                    (ListButtons[i] as Button).Content = i + 1;
            }
        }


        //private void SetColorPlace()
        //{
        //    List<int> Places = new List<int>();
        //    using (ParkingContext db = new ParkingContext())
        //    {
        //        Places = db.BalanceParking.Select(pl => pl.Place).ToList();
        //        List<int> tt = new List<int>();
        //        for (int i = 0; i < ListButtons.Count; i++)
        //        {
        //            tt.Add(Int32.Parse(ListButtons[i].Content.ToString()));
        //        }
        //        IEnumerable<int> unique1 = tt.Except(Places);
        //        foreach (int item in unique1)
        //        {
        //            ListButtons[item - 1].Background = Brushes.White;
        //        }
        //        foreach (int item in Places)
        //        {
        //            ListButtons[item - 1].Background = Brushes.Red;
        //        }
        //    }
        //}


        /// <summary>
        /// Set for any sectors color scheme
        /// </summary>
        /// <param name="obj"></param>
        private void SetColorSchemeSectors(dynamic obj)
        {
            ClickOnPlace.DefaultSettingsForButtons(this);
            if ((obj).Visibility == Visibility.Hidden)
            {
                // установка цветовой схемы для мест на стоянки
                SetColor.SetColorForPlaces(ListButtons);
                obj.Visibility = Visibility.Visible;
            }
            else
            {
                SetColor.SetColorForPlaces(ListButtons);
                obj.Show();
            }
        }



        /// <summary>
        /// Event for click on button Sector1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSector1_Click(object sender, RoutedEventArgs e)
        {
            SetColorSchemeSectors(sector1);
        }

        /// <summary>
        /// Event for click on button Sector2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSector2_Click(object sender, RoutedEventArgs e)
        {
            SetColorSchemeSectors(sector2);
        }


        /// <summary>
        /// Event for click on button Sector3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSector3_Click(object sender, RoutedEventArgs e)
        {
            SetColorSchemeSectors(sector3);
        }


        /// <summary>
        /// Event for state radiobutton in radiogroup GroupFind
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioBtnPhoneClient_Checked(object sender, RoutedEventArgs e)
        {
            string nameRadioBtn = (sender as RadioButton).Name;
            if (nameRadioBtn == nameof(radioBtnNumberCar))
            {
                txbFindByPhoneClient.IsEnabled = false;
                txbFindByNumberCar.IsEnabled = true;
            }
            if (nameRadioBtn == nameof(radioBtnPhoneClient))
            {
                txbFindByNumberCar.IsEnabled = false;
                txbFindByPhoneClient.IsEnabled = true;
            }
        }


        /// <summary>
        /// Event for click on button FindMain
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFindMain_Click(object sender, RoutedEventArgs e)
        {
            // Если активны txbFindByNumberCar и txbFindByPhoneClient одновременно
            if (txbFindByNumberCar.IsEnabled & txbFindByPhoneClient.IsEnabled)
                return;

            // Если активна txbFindByNumberCar
            if (txbFindByNumberCar.IsEnabled)
            {
                if (txbFindByNumberCar.Text != null || txbFindByNumberCar.Text != string.Empty)
                    FindPlaceByNumberCar(txbFindByNumberCar.Text);
            }

            // Если активна txbFindByPhoneClient
            if (txbFindByPhoneClient.IsEnabled)
            {
                if (txbFindByPhoneClient.Text != null || txbFindByPhoneClient.Text != string.Empty)
                    FindPlaceByPhoneClient(txbFindByPhoneClient.Text);
            }
        }


        /// <summary>
        /// Find place by client's phone
        /// </summary>
        /// <param name="phoneClient"></param>
        private void FindPlaceByPhoneClient(string phoneClient)
        {
            phoneClient = phoneClient.TrimStart('0');
            using (ParkingContext db = new ParkingContext())
            {
                BalanceParking findPlace = db.BalanceParking.Where(p => p.Client.Phone.ToString() == phoneClient.ToString()).FirstOrDefault();
                if (findPlace != null)
                {
                    if (FindPlaceSetScheme(ListButtons, findPlace))
                        ShowSector(findPlace);
                }
            }
        }


        /// <summary>
        /// Find place by numberCar
        /// </summary>
        /// <param name="numberCar"></param>
        private void FindPlaceByNumberCar(string numberCar)
        {
            using (ParkingContext db = new ParkingContext())
            {
                BalanceParking findPlace = db.BalanceParking.Where(p => p.Car.NumberCar == numberCar).FirstOrDefault();
                if (findPlace != null)
                {
                    if (FindPlaceSetScheme(ListButtons, findPlace))
                        ShowSector(findPlace);
                }
            }
        }


        /// <summary>
        /// Show place in sector with border
        /// </summary>
        /// <param name="result"></param>
        private void ShowSector(BalanceParking result)
        {
            if (Int32.Parse(result.Place.ToString()) > 0 & Int32.Parse(result.Place.ToString()) < 22)
            {
                SetColor.SetColorForPlaces(ListButtons);
                sector1.Show();
            }
            if (Int32.Parse(result.Place.ToString()) > 21 & Int32.Parse(result.Place.ToString()) < 46)
            {
                SetColor.SetColorForPlaces(ListButtons);
                sector2.Show();
            }
            if (Int32.Parse(result.Place.ToString()) > 45 & Int32.Parse(result.Place.ToString()) < 67)
                sector3.Show();
        }


        /// <summary>
        /// Notice place in list of buttons
        /// </summary>
        /// <param name="ListBtns"></param>
        /// <param name="blPark"></param>
        /// <returns></returns>
        private bool FindPlaceSetScheme(IEnumerable<Button> ListBtns, BalanceParking blPark)
        {
            var res = ListBtns.Where(n => n.Content.ToString() == blPark.Place.ToString()).FirstOrDefault();
            if (res != null)
            {
                res.BorderBrush = Brushes.Black;
                res.BorderThickness = new Thickness(4);
                return true;
            }
            return false;
        }

        private void AddCar_Click(object sender, RoutedEventArgs e)
        {
            AddCar AddCar = new AddCar();
            AddCar.Owner = this;
            AddCar.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            AddCar.ShowDialog();
        }

        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
            AddClient addClient = new AddClient();
            addClient.Owner = this;
            addClient.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            addClient.ShowDialog();
        }

    }
}
