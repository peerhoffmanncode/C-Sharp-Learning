// See https://aka.ms/new-console-template for more information







using System.Security;
using System.Text.Json;

public class JsonFileHandler : IFileHandler<List<Game>>
{
    IUserInterfaceLogger UserInterface;
    public JsonFileHandler(IUserInterfaceLogger _userInterface)
    {
        UserInterface = _userInterface;
    }
    public bool Exists(string filename)
    {
        return File.Exists(filename);
    }

    public string CreateFullFilePath(string filename, string subFolder)
    {
        if (subFolder != "")
        { subFolder = Path.DirectorySeparatorChar + subFolder; }

        return $"{Environment.CurrentDirectory}{subFolder}{Path.DirectorySeparatorChar}{filename}.json";
    }

    public List<Game>? Read(string filename)
    {
        List<Game> data = new();
        if (!string.IsNullOrEmpty(filename) && File.Exists(filename))
        {
            string jsonData = File.ReadAllText(filename);
            data = JsonSerializer.Deserialize<List<Game>>(jsonData);
        }

        return data;
    }

    public bool Write(string filename, List<Game> Games)
    {
        if (string.IsNullOrEmpty(filename))
            return false;

        try
        {
            string jsonData = JsonSerializer.Serialize(Games);
            File.WriteAllText(filename, jsonData);
            return true;
        }
        catch (IOException ex)
        {
            // Handle I/O errors (e.g., disk full, permissions issue)
            UserInterface.Message($"Error writing to file: {ex.Message}", ex.StackTrace, true);
            return false;
        }
        catch (UnauthorizedAccessException ex)
        {
            // Handle permissions-related errors
            UserInterface.Message($"Unauthorized access while writing to file: {ex.Message}", ex.StackTrace, true);
            return false;
        }
        catch (SecurityException ex)
        {
            // Handle security policy-related errors
            UserInterface.Message($"Security exception while writing to file: {ex.Message}", ex.StackTrace, true);
            return false;
        }
        catch (ArgumentNullException ex)
        {
            // Handle null Games parameter
            UserInterface.Message($"Error: {ex.Message}", ex.StackTrace, true);
            return false;
        }
    }
}

