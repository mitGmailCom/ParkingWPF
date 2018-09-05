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
using System.Windows.Shapes;

namespace ParkingWPF
{
    /// <summary>
    /// Логика взаимодействия для ClickPlace.xaml
    /// </summary>
    public partial class ClickPlace : Window
    {
        internal int? SenderPlace { get; set; }
        internal int IdCar { get; set; }
        internal int IdClient { get; set; }

        public ClickPlace()
        {
            InitializeComponent();
            Loaded += ClickPlace_Loaded;
        }
        

        /// <summary>
        /// Disable all buttons on ClickPlace window
        /// </summary>
        private void ClearValuesInBtn()
        {
            btnAddCar.IsEnabled = false;
            btnAddClient.IsEnabled = false;
            btnEditeCar.IsEnabled = false;
            btnEditeClient.IsEnabled = false;
            btnMoveFromPlace.IsEnabled = false;
            btnSelectCar.IsEnabled = false;
            btnSelectClient.IsEnabled = false;
            btnSaveToPlace.IsEnabled = false;
        }

        /// <summary>
        /// Disable buttons in case Checked Car
        /// </summary>
        private void CaseCheckedCar()
        {
            btnAddCar.IsEnabled = false;
            btnAddClient.IsEnabled = false;
            btnEditeCar.IsEnabled = false;
            btnEditeClient.IsEnabled = false;
            btnMoveFromPlace.IsEnabled = true;
            btnSelectCar.IsEnabled = false;
            btnSelectClient.IsEnabled = false;
            btnSaveToPlace.IsEnabled = false;
        }

        /// <summary>
        /// Disable buttons in case Checked Cient
        /// </summary>
        private void CaseNotCheckedCar()
        {
            btnAddCar.IsEnabled = true;
            btnAddClient.IsEnabled = true;
            btnEditeCar.IsEnabled = false;
            btnEditeClient.IsEnabled = false;
            btnMoveFromPlace.IsEnabled = false;
            btnSelectCar.IsEnabled = true;
            btnSelectClient.IsEnabled = true;
            btnSaveToPlace.IsEnabled = false;
        }


        private void ClickPlace_Loaded(object sender, RoutedEventArgs e)
        {
            ClearValuesInBtn();
            if (SenderPlace != null)
            {
                LoadDataToClickPlace();
            }
        }


        /// <summary>
        /// Initial loading of data into the window ClickPlace
        /// </summary>
        private void LoadDataToClickPlace()
        {
            using (ParkingContext db = new ParkingContext())
            {
                var placeInfo = db.BalanceParking.Where(p => p.Place == SenderPlace)
                    .Select(pl => new
                    {
                        place = pl.Place,
                        clientLName = pl.Client.LastName,
                        clientFName = pl.Client.FirstName,
                        phone = pl.Client.Phone,
                        manufacture = pl.Car.Manufacture,
                        model = pl.Car.Model,
                        color = pl.Car.Color,
                        number = pl.Car.NumberCar,
                        date = pl.DataAdded
                    }).FirstOrDefault();

                // case, that no data in placeInfo
                if (placeInfo != null)
                {
                    txbInfoPlace.Text = placeInfo.place.ToString();
                    txbInfoClientFirstName.Text = placeInfo.clientFName;
                    txbInfoClientLastName.Text = placeInfo.clientLName;
                    txbInfoPhone.Text = placeInfo.phone.ToString();
                    if (txbInfoPhone.Text.Length < 10)
                    {
                        for (int i = 0; i < 10-txbInfoPhone.Text.Length; i++)
                        {
                            txbInfoPhone.Text = txbInfoPhone.Text.Insert(0, "0");
                        }
                    }
                    txbInfoManufacture.Text = placeInfo.manufacture;
                    txbInfoModel.Text = placeInfo.model;
                    txbInfoColor.Text = placeInfo.color;
                    txbInfoNumber.Text = placeInfo.number;
                    txbInfoDate.Text = placeInfo.date.ToShortDateString();
                    CaseCheckedCar();
                }
                else
                {
                    txbInfoPlace.Text = SenderPlace.Value.ToString();
                    CaseNotCheckedCar();
                }
            }
        }
        

        /// <summary>
        /// Check all Texboxes
        /// </summary>
        /// <returns></returns>
        public bool CheckAllFieldsClickPlace()
        {
            // ToDo
            bool res = false;
            if (txbInfoPlace.Text == null || txbInfoPlace.Text == string.Empty)
                res = false;
            if (txbInfoClientFirstName.Text == null || txbInfoClientFirstName.Text == string.Empty)
                res = false;
            if (txbInfoClientLastName.Text == null || txbInfoClientLastName.Text == string.Empty)
                res = false;
            if (txbInfoPhone.Text == null || txbInfoPhone.Text == string.Empty)
                res = false;
            if (txbInfoManufacture.Text == null || txbInfoManufacture.Text == string.Empty)
                res = false;
            if (txbInfoModel.Text == null || txbInfoModel.Text == string.Empty)
                res = false;
            if (txbInfoColor.Text == null || txbInfoColor.Text == string.Empty)
                res = false;
            if (txbInfoNumber.Text == null || txbInfoNumber.Text == string.Empty)
                res = false;
            //if (txbInfoDate.Text == null || txbInfoDate.Text == string.Empty)
            //    res = false;
            else
                res = true;

            return res;
        }



        private void btnAddCar_Click(object sender, RoutedEventArgs e)
        {
            AddCar AddCar = new AddCar();
            AddCar.Owner = this;
            AddCar.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            AddCar.ShowDialog();
        }


        private void btnAddClient_Click(object sender, RoutedEventArgs e)
        {
            AddClient addClient = new AddClient();
            addClient.Owner = this;
            addClient.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            addClient.ShowDialog();
        }


        private void btnSelectCar_Click(object sender, RoutedEventArgs e)
        {
            SelectCar selectCar = new SelectCar();
            selectCar.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            selectCar.Owner = this;
            selectCar.ShowDialog();
        }


        private void btnSelectClient_Click(object sender, RoutedEventArgs e)
        {
            SelectClient selectClient = new SelectClient();
            selectClient.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            selectClient.Owner = this;
            selectClient.ShowDialog();
        }


        /// <summary>
        /// Take the car out off the parking place
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMoveFromPlace_Click(object sender, RoutedEventArgs e)
        {
            if (CheckAllFieldsClickPlace())
            {
                using (ParkingContext db = new ParkingContext())
                {
                    using (var tran = db.Database.BeginTransaction())
                    {
                        try
                        {
                            BalanceParking bal = db.BalanceParking.Where(b => b.Place == SenderPlace).FirstOrDefault();
                            //BalanceParking bal = new BalanceParking { Place = (int)SenderPlace };
                            //db.BalanceParking.Attach(bal);
                            if (bal != null)
                            {
                                db.BalanceParking.Remove(bal);
                                db.HistoryDeletedCars.Add(new HistoryDeletedCars { ClientId = bal.ClientId, CarId = bal.CarId, DataAdded = bal.DataAdded, Place = (int)SenderPlace });
                                db.SaveChanges();
                                tran.Commit();
                                btnMoveFromPlace.IsEnabled = false;
                                btnSaveToPlace.IsEnabled = false;
                                StatisticsOfPlaces.UpdateStatisticsPlaces(bal.Place, '-');
                                StatisticsOfPlaces.ShowStatisticsInMainWind();
                                SetColor.SetColorForPlaces((List<Button>)(this.Owner as MainWindow).ListButtons);
                                this.Close();
                            }
                        }
                        catch (Exception)
                        {
                            tran.Rollback();
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Add info about Client and Car to Parking
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveToPlace_Click(object sender, RoutedEventArgs e)
        {
            if (txbInfoDate.Text == null || txbInfoDate.Text == string.Empty)
                txbInfoDate.Text = DateTime.Now.ToShortDateString().ToString();
            if (!CheckAllFieldsClickPlace())
                MessageBox.Show("Please input all fields!", "Warning!");
            if (CheckAllFieldsClickPlace())
                AddToBalanceParking();
        }


        /// <summary>
        /// The method of adding  info about Client and Car to Parking
        /// </summary>
        private void AddToBalanceParking()
        {
            using (ParkingContext db = new ParkingContext())
            {
                var tempCar = db.Cars.Where(c => c.NumberCar == txbInfoNumber.Text).FirstOrDefault();
                int tempNum = Int32.Parse(txbInfoPhone.Text);
                var tempClient = db.Clients.Where(c => c.Phone == tempNum).FirstOrDefault();
                BalanceParking temPlace = new BalanceParking { ClientId = tempClient.Id, CarId = tempCar.Id, DataAdded = DateTime.Parse(txbInfoDate.Text), Place = (int)SenderPlace };
                var isExistPlace = db.BalanceParking.Where(pl => pl.CarId == temPlace.CarId).FirstOrDefault();
                if (isExistPlace == null)
                {
                    db.BalanceParking.Add(temPlace);
                    db.HistoryAddedCars.Add(new HistoryAddedCars { ClientId = tempClient.Id, CarId = tempCar.Id, DataAdded = DateTime.Parse(txbInfoDate.Text), Place = (int)SenderPlace });
                    db.SaveChanges();
                    StatisticsOfPlaces.UpdateStatisticsPlaces(temPlace.Place, '+');
                    StatisticsOfPlaces.ShowStatisticsInMainWind();
                    SetColor.SetColorForPlaces((List<Button>)(this.Owner as MainWindow).ListButtons);
                    this.Close();
                }
            }
        }

    }
}
