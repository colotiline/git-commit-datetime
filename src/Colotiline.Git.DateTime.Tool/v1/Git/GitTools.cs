using LibGit2Sharp;

namespace Colotiline.Git.DateTime.Tool.v1.Git;

public static class GitTools
{
    public static (string FilePath, FileStatus State)[] GetChanges()
    {
        using var gitRepository = new Repository
        (
            Path.Combine(Environment.CurrentDirectory, ".git")
        );

        return 
            gitRepository
            .RetrieveStatus
            (
                new StatusOptions
                {
                    ExcludeSubmodules = true,
                    IncludeUntracked = true
                }
            )
            .Select(_ => (_.FilePath, _.State))
            .ToArray();
    }

    public static void Commit
    (
        (string FilePath, FileStatus State)[] changes, 
        string message, 
        System.DateTime dateTime
    )
    {
        using var gitRepository = new Repository
        (
            Path.Combine(Environment.CurrentDirectory, ".git")
        );

        foreach (var change in changes)
        {
            gitRepository.Index.Add(change.FilePath);
            gitRepository.Index.Write();
        }

        gitRepository.Commit
        (
            message, 
            gitRepository.Config.BuildSignature(dateTime),
            gitRepository.Config.BuildSignature(dateTime),
            default
        );
    }
}