using System.Globalization;

namespace Colotiline.Git.DateTime.Tool.v1.Readers;

public static class DateTimeReader
{
    public static System.DateTime Read(string date, string time)
    {
        var dateToSet = 
            string.IsNullOrEmpty(date) 
            ? System.DateTime.UtcNow.Date
            : System.DateTime.ParseExact
            (
                date, 
                "yyyy-MM-dd", 
                CultureInfo.InvariantCulture
            );

        var timeToSet = System.DateTime.ParseExact
        (
            time,
             "HH:mm",
              CultureInfo.InvariantCulture
        );

        return dateToSet.AddHours(timeToSet.Hour).AddMinutes(timeToSet.Minute);
    }
}