using System.Security;

internal class FileHandler : IFileHandler
{
    public string CreateFullFilePath(string filename, string subFolder)
    {
        if (subFolder != "")
        { subFolder = Path.DirectorySeparatorChar + subFolder; }

        return $"{Environment.CurrentDirectory}{subFolder}{Path.DirectorySeparatorChar}{filename}";
    }
    public bool Exists(string filename)
    {
        return File.Exists(filename);
    }

    public List<string> Read(string filename)
    {
        List<string> data = new();
        if (!string.IsNullOrEmpty(filename) && File.Exists(filename))
        {
            string readData = File.ReadAllText(filename);
            data = (List<string>)(object)readData.Split(Environment.NewLine);
        }
        return data;
    }

    public bool Write(string filename, List<string> Data)
    {
        if (string.IsNullOrEmpty(filename))
            return false;

        try
        {
            File.WriteAllText(filename, string.Join(Environment.NewLine, Data));
            return true;
        }
        catch (IOException ex)
        {
            // Handle I/O errors (e.g., disk full, permissions issue)            
            return false;
        }
        catch (UnauthorizedAccessException ex)
        {
            // Handle permissions-related errors            
            return false;
        }
        catch (SecurityException ex)
        {
            // Handle security policy-related errors            
            return false;
        }
        catch (ArgumentNullException ex)
        {
            // Handle null Games parameter            
            return false;
        }
    }
}