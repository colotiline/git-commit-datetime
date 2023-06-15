using Xunit;

namespace Colotiline.Git.DateTime.Tool.v1.Readers;

public sealed class DateTimeReaderTests
{
    [Fact]
    public void Read_DateTime_Ok()
    {
        var date = "1990-05-10";
        var time = "23:12";

        var dateTime = DateTimeReader.Read(date, time);

        Assert.Equal(1990, dateTime.Year);
        Assert.Equal(5, dateTime.Month);
        Assert.Equal(10, dateTime.Day);
        Assert.Equal(23, dateTime.Hour);
        Assert.Equal(12, dateTime.Minute);
        Assert.Equal(0, dateTime.Second);
    }

    [Fact]
    public void Read_Time_Ok()
    {
        var time = "23:12";
        var now = System.DateTime.UtcNow;

        var dateTime = DateTimeReader.Read(string.Empty, time);

        Assert.Equal(now.Year, dateTime.Year);
        Assert.Equal(now.Month, dateTime.Month);
        Assert.Equal(now.Day, dateTime.Day);
        Assert.Equal(23, dateTime.Hour);
        Assert.Equal(12, dateTime.Minute);
        Assert.Equal(0, dateTime.Second);
    }

    [Fact]
    public void Read_DateTime_Error()
    {
        var date = "1990-05-10";
        var time = "48:12";

        var exception = Record.Exception(() => DateTimeReader.Read(date, time));

        Assert.Equal
        (
            "The DateTime represented by the string '48:12'"
            + " is not supported in calendar"
            + " 'System.Globalization.GregorianCalendar'.", 
            exception.Message
        );
    }

    [Fact]
    public void Read_AllEmpty_Ok()
    {
        var now = System.DateTime.UtcNow;

        var dateTime = DateTimeReader.Read(string.Empty, string.Empty);

        Assert.Equal(now.Year, dateTime.Year);
        Assert.Equal(now.Month, dateTime.Month);
        Assert.Equal(now.Day, dateTime.Day);
        Assert.Equal(now.AddHours(8).Hour, dateTime.Hour);
        Assert.Equal(now.Minute, dateTime.Minute);
        Assert.Equal(now.Second, dateTime.Second);
    }
}
