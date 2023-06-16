namespace Colotiline.Git.DateTime.Tool.v1.IO;

public static class Files
{
    public static void ModifyDates
    (
        string[] filesPaths, 
        System.DateTime fileDateTime
    )
    {
        for (int i = 0; i < filesPaths.Length; i++)
        {
            var filePath = Path.Combine
            (
                Environment.CurrentDirectory, 
                filesPaths[i]
            );

            if (!File.Exists(filePath))
            {
                continue;
            }

            File.SetCreationTimeUtc(filePath, fileDateTime);
            File.SetLastWriteTimeUtc(filePath, fileDateTime);
            File.SetLastAccessTimeUtc(filePath, fileDateTime);
        }
    }
}