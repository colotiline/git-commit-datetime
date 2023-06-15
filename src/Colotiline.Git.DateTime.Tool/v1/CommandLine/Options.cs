using CommandLine;

namespace Colotiline.Git.DateTime.Tool.v1;

public sealed class Options
{
    [
        Option
        (
            'd', 
            "date", 
            Required = false, 
            HelpText = 
                "Sets the date (yyyy-MM-dd)."
                + " The current date will be used when omitted."
        )
    ]
    public string Date { get; init; } = string.Empty;

    [
        Option
        (
            't', 
            "time", 
            Required = false,
            HelpText = 
                "Sets the time (HH:mm). Seconds are always zero."
                + " +8 hours will be used when omitted."
        )
    ]
    
    public string Time { get; init; } = string.Empty;

    [
        Option
        (
            'm',
            "message",
            Required = true,
            HelpText = "Sets the commit message."
        )
    ]
    public string Message { get; init; } = string.Empty;
}