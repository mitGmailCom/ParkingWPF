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
    /// Логика взаимодействия для Sector1.xaml
    /// </summary>
    public partial class Sector1 : Window
    {
        public Sector1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Event for click on any button in window Sector
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlace_Click(object sender, RoutedEventArgs e)
        {
            MainWindow tempMainWind = (this.Owner as MainWindow);
            ClickOnPlace.ClickOnAnyPlace(sender, e, tempMainWind);
        }


        /// <summary>
        /// Event for closing window Sector1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }
    }
}
