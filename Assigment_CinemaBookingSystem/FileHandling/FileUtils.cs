internal static class FileUtils
{
    public static string[] FindAllFiles(string path, string fileExtention)
    {
        return Directory.GetFiles(path, fileExtention);
    }
}