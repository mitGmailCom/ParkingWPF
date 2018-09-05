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
    /// Логика взаимодействия для AddClient.xaml
    /// </summary>
    public partial class AddClient : Window
    {
        public List<string> ListOfStringType; // List for save string's type
        public List<string> ListOfIntType; // List for save int's type
        public List<string> ListOfDateType; // List for save dateType's type


        public AddClient()
        {
            InitializeComponent();
            Loaded += AddClient_Loaded;
        }

        private void AddClient_Loaded(object sender, RoutedEventArgs e)
        {
            ListOfStringType = new List<string>() { nameof(txbAddClientLastName), nameof(txbAddClientFirstName), nameof(txbAddClientMidleName), nameof(txbAddClientAdress) };
            ListOfIntType = new List<string>() { nameof(txbAddClientPhone) };
            ListOfDateType = new List<string>();
        }


        /// <summary>
        /// Add Car toDatabase
        /// </summary>
        private void AddClientToDB()
        {
            Client newClient = new Client();
            newClient.LastName = txbAddClientLastName.Text;
            newClient.FirstName = txbAddClientFirstName.Text;
            newClient.MidleName = txbAddClientMidleName.Text;
            newClient.Phone = Int32.Parse(txbAddClientPhone.Text);
            newClient.Adress = txbAddClientAdress.Text;
            using (ParkingContext db = new ParkingContext())
            {
                var tempClient = db.Clients.Where(c => c.Phone == newClient.Phone).FirstOrDefault();
                if (tempClient == null)
                {
                    db.Clients.Add(newClient);
                    db.SaveChanges();
                }
                else
                    MessageBox.Show("I can't to add this client. He exist in Database!", "Warrning!");
            }
        }


        /// <summary>
        /// Set focus on textBox
        /// </summary>
        private void SetFocusToTextBox()
        {
            var list = FindElementByType.FindVisualChildren<TextBox>(this);
            foreach (TextBox item in list)
            {
                if (item.Text == null || item.Text == string.Empty)
                {
                    item.Focus();
                    FocusManager.SetFocusedElement(this, item);
                    break;
                }
            }
        }


        /// <summary>
        /// Adding data about Car to TextBoxes
        /// </summary>
        private void AddDataToClickPlace()
        {
            (this.Owner as ClickPlace).txbInfoClientLastName.Text = this.txbAddClientLastName.Text;
            (this.Owner as ClickPlace).txbInfoClientFirstName.Text = this.txbAddClientFirstName.Text;
            (this.Owner as ClickPlace).txbInfoPhone.Text = this.txbAddClientPhone.Text;
        }


        /// <summary>
        /// Check on adding to DataBase
        /// </summary>
        /// <returns></returns>
        private bool AddClientInGeneral()
        {
            // проверка на ввод
            if (txbAddClientLastName.Text == null || txbAddClientFirstName.Text == null || txbAddClientMidleName.Text == null || txbAddClientPhone == null
                 || txbAddClientAdress == null || txbAddClientLastName.Text == string.Empty || txbAddClientFirstName.Text == string.Empty || txbAddClientMidleName.Text == string.Empty
                 || txbAddClientPhone.Text == string.Empty || txbAddClientAdress.Text == string.Empty)
            {
                MessageBox.Show("Please input values all fields!", "Error");
                SetFocusToTextBox();
                CheckFieldsByType.CheckFieldsByTypeMethod(ListOfIntType, ListOfDateType, ListOfStringType, this);
                return false;
            }
            else
            {
                //SetFocusToTextBox();
                if (CheckFieldsByType.CheckFieldsByTypeMethod(ListOfIntType, ListOfDateType, ListOfStringType, this))
                    AddClientToDB();
                return true;
            }
        }


        // Click on AddCar
        private void btnAddClient_Click(object sender, RoutedEventArgs e)
        {
            if (AddClientInGeneral())
            {
                if (this.Owner is ClickPlace)
                {
                    AddDataToClickPlace();
                    if ((this.Owner as ClickPlace).CheckAllFieldsClickPlace())
                        (this.Owner as ClickPlace).btnSaveToPlace.IsEnabled = true;
                    this.Close();
                }
            }
        }


        // Cancel process on adding
        private void btnCancelAddingClient_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
