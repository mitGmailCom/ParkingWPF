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

        public ClickPlace()
        {
            InitializeComponent();
            Loaded += ClickPlace_Loaded;
        }
        public string PlaceInClickPlace
        {
            get
            {
                return this.txbInfoPlace.Text;
            }
            set
            {
                txbInfoPlace.Text = value;
            }
        }
        public string LastNameInClickPlace
        {
            get
            {
                return this.txbInfoClientLastName.Text;
            }
            set
            {
                txbInfoClientLastName.Text = value;
            }
        }
        public string FirstNameInClickPlace
        {
            get
            {
                return this.txbInfoClientFirstName.Text;
            }
            set
            {
                txbInfoClientFirstName.Text = value;
            }
        }
        public string PhoneInClickPlace
        {
            get
            {
                return this.txbInfoPhone.Text;
            }
            set
            {
                txbInfoPhone.Text = value;
            }
        }
        public string ManufactureInClickPlace
        {
            get
            {
                return this.txbInfoManufacture.Text;
            }
            set
            {
                txbInfoManufacture.Text = value;
            }
        }
        public string ModelInClickPlace
        {
            get
            {
                return this.txbInfoModel.Text;
            }
            set
            {
                txbInfoModel.Text = value;
            }
        }
        public string ColorCarInClickPlace
        {
            get
            {
                return this.txbInfoColor.Text;
            }
            set
            {
                txbInfoColor.Text = value;
            }
        }
        public string NumberCarInClickPlace
        {
            get
            {
                return this.txbInfoNumber.Text;
            }
            set
            {
                txbInfoNumber.Text = value;
            }
        }
        public string DateAddInClickPlace
        {
            get
            {
                return this.txbInfoDate.Text;
            }
            set
            {
                txbInfoDate.Text = value;
            }
        }


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

        private void CaseNotCheckedCar()
        {
            btnAddCar.IsEnabled = true;
            btnAddClient.IsEnabled = true;
            btnEditeCar.IsEnabled = false;
            btnEditeClient.IsEnabled = false;
            btnMoveFromPlace.IsEnabled = true;
            btnSelectCar.IsEnabled = true;
            btnSelectClient.IsEnabled = true;
            btnSaveToPlace.IsEnabled = false;
        }

        //public struct InfoPlace
        //{
        //    public int place;
        //    string lastName;
        //    string firstName;
        //    int phone;
        //    string manufacture;
        //    string madel;
        //    string color;
        //    int number;
        //    DateTime dateAdding;
        //}

        private void ClickPlace_Loaded(object sender, RoutedEventArgs e)
        {
            ClearValuesInBtn();
            if (SenderPlace != null)
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

                    if (placeInfo != null)
                    {
                        txbInfoPlace.Text = placeInfo.place.ToString();
                        txbInfoClientFirstName.Text = placeInfo.clientFName;
                        txbInfoClientLastName.Text = placeInfo.clientLName;
                        txbInfoPhone.Text = placeInfo.phone.ToString();
                        txbInfoManufacture.Text = placeInfo.manufacture;
                        txbInfoModel.Text = placeInfo.model;
                        txbInfoColor.Text = placeInfo.color;
                        txbInfoNumber.Text = placeInfo.number;
                        txbInfoDate.Text = placeInfo.date.ToString("yyyy-mm-dd");
                        CaseCheckedCar();
                    }
                    else
                    {
                        CaseNotCheckedCar();
                    }
                }
            }
        }

        public bool CheckAllFieldsClickPlace()
        {
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
            if (txbInfoDate.Text == null || txbInfoDate.Text == string.Empty)
                res = false;
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
    }
}
