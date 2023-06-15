using System.Globalization;

namespace Colotiline.Git.DateTime.Tool.v1.Readers;

public static class DateTimeReader
{
    public static System.DateTime Read(string date, string time)
    {
        

        var dateToSet = 
            string.IsNullOrEmpty(date) 
            ? System.DateTime.UtcNow
            : System.DateTime.ParseExact
            (
                date, 
                "yyyy-MM-dd", 
                CultureInfo.InvariantCulture
            );

        if (string.IsNullOrEmpty(time))
        {
            return dateToSet.AddHours(8);
        }

        var timeToSet = 
            System.DateTime.ParseExact
            (
                time,
                "HH:mm",
                CultureInfo.InvariantCulture
            );

        return 
            dateToSet
            .Date
            .AddHours(timeToSet.Hour)
            .AddMinutes(timeToSet.Minute);
    }
}