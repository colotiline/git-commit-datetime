using Microsoft.Extensions.Configuration;

namespace Colotiline.Git.DateTime.Tool.v1;

public static class Configuration
{
    static Configuration()
    {
        Loaded = 
            new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile
            (
                "appsettings.json", 
                optional: false,
                reloadOnChange: false
            )
            .Build();
    }

    public static IConfiguration Loaded { get; }
}