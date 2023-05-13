using Serilog;
using Serilog.Debugging;

namespace Colotiline.Git.DateTime.Tool.v1.Configurations.v1;

public static class Logger
{
    static Logger()
    {
        SelfLog.Enable(Console.Error);

        Log.Logger =  
            new LoggerConfiguration()
            .ReadFrom.Configuration(Configuration.Loaded)
            .CreateLogger();

        Loaded = Log.Logger;
    }

    public static ILogger Loaded { get; }
}