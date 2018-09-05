using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ParkingWPF
{
    public static class CheckFieldsByType
    {
        /// <summary>
        /// Check which collection contains the item
        /// </summary>
        /// <param name="ListOfIntType"></param>
        /// <param name="ListOfDateType"></param>
        /// <param name="ListOfStringType"></param>
        /// <param name="depObj - the item to find"></param>
        /// <returns></returns>
        public static bool CheckFieldsByTypeMethod(List<string> ListOfIntType, List<string> ListOfDateType, List<string> ListOfStringType, DependencyObject depObj)
        {
            bool result = false;
            var list = FindElementByType.FindVisualChildren<TextBox>(depObj);
            int tempNumberCar = 0;
            DateTime tempDate;
            foreach (TextBox item in list)
            {
                var res = ListOfIntType.Where(e => e == item.Name).FirstOrDefault();
                if (res != null)
                {
                    bool isNumber = Int32.TryParse(item.Text, out tempNumberCar);
                    if (isNumber)
                        result = true;
                    else
                    {
                        result = false;
                        break;
                    }
                }
                res = ListOfDateType.Where(e => e == item.Name).FirstOrDefault();
                if (res != null)
                {
                    bool isDate = DateTime.TryParse(res, out tempDate);
                    if (isDate)
                        result = true;
                    else
                    {
                        result = false;
                        break;
                    }
                }
                res = ListOfStringType.Where(e => e == item.Name).FirstOrDefault();
                if (res != null)
                    result = true;
            }
            return result;
        }
    }
}
