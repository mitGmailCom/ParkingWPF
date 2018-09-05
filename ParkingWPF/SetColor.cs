using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace ParkingWPF
{
    public static class SetColor
    {
        /// <summary>
        /// Set color shceme for buttons
        /// </summary>
        /// <param name="ListButtons - list with Buttons"></param>
        public static void SetColorForPlaces(List<Button> ListButtons)
        {
            List<int> Places = new List<int>();
            using (ParkingContext db = new ParkingContext())
            {
                Places = db.BalanceParking.Select(pl => pl.Place).ToList();
                List<int> tt = new List<int>();
                for (int i = 0; i < ListButtons.Count; i++)
                {
                    tt.Add(Int32.Parse(ListButtons[i].Content.ToString()));
                }
                IEnumerable<int> unique1 = tt.Except(Places);
                foreach (int item in unique1)
                {
                    ListButtons[item - 1].Background = Brushes.White;
                }
                foreach (int item in Places)
                {
                    ListButtons[item - 1].Background = Brushes.Red;
                }
            }
        }
    }
}
