using Xunit;

namespace Colotiline.Git.DateTime.Tool.v1.IO;

public sealed class FilesTests
{
    [Fact]
    public void ModifyDates_New_Ok()
    {
        var testFilesPath = Path.Combine
        (
            AppDomain.CurrentDomain.BaseDirectory,
            "TestGitRepository"
        );

        if (Directory.Exists(testFilesPath))
        {
            Directory.Delete(testFilesPath, true);
        }

        Directory.CreateDirectory(testFilesPath);
        Directory.SetCurrentDirectory(testFilesPath);

        var fileName = "temp.txt";
        var filePath = Path.Combine(testFilesPath, fileName);

        using var textFile = File.CreateText(filePath);

        textFile.WriteLine("Hi!");
        textFile.Flush();

        var fileCreationTime = File.GetCreationTimeUtc(filePath);
        var fileWriteTime = File.GetLastWriteTimeUtc(filePath);
        var fileAccessTime = File.GetLastAccessTimeUtc(filePath);

        var date = new System.DateTime(1990, 5, 10);

        Files.ModifyDates(new [] { filePath }, date);

        var newFileCreationTime = File.GetCreationTimeUtc(filePath);
        var newFileWriteTime = File.GetLastWriteTimeUtc(filePath);
        var newFileAccessTime = File.GetLastAccessTimeUtc(filePath);

        Assert.True(newFileCreationTime < fileCreationTime);
        Assert.True(newFileWriteTime < fileWriteTime);
        Assert.True(newFileAccessTime < fileAccessTime);

        Assert.Equal(date, newFileCreationTime);
        Assert.Equal(date, newFileWriteTime);
        Assert.Equal(date, newFileAccessTime);
    }
}