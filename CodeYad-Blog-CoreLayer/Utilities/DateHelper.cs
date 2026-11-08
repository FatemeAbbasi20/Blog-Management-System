using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYad_Blog_CoreLayer.Utilities
{
    public  static class DateHelper
    {
     public static string ToPersianDate(this DateTime dateTime)
        {
            PersianCalendar pc = new PersianCalendar();
            try
            { 
               return string.Format("{0/{1}/{2}", pc.GetYear(dateTime).ToString().PadLeft(4, '0'),
                 pc.GetMonth(dateTime).ToString().PadLeft(2, '0'),
                 pc.GetDayOfMonth(dateTime).ToString().PadLeft(2, '0'));
               

            }
            catch
            {
                return "";
            }

        }
        public static string ToPersianTime(this DateTime dateTime, string format)
        {
            PersianCalendar pc = new PersianCalendar();
            try
            {
                
                string date = format.Replace("Y", pc.GetYear(dateTime).ToString().PadLeft(4, '0'))
                .Replace("mm", pc.GetMonth(dateTime).ToString())
                .Replace("MM", pc.GetMonth(dateTime).ToString().PadLeft(2, '0'))
                .Replace("dd", pc.GetDayOfMonth(dateTime).ToString())
                .Replace("DD", pc.GetDayOfMonth(dateTime).ToString().PadLeft(2, '0')
                .Replace("ds", GetDayOfWeekString((int)pc.GetDayOfWeek(dateTime)).ToString())
                .Replace("ms", GetMonthString(pc.GetMonth(dateTime)).ToString()));
                return date;
            }
            catch
            {
                return "";
            }
        }

        private static string GetDayOfWeekString(int day)
        {
            string[] days = new string[] { "جمعه", "پنج شنبه", "چهارشنبه", "سه شنیه", "دوشنبه", "یکشنبه", "شنبه" };
            if (day <= days.Length)
                return days[day];
            return "";
        }

        private static string GetMonthString(int month)
        {
            string[] Months = new string[] { "اسفند", "بهمن", "دی", "اذر", "آبان", "مهر", "شهریور", "مرداد", "تیر", "خرداد", "اردیبهشت", "فروردین" };
            if (month <= Months.Length)
                return Months[month-1];
            return "";
        
        }
        public static string GetTimeAgo(this DateTime dateTime)
        {
            var now = DateTime.Now;
            int Year = now.Year - dateTime.Year;
            int Month= now.Month-dateTime.Month;
            int Day= now.Day-dateTime.Day;
            int Hour= now.Hour-dateTime.Hour;
            int Minute= now.Minute-dateTime.Minute;
            int Second= now.Second-dateTime.Second;
            if (Year > 0)
                return $"{Year}سال پیش";
            if (Month > 0)
                return $"{Month}ماه پیش";
            if (Day > 0)
                return $"{Day}روز پیش";
            if (Hour > 0)
                return $"{Hour}ساعت پیش";
            if (Minute > 0)
                return $"{Minute}دقیقه پیش";
            if (Second > 0)
                return $"{Second}ثانیه پیش";
          else
                return "لحظاتی پیش";  
        }

    }
}
