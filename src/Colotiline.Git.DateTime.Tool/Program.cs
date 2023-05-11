using Colotiline.Git.DateTime.Tool.v1;
using Colotiline.Git.DateTime.Tool.v1.Configurations.v1;
using Colotiline.Git.DateTime.Tool.v1.Git;
using Colotiline.Git.DateTime.Tool.v1.IO;
using Colotiline.Git.DateTime.Tool.v1.Readers;
using CommandLine;

namespace Colotiline.Git.DateTime.Tool;

public static class Program
{
    public static void Main(string[] args)
    {
        Parser
        .Default
        .ParseArguments<Options>(args)
        .WithParsed
        (
            _ => 
            {
                var changes = GitTools.GetChanges();

                if (!changes.Any())
                {
                    Logger.Loaded.Information("No changes.");
                    return;
                }

                var dateTime = DateTimeReader.Read(_.Date, _.Time);

                Logger.Loaded.Information("Setting @{dateTime}.", dateTime);

                Files.ModifyDates
                (
                    changes.Select(_ => _.FilePath).ToArray(), 
                    dateTime
                );

                GitTools.Commit(changes, _.Message, dateTime);

                Logger.Loaded.Information("Finished.");
            }
        )
        .WithNotParsed
        (
            _ => Logger.Loaded.Information
            (
                "Can't parse commands. Details: {@Errors}", 
                _
            )
        );
    }
}