using System.Globalization;

namespace Common.Application.DateUtil
{
    public static class DateConvertor
    {
        public static DateTime ToMiladi(this string persianDate)
        {
            try
            {
                // عضو اول سال ، عضو دوم ماه ، عضو سوم روز
                //std[0]=سال | std[1]= ماه | std[2]=روز
                string[] std = persianDate.Split("/");

                //تبدیل تاریخ شمسی به میلادی
                return new DateTime(
                    int.Parse(std[0]),//سال
                    int.Parse(std[1]),//ماه
                    int.Parse(std[2]),//روز
                    new PersianCalendar()//نوع تاریخ
                );
            }
            catch
            {
               return DateTime.Now;
            }
        }
        public static string ToPersianTime(this TimeSpan ts)
        {
            return ts.Hours.ToString().PadLeft(2, '0') + ":" + ts.Minutes.ToString().PadLeft(2, '0');
        }
        public static string ToPersianTime(this TimeSpan? ts)
        {
            return ts.HasValue ? ToPersianTime(ts.Value) : "";
        }
        public static string ToPersianDate(this DateTime dateTime)
        {
            PersianCalendar pc = new PersianCalendar();
            try
            {
                return string.Format("{0}/{1}/{2}", pc.GetYear(dateTime).ToString().PadLeft(4, '0'),
                    pc.GetMonth(dateTime).ToString().PadLeft(2, '0'),
                    pc.GetDayOfMonth(dateTime).ToString().PadLeft(2, '0'));
            }
            catch
            {
                return "";
            }
        }
       
        /// <summary>
        /// Sample Format = ds dd ms Y
        /// </summary>
        /// <param name="dateTime">تاریخ میلادی</param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string ToPersianDate(this DateTime dateTime, string format)
        {
            //@DateTime.Now.ToPersianDate("ds dd ms Y")
            PersianCalendar pc = new PersianCalendar();
            try
            {
                string date = format.Replace("Y", pc.GetYear(dateTime).ToString().PadLeft(4, '0'))
                    .Replace("mm", pc.GetMonth(dateTime).ToString())
                    .Replace("MM", pc.GetMonth(dateTime).ToString().PadLeft(2, '0'))
                    .Replace("dd", pc.GetDayOfMonth(dateTime).ToString())
                    .Replace("DD", pc.GetDayOfMonth(dateTime).ToString().PadLeft(2, '0'))
                    .Replace("ds", GetDayOfWeekString((int)pc.GetDayOfWeek(dateTime)).ToString())
                    .Replace("ms", GetMonthString(pc.GetMonth(dateTime)).ToString())
                    ;
                return date;
            }
            catch
            {
                return "";
            }
        }

        private static string GetDayOfWeekString(int day)
        {
            string[] days = new string[] { "یکشنبه", "دوشنبه", "سه شنبه", "چهارشنبه", "پنجشنبه", "جمعه", "شنبه" };
            if (day <= days.Length)
            {
                return days[day];
            }
            return "";
        }
        private static string GetMonthString(int month)
        {
            string[] months = new string[] { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };
            if (month <= months.Length)
            {
                return months[month-1];
            }
            return "";
        }

        public static string ToPersianDateTime(this DateTime dateTime)
        {
            try
            {
                return string.Format("{0}:{1} {2}", dateTime.Hour.ToString().PadLeft(2, '0'),
                    dateTime.Minute.ToString().PadLeft(2, '0'), dateTime.ToPersianDate());
            }
            catch
            {
                return "";
            }
        }
        public static string ToPersianDate(this DateTime? dateTime)
        {
            if (dateTime != null)
                return ToPersianDate(dateTime.Value);
            
            return string.Empty;
        }
        public static string ToPersianDateTime(this DateTime? dateTime)
        {
            if (dateTime != null)
                return ToPersianDateTime(dateTime.Value);
            
            return string.Empty;
        }

        public static DateTime? ToGregorianDateTime(this string persianDate)
        {
            if (string.IsNullOrEmpty(persianDate))
                return null;
            try
            {
                var pc = new PersianCalendar();

                var arrPersianDateTime = persianDate.Split(' ');
                var arrPersianDate = arrPersianDateTime[0].Split('/');
                var arrPersianTime = new string[] { "0", "0", "0" };

                if (arrPersianDateTime.Length == 2)
                {
                    arrPersianTime = arrPersianDateTime[1].Split(':');
                }

                var year = int.Parse(arrPersianDate[0]);
                var month = short.Parse(arrPersianDate[1]);
                var day = short.Parse(arrPersianDate[2]);

                var hour = short.Parse(arrPersianTime[0]);
                var minute = short.Parse(arrPersianTime[1]);
                var second = arrPersianTime.Length == 3 ? short.Parse(arrPersianTime[2]) : 0;

                return pc.ToDateTime(year, month, day, hour, minute, second, 0);
            }
            catch
            {
                return null;
            }
        }

    }
}
