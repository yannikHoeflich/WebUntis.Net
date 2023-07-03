using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace Untis.Net;
internal class UntisTimeConverter {
    public static int ConvertDateToUntis(DateOnly date) {
        return int.Parse(
            date.Year.ToString() +
            (date.Month < 10 ? "0" + date.Month.ToString() : date.Month.ToString()) +
            (date.Day < 10 ? "0" + date.Day.ToString() : date.Day.ToString())
        );
    }
    public static DateOnly ConvertUntisToDate(int UntisDate) {
        string str = UntisDate.ToString();
        int year = int.Parse(str[..4]);
        int month = int.Parse(str.Substring(4, 2));
        int day = int.Parse(str.Substring(6, 2));

        return new DateOnly(year, month, day);
    }


    public static int ConvertTimeToUntis(TimeOnly time) {
        return int.Parse(
            time.Hour.ToString() +
            (time.Minute < 10 ? "0" + time.Minute.ToString() : time.Minute.ToString())
        );
    }
    public static TimeOnly ConvertUntisToTime(int UntisTime) {
        string str = UntisTime.ToString();
        string hour;
        string minute;

        if (str.Length == 3) {
            hour = str[..1];
            minute = str.Substring(1, 2);
        } else {
            hour = str[..2];
            minute = str.Substring(2, 2);
        }

        return new TimeOnly(int.Parse(hour), int.Parse(minute));
    }
}
