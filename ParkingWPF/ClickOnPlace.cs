using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ParkingWPF
{
    public static class ClickOnPlace
    {
        public static void ClickOnAnyPlace(object sender, RoutedEventArgs e, MainWindow depObj)
        {
            DefaultSettingsForButtons(depObj);
            ClickPlace clickPlace = new ClickPlace();
            clickPlace.Owner = depObj;
            clickPlace.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            clickPlace.SenderPlace = Int32.Parse((sender as Button).Content.ToString());
            clickPlace.ShowDialog();
        }

        public static void DefaultSettingsForButtons(MainWindow depObj)
        {
            depObj.ListButtons.ForEach(it => it.BorderBrush = Brushes.Black);
            depObj.ListButtons.ForEach(it => it.BorderThickness = new Thickness(0.7));
        }
    }
}
