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
    /// Логика взаимодействия для SelectClient.xaml
    /// </summary>
    public partial class SelectClient : Window
    {
        public SelectClient()
        {
            InitializeComponent();
            Loaded += SelectClient_Loaded;
        }

        private void SelectClient_Loaded(object sender, RoutedEventArgs e)
        {
            using (ParkingContext db = new ParkingContext())
            {
                //var ListCars = db.Cars.Select(i => new { Manufacture = i.Manufacture, Model = i.Model, Number = i.NumberCar, Id = i.Id }).ToList();
                var ListClients = db.Clients.OrderBy(c => c.LastName).OrderBy(cc => cc.FirstName).ToList();
                DataGridClients.ItemsSource = ListClients;
            }
        }

        // Insert data abot Client in ClickPlace window
        private void DataGridClients_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (sender is DataGrid)
            {
                Client selectedClient = (Client)(sender as DataGrid).SelectedItem;
                (this.Owner as ClickPlace).txbInfoClientLastName.Text = selectedClient.LastName;
                (this.Owner as ClickPlace).txbInfoClientFirstName.Text = selectedClient.FirstName;
                (this.Owner as ClickPlace).txbInfoPhone.Text = selectedClient.Phone.ToString();
                (this.Owner as ClickPlace).IdClient = selectedClient.Id;
                if ((this.Owner as ClickPlace).CheckAllFieldsClickPlace())
                    (this.Owner as ClickPlace).btnSaveToPlace.IsEnabled = true;
                this.Close();
            }
        }
    }
}
