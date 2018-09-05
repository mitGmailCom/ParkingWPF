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
    /// Логика взаимодействия для AddCar.xaml
    /// </summary>
    public partial class AddCar : Window
    {
        public List<string> ListOfStringType; // List for save string's type
        public List<string> ListOfIntType; // List for save int's type
        public List<string> ListOfDateType; // List for save dateType's type

        public AddCar()
        {
            InitializeComponent();
            Loaded += AddCar_Loaded;
        }


        private void AddCar_Loaded(object sender, RoutedEventArgs e)
        {
            ListOfStringType = new List<string>() { nameof(txbAddManufacture), nameof(txbAddModel), nameof(txbAddColorCar), nameof(txbAddNumberCar) };
            ListOfIntType = new List<string>();
            ListOfDateType = new List<string>();
        }


        // Cancel process on adding
        private void btnCancelAddingCar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        // Click on AddCar
        private void btnAddCar_Click(object sender, RoutedEventArgs e)
        {
            if (AddCarInGeneral())
            {
                if (this.Owner is ClickPlace)
                {
                    AddDataToClickPlace();
                    if ((this.Owner as ClickPlace).CheckAllFieldsClickPlace())
                        (this.Owner as ClickPlace).btnSaveToPlace.IsEnabled = true;
                }
            }
        }


        /// <summary>
        /// Check on adding to DataBase
        /// </summary>
        /// <returns></returns>
        private bool AddCarInGeneral()
        {
            // check for input
            if (txbAddManufacture.Text == null || txbAddModel.Text == null || txbAddColorCar.Text == null || txbAddNumberCar == null ||
                txbAddManufacture.Text == string.Empty || txbAddModel.Text == string.Empty || txbAddColorCar.Text == string.Empty || txbAddNumberCar.Text == string.Empty)
            {
                MessageBox.Show("Please input values into all fields!", "Error");
                SetFocusToTextBox();
                CheckFieldsByType.CheckFieldsByTypeMethod(ListOfIntType, ListOfDateType, ListOfStringType, this);
                return false;
            }
            else
            {
                //SetFocusToTextBox();
                if (CheckFieldsByType.CheckFieldsByTypeMethod(ListOfIntType, ListOfDateType, ListOfStringType, this))
                    AddCarToDB();
                return true;
            }
        }


        /// <summary>
        /// Add Car toDatabase
        /// </summary>
        private void AddCarToDB()
        {
            Car newCar = new Car();
            newCar.Manufacture = txbAddManufacture.Text;
            newCar.Model = txbAddModel.Text;
            newCar.Color = txbAddColorCar.Text;
            newCar.NumberCar = txbAddNumberCar.Text;
            using (ParkingContext db = new ParkingContext())
            {
                var tempCar = db.Cars.Where(c => c.NumberCar == newCar.NumberCar).FirstOrDefault();
                if (tempCar == null)
                {
                    db.Cars.Add(newCar);
                    db.SaveChanges();
                }
                else
                    MessageBox.Show("I can't to add this car. It exists in Database!", "Warrning!");
            }
        }


        /// <summary>
        /// Adding data about Car to TextBoxes
        /// </summary>
        private void AddDataToClickPlace()
        {
            (this.Owner as ClickPlace).txbInfoManufacture.Text = this.txbAddManufacture.Text;
            (this.Owner as ClickPlace).txbInfoModel.Text = this.txbAddModel.Text;
            (this.Owner as ClickPlace).txbInfoColor.Text = this.txbAddColorCar.Text;
            (this.Owner as ClickPlace).txbInfoNumber.Text = this.txbAddNumberCar.Text;
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

    }
}
