using System.Globalization;
using System.Text;

namespace Tebnegar_Common.DateTimeTools;

public static class DateTimeTools
{
    public static int CalculateAge(DateTime birthdate)
    {
        // Save today's date.
        var today = DateTime.Today;
        // Calculate the age.
        var age = today.Year - birthdate.Year;
        // Go back to the year the person was born in case of a leap year
        if (birthdate > today.AddYears(-age)) age--;

        return age;
    }
    
    public static string CalculateBirthDay(DateTime? birthday)
    {
        if (!birthday.HasValue)
        {
            return $"0 سال 0 ماه";
        }

        var today = DateTime.Today;

        var months = today.Month - birthday.Value.Month;
        var years = today.Year - birthday.Value.Year;

        if (today.Day < birthday.Value.Day)
        {
            months--;
        }

        if (months < 0)
        {
            years--;
            months += 12;
        }


        return
            $"{years} سال, {months} ماه";
    }
    public static string Miladi2Shamsi(string mydate)
    {
        try
        {
            var date = DateTime.Parse(mydate);
            var pc = new PersianCalendar();
            var sb = new StringBuilder();
            sb.Append(pc.GetYear(date).ToString("0000"));
            sb.Append("/");
            sb.Append(pc.GetMonth(date).ToString("00"));
            sb.Append("/");
            sb.Append(pc.GetDayOfMonth(date).ToString("00"));
            return sb.ToString();
        }
        catch
        {
            return "0000/00/00";
        }
    }
    public static DateTime Shamsi2Miladi(string date)
    {
        var year = int.Parse(date[..4]);
        var month = int.Parse(date.Substring(5, 2));
        var day = int.Parse(date.Substring(8, 2));
        var p = new PersianCalendar();
        var resultDate = p.ToDateTime(year, month, day, 0, 0, 0, 0);
        return resultDate;
    }
    public static string DayName(DateTime d)
    {
        var dname = d.DayOfWeek;
        return dname switch
        {
            DayOfWeek.Sunday => "یکشنبه",
            DayOfWeek.Monday => "دوشنبه",
            DayOfWeek.Tuesday => "سه شنبه",
            DayOfWeek.Wednesday => "چهارشنبه",
            DayOfWeek.Thursday => "پنجشنبه",
            DayOfWeek.Friday => "جمعه",
            DayOfWeek.Saturday => "شنبه",
            _ => ""
        };
    }
}