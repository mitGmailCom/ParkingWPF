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

        private void ClearValuesInBtn()
        {
            btnAddCar.IsEnabled = false;
            btnEditeInfo.IsEnabled = false;
            btnGoAway.IsEnabled = false;
        }

        private void CaseCheckedCar()
        {
            btnAddCar.IsEnabled = false;
            btnEditeInfo.IsEnabled = true;
            btnGoAway.IsEnabled = true;
        }

        private void CaseNotCheckedCar()
        {
            btnAddCar.IsEnabled = true;
            btnEditeInfo.IsEnabled = false;
            btnGoAway.IsEnabled = false;
        }


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
    }
}
