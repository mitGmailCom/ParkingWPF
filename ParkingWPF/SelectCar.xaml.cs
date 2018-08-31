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
    /// Логика взаимодействия для SelectCar.xaml
    /// </summary>
    public partial class SelectCar : Window
    {
        public SelectCar()
        {
            InitializeComponent();
            Loaded += SelectCar_Loaded;
        }

        private void SelectCar_Loaded(object sender, RoutedEventArgs e)
        {
            using (ParkingContext db = new ParkingContext())
            {
                //var ListCars = db.Cars.Select(i => new { Manufacture = i.Manufacture, Model = i.Model, Number = i.NumberCar, Id = i.Id }).ToList();
                var ListCars = db.Cars.OrderBy(c => c.Manufacture).ToList();
                DataGridCars.ItemsSource = ListCars;
            }
        }

        private void DataGridCars_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (sender is DataGrid)
            {
                Car selectedCar = (Car)(sender as DataGrid).SelectedItem;
                (this.Owner as ClickPlace).txbInfoManufacture.Text = selectedCar.Manufacture;
                (this.Owner as ClickPlace).txbInfoModel.Text = selectedCar.Model;
                (this.Owner as ClickPlace).txbInfoColor.Text = selectedCar.Color;
                (this.Owner as ClickPlace).txbInfoNumber.Text = selectedCar.NumberCar;
                (this.Owner as ClickPlace).IdCar = selectedCar.Id;
                if ((this.Owner as ClickPlace).CheckAllFieldsClickPlace())
                    (this.Owner as ClickPlace).btnSaveToPlace.IsEnabled = true;
                this.Close();
            }
        }
    }
}
