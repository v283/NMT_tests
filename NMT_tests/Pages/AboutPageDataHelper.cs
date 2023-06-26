using Microsoft.Maui.Graphics;
using NMT_tests.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMT_tests.Pages
{
    
    public class AboutPageDataHelper
    {
        public static Color myGreen = Color.FromHex("#3fff00"); 
        public static Color white = Color.FromHex("#ffffff");
        public static Color myDarkGreen = Color.FromHex("#228b22");
        public static Color myOrange = Color.FromHex("#ed820e");

        public static WeekModel MyWeek = new();
            
        public static void FindOutColorAndHeigh(string day, out Color c, out double heigh)
        {
            switch (day)
            {
                case "Low":
                    c = myOrange;
                    heigh = 24.0;
                    break;
                case "Middle":
                    c = myDarkGreen;
                    heigh = 54.0;
                    break;
                case "High":
                    c = myGreen;
                    heigh = 84.0;
                    break;
                default:
                    heigh = 0.0;
                    c = white;
                    break;
            }
        }

        public static void CheckWeek()
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Monday )
            {
                //it's work normal
                DbProvider.database.Execute("UPDATE MyWeek SET Tuesday = '' ,  Wednesday = '' , Thursday = '', Friday = '', Saturday = '', Sunday = ''  WHERE Id = 1");

            }
            
        }

        public static void SetWeek()
        {
            MyWeek = DbProvider.GetWeekFromDbTable("MyWeek")[0];
        }

        public static void CheckCurrentDay()
        {
            if (DateTime.Now.DayOfWeek.ToString().ToUpper() != DbProvider.GetCurrentDay())
            {
                DbProvider.SetDayTime(0);
                DbProvider.SetCurrentDay(DateTime.Now.DayOfWeek.ToString().ToUpper());
            }

        }

        public static void WriteDay()
        {
            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    if (TimeAccountant.UserTime >= 1 && TimeAccountant.UserTime < 20)
                    {
                        DbProvider.database.Execute("UPDATE MyWeek SET Monday = 'Low'  WHERE Id = 1");                       
                    }
                    else if (TimeAccountant.UserTime >= 20 && TimeAccountant.UserTime < 40)
                    {
                        DbProvider.database.Execute("UPDATE MyWeek SET Monday = 'Middle' WHERE Id = 1");
                    }
                    else if (TimeAccountant.UserTime >= 40)
                    {
                        DbProvider.database.Execute("UPDATE MyWeek SET Monday = 'High' WHERE Id = 1");
                    }
                    break;
                case DayOfWeek.Tuesday:
                    if (TimeAccountant.UserTime >= 1 && TimeAccountant.UserTime < 20)
                    {
                        DbProvider.database.Execute("UPDATE MyWeek SET Tuesday = 'Low'  WHERE Id = 1");
                    }
                    else if (TimeAccountant.UserTime >= 20 && TimeAccountant.UserTime < 40)
                    {
                        DbProvider.database.Execute("UPDATE MyWeek SET Tuesday = 'Middle' WHERE Id = 1");
                    }
                    else if (TimeAccountant.UserTime >= 40)
                    {
                        DbProvider.database.Execute("UPDATE MyWeek SET Tuesday = 'High' WHERE Id = 1");
                    }
                    break;
                case DayOfWeek.Wednesday:
                    if (TimeAccountant.UserTime >= 1 && TimeAccountant.UserTime < 20)
                    {
                        DbProvider.database.Execute("UPDATE MyWeek SET Wednesday = 'Low'  WHERE Id = 1");
                    }
                    else if (TimeAccountant.UserTime >= 20 && TimeAccountant.UserTime < 40)
                    {
                        DbProvider.database.Execute("UPDATE MyWeek SET Wednesday = 'Middle' WHERE Id = 1");
                    }
                    else if (TimeAccountant.UserTime >= 40)
                    {
                        DbProvider.database.Execute("UPDATE MyWeek SET Wednesday = 'High' WHERE Id = 1");
                    }
                    break;
                case DayOfWeek.Thursday:
                    if (TimeAccountant.UserTime >= 1 && TimeAccountant.UserTime < 20)
                    {
                        DbProvider.database.Execute("UPDATE MyWeek SET Thursday = 'Low'  WHERE Id = 1");
                    }
                    else if (TimeAccountant.UserTime >= 20 && TimeAccountant.UserTime < 40)
                    {
                        DbProvider.database.Execute("UPDATE MyWeek SET Thursday = 'Middle' WHERE Id = 1");
                    }
                    else if (TimeAccountant.UserTime >= 40)
                    {
                        DbProvider.database.Execute("UPDATE MyWeek SET Thursday = 'High' WHERE Id = 1");
                    }
                    break;
                case DayOfWeek.Friday:
                    if (TimeAccountant.UserTime >= 1 && TimeAccountant.UserTime < 20)
                    {
                        DbProvider.database.Execute("UPDATE MyWeek SET Friday = 'Low'  WHERE Id = 1");
                    }
                    else if (TimeAccountant.UserTime >= 20 && TimeAccountant.UserTime < 40)
                    {
                        DbProvider.database.Execute("UPDATE MyWeek SET Friday = 'Middle' WHERE Id = 1");
                    }
                    else if (TimeAccountant.UserTime >= 40)
                    {
                        DbProvider.database.Execute("UPDATE MyWeek SET Friday = 'High' WHERE Id = 1");
                    }
                    break;
                case DayOfWeek.Saturday:
                    if (TimeAccountant.UserTime >= 1 && TimeAccountant.UserTime < 20)
                    {
                        DbProvider.database.Execute("UPDATE MyWeek SET Saturday = 'Low'  WHERE Id = 1");
                    }
                    else if (TimeAccountant.UserTime >= 20 && TimeAccountant.UserTime < 40)
                    {
                        DbProvider.database.Execute("UPDATE MyWeek SET Saturday = 'Middle' WHERE Id = 1");
                    }
                    else if (TimeAccountant.UserTime >= 40)
                    {
                        DbProvider.database.Execute("UPDATE MyWeek SET Saturday = 'High' WHERE Id = 1");
                    }
                    break;
                case DayOfWeek.Sunday:
                    if (TimeAccountant.UserTime >= 1 && TimeAccountant.UserTime < 20)
                    {
                        DbProvider.database.Execute("UPDATE MyWeek SET Sunday = 'Low'  WHERE Id = 1");
                    }
                    else if (TimeAccountant.UserTime >= 20 && TimeAccountant.UserTime < 40)
                    {
                        DbProvider.database.Execute("UPDATE MyWeek SET Sunday = 'Middle' WHERE Id = 1");
                    }
                    else if (TimeAccountant.UserTime >= 40)
                    {
                        DbProvider.database.Execute("UPDATE MyWeek SET Sunday = 'High' WHERE Id = 1");
                    }
                    break;

                default:
                    break;
            }
        }

    }
}
