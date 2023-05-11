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
                "Date for commit and non-commited files (yyyy-MM-dd)."
                + " When omitted the current date will be used."
        )
    ]
    public string Date { get; init; } = string.Empty;

    [
        Option
        (
            't', 
            "time", 
            Required = true,
            HelpText = 
                "Time for commit and non-commited files (HH:mm). "
                + " Seconds are always zero."
        )
    ]
    
    public string Time { get; init; } = string.Empty;

    [
        Option
        (
            'm',
            "message",
            Required = true,
            HelpText = "Commit message."
        )
    ]
    public string Message { get; init; } = string.Empty;
}