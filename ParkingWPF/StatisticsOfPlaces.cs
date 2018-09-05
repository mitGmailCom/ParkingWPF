using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingWPF
{
    public static class StatisticsOfPlaces
    {
        public static List<int> ListPlaces = new List<int>(); // List of places
        public static int PlaceNotFreeSector1 { get; set; } // number of not free places in sector1
        public static int PlaceNotFreeSector2 { get; set; } // number of not free places in sector2
        public static int PlaceNotFreeSector3 { get; set; } // number of not free places in sector3
        public static int PlaceSector1 { get; set; } = 21; // number of places in sector1
        public static int PlaceSector2 { get; set; } = 24; // number of places in sector2
        public static int PlaceSector3 { get; set; } = 21; // number of places in sector3
        private static MainWindow copyMainWindow = new MainWindow();


        /// <summary>
        /// Calculate the number of free places in each sectors
        /// </summary>
        public static void StatisticOfPlacesLoad()
        {
            using (ParkingContext db = new ParkingContext())
            {
                ListPlaces = db.BalanceParking.Select(pl => pl.Place).ToList();
                for (int i = 0; i < ListPlaces.Count; i++)
                {
                    if (ListPlaces[i] > 0 & ListPlaces[i] < 22)
                        PlaceNotFreeSector1++;

                    if (ListPlaces[i] > 21 & ListPlaces[i] < 46)
                        PlaceNotFreeSector2++;

                    if (ListPlaces[i] > 45 & ListPlaces[i] < 67)
                        PlaceNotFreeSector3++;
                }
            }
        }

        /// <summary>
        /// Update data in each sector
        /// </summary>
        /// <param name="place - place with which some actions were carried out"></param>
        /// <param name="symb - sign for adding or subtracting space"></param>
        public static void UpdateStatisticsPlaces(int place, char symb)
        {
            if (symb == '+')
            {
                if (place > 0 & place < 22)
                    PlaceNotFreeSector1++;

                if (place > 21 & place < 46)
                    PlaceNotFreeSector2++;

                if (place > 45 & place < 67)
                    PlaceNotFreeSector3++;
            }
            if (symb == '-')
            {
                if (place > 0 & place < 22)
                    PlaceNotFreeSector1--;

                if (place > 21 & place < 46)
                    PlaceNotFreeSector2--;

                if (place > 45 & place < 67)
                    PlaceNotFreeSector3--;
            }
        }

        /// <summary>
        /// Show data about places in each sector
        /// </summary>
        /// <param name="mainWind"></param>
        public static void ShowStatisticsInMainWind(MainWindow mainWind)
        {
            if (copyMainWindow.Tag == null)
                copyMainWindow = mainWind;
            ShowStatisticsInMainWind();
            if (copyMainWindow.Tag == null)
                copyMainWindow.Tag = 1;
        }


        /// <summary>
        /// Insert data about places in TexBoxes
        /// </summary>
        public static void ShowStatisticsInMainWind()
        {
            copyMainWindow.txBlNotFreePlacesSector1.Text = StatisticsOfPlaces.PlaceNotFreeSector1.ToString();
            copyMainWindow.txBlNotFreePlacesSector2.Text = StatisticsOfPlaces.PlaceNotFreeSector2.ToString();
            copyMainWindow.txBlNotFreePlacesSector3.Text = StatisticsOfPlaces.PlaceNotFreeSector3.ToString();
            copyMainWindow.txBlFreePlacesSector1.Text = (StatisticsOfPlaces.PlaceSector1 - StatisticsOfPlaces.PlaceNotFreeSector1).ToString();
            copyMainWindow.txBlFreePlacesSector2.Text = (StatisticsOfPlaces.PlaceSector2 - StatisticsOfPlaces.PlaceNotFreeSector2).ToString();
            copyMainWindow.txBlFreePlacesSector3.Text = (StatisticsOfPlaces.PlaceSector3 - StatisticsOfPlaces.PlaceNotFreeSector3).ToString();
            copyMainWindow.txBlPlacesSector1.Text = StatisticsOfPlaces.PlaceSector1.ToString();
            copyMainWindow.txBlPlacesSector2.Text = StatisticsOfPlaces.PlaceSector2.ToString();
            copyMainWindow.txBlPlacesSector3.Text = StatisticsOfPlaces.PlaceSector3.ToString();
        }
    }
}
