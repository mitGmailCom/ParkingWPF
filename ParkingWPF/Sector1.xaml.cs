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

        private void btnPlace4_Click(object sender, RoutedEventArgs e)
        {
            (this.Owner as MainWindow).ListButtons.ForEach(it => it.BorderBrush = Brushes.Black);
            (this.Owner as MainWindow).ListButtons.ForEach(it => it.BorderThickness = new Thickness(0.5));
            ClickPlace clickPlace = new ClickPlace();
            clickPlace.Owner = this;
            clickPlace.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            clickPlace.SenderPlace = Int32.Parse((sender as Button).Content.ToString());
            clickPlace.ShowDialog();
        }

        private void Window_LostFocus(object sender, RoutedEventArgs e)
        {
            (this.Owner as MainWindow).ListButtons.ForEach(it => it.BorderBrush = null);
            (this.Owner as MainWindow).ListButtons.ForEach(it => it.BorderThickness = new Thickness(0.5));
        }

        private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            (this.Owner as MainWindow).ListButtons.ForEach(it => it.BorderBrush = Brushes.Black);
            (this.Owner as MainWindow).ListButtons.ForEach(it => it.BorderThickness = new Thickness(0.5));
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }
    }
}
