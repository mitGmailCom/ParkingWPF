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
    /// Логика взаимодействия для Sector3.xaml
    /// </summary>
    public partial class Sector3 : Window
    {
        public Sector3()
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


        // Delete
        //private void Window_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    (this.Owner as MainWindow).ListButtons.ForEach(it => it.BorderBrush = null);
        //    (this.Owner as MainWindow).ListButtons.ForEach(it => it.BorderThickness = new Thickness(0.5));
        //}

        //private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        //{
        //    (this.Owner as MainWindow).ListButtons.ForEach(it => it.BorderBrush = Brushes.Black);
        //    (this.Owner as MainWindow).ListButtons.ForEach(it => it.BorderThickness = new Thickness(0.5));
        //}

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
