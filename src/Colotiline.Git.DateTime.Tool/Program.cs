using Colotiline.Git.DateTime.Tool.v1;
using Colotiline.Git.DateTime.Tool.v1.Configurations.v1;
using Colotiline.Git.DateTime.Tool.v1.Git;
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

                

                throw new NotImplementedException();
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