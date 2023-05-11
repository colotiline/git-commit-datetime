using LibGit2Sharp;
using Xunit;

namespace Colotiline.Git.DateTime.Tool.v1.Git;

public sealed class GitToolsTests
{
    private readonly string testGitRepositoryPath;

    public GitToolsTests()
    {
        this.testGitRepositoryPath = Path.Combine
        (
            AppDomain.CurrentDomain.BaseDirectory,
            "TestGitRepository"
        );

        if (Directory.Exists(this.testGitRepositoryPath))
        {
            Directory.Delete(this.testGitRepositoryPath, true);
        }

        Directory.CreateDirectory(this.testGitRepositoryPath);
        Directory.SetCurrentDirectory(this.testGitRepositoryPath);
    }

    [Fact]
    public void GetChanges_New_Ok()
    {
        var repositoryPath = Repository.Init(this.testGitRepositoryPath);

        using var gitRepository = new Repository(repositoryPath);

        var fileName = "temp.txt";
        var filePath = Path.Combine(this.testGitRepositoryPath, fileName);

        using var textFile = File.CreateText(filePath);

        textFile.WriteLine("Hi!");

        textFile.Flush();

        var changes = GitTools.GetChanges();

        Assert.Single(changes);
        Assert.Equal(fileName, changes[0].FilePath);
        Assert.Equal(FileStatus.NewInWorkdir, changes[0].State);
    }

    [Fact]
    public void GetChanges_No_Ok()
    {
        var repositoryPath = Repository.Init(this.testGitRepositoryPath);

        using var gitRepository = new Repository(repositoryPath);

        var changes = GitTools.GetChanges();

        Assert.Empty(changes);
    }

    [Fact]
    public void GetChanges_Changed_Ok()
    {
        var repositoryPath = Repository.Init(this.testGitRepositoryPath);

        using var gitRepository = new Repository(repositoryPath);

        var fileName = "temp.txt";
        var filePath = Path.Combine(this.testGitRepositoryPath, fileName);

        var textFile = File.CreateText(filePath);

        textFile.WriteLine("Hi!");

        textFile.Flush();
        textFile.Close();

        gitRepository.Index.Add(fileName);
        gitRepository.Index.Write();
        gitRepository.Commit
        (
            "Fake commit", 
            gitRepository.Config.BuildSignature(DateTimeOffset.Now),
            gitRepository.Config.BuildSignature(DateTimeOffset.Now),
            default
        );

        var changes = GitTools.GetChanges();

        Assert.Empty(changes);

        var newFileName = "newTemp.txt";
        var newFilePath = Path.Combine(this.testGitRepositoryPath, newFileName);

        using var newTextFile = File.CreateText(newFilePath);

        newTextFile.WriteLine("Hi again!");

        newTextFile.Flush();

        using var streamWriter = new StreamWriter(filePath, true);
        streamWriter.WriteLine("Something new.");
        streamWriter.Flush();

        changes = GitTools.GetChanges();

        Assert.Equal(2, changes.Length);

        Assert.Equal(newFileName, changes[0].FilePath);
        Assert.Equal(FileStatus.NewInWorkdir, changes[0].State);

        Assert.Equal(fileName, changes[1].FilePath);
        Assert.Equal(FileStatus.ModifiedInWorkdir, changes[1].State);
    }
}