using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FASClient
{
    class Constant
    {
        public const string Student = "Student";
        public const string Staff = "Staff/Faculty";
        public const string Faculty = "Staff/Faculty";
        public const string Visitor = "Visitors";
        public const string Resident = "Residents";
        public const string Alumni = "Alumni";
        public const string T6 = "T6";
        public const string T7 = "T7";
        public const string T8 = "T8";

        public static string getCardUserGID(string section)
        {
            switch (section)
            {
                case Constant.Student:
                    return "12";
                case Constant.Staff:
                    return "22";
                case Constant.Resident:
                    return "32";
                case Constant.Visitor:
                    return "42";
                case Constant.Alumni:
                    return "52";
                case Constant.T6:
                    return "62";
                case Constant.T7:
                    return "72";
                case Constant.T8:
                    return "82";
                default:
                    return "0";
            }
        }
        public static string weekdays(string day)
        {
            switch (day)
            {
                case "1":
                    return "Sunday";                    
                case "2":
                    return "Monday";
                case "3":
                    return "Tuesday";
                case "4":
                    return "Wednesday";
                case "5":
                    return "Thursday";
                case "6":
                    return "Friday";
                case "7":
                    return "Saturday";

                //if no case value is matched
                default:
                    return "";
                    
            }


        }
        public static string getFingerUserGID(string section)
        {
            switch (section)
            {
                case Constant.Student:
                    return "11";
                case Constant.Staff:
                    return "21";
                case Constant.Resident:
                    return "31";
                case Constant.Visitor:
                    return "41";
                case Constant.Alumni:
                    return "51";
                case Constant.T6:
                    return "61";
                case Constant.T7:
                    return "71";
                case Constant.T8:
                    return "81";
                default:
                    return "0";
            }
        }
    }
}
