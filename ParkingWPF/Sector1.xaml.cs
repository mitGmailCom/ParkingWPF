﻿using System;
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
            ClickPlace clickPlace = new ClickPlace();
            clickPlace.SenderPlace = Int32.Parse((sender as Button).Content.ToString());
            clickPlace.Show();
        }
    }
}