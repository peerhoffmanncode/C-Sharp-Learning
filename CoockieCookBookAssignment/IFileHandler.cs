using System.Text.Json;

public interface IFileHandler<T>
{

    // filename property
    string Filename { get; set; }

    // Read Method
    List<T> Read();

    // Write Method
    bool Write(List<T> data);
}

public class FromMemory<T> : IFileHandler<T>
{
    private List<T>? data;
    private string _filename;

    public string Filename { get => _filename; set => _filename = value; }

    public FromMemory(string Filename)
    {
        _filename = Filename;

        Ingredient ingredient1 = new(1, "Wheat flour", "Sieve. Add to other ingredients.");
        Ingredient ingredient2 = new(2, "Coconut flour", "Sieve. Add to other ingredients.");
        Ingredient ingredient3 = new(3, "Butter", "Melt on low heat. Add to other ingredients.");
        Ingredient ingredient4 = new(4, "Chocolate", "Melt in a water bath. Add to other ingredients.");
        Ingredient ingredient5 = new(5, "Sugar", "Add to other ingredients.");
        Ingredient ingredient6 = new(6, "Cardamom", "Take half a teaspoon. Add to other ingredients.");
        Ingredient ingredient7 = new(7, "Cinnamon", "Take half a teaspoon. Add to other ingredients.");
        Ingredient ingredient8 = new(8, "Cocoa powder", "Add to other ingredients.");


        // Create the data list and add ingredients to it.
        this.data = new List<T>();
        data.Add((T)(object)ingredient1);
        data.Add((T)(object)ingredient2);
        data.Add((T)(object)ingredient3);
        data.Add((T)(object)ingredient4);
        data.Add((T)(object)ingredient5);
        data.Add((T)(object)ingredient6);
        data.Add((T)(object)ingredient7);
        data.Add((T)(object)ingredient8);
    }

    public List<T> Read()
    {
        if (data == null)
        {
            return new List<T>();
        }
        else
        {
            return data;
        }
    }

    public bool Write(List<T> data) => false;
}

public class FromJSON<T> : IFileHandler<T>
{
    private List<T>? data;
    private string _filename;

    public string Filename { get => _filename; set => _filename = value; }

    public FromJSON(string filename)
    {
        _filename = filename + ".json";
    }

    public List<T> Read()
    {
        if (data == null)
        {
            if (!string.IsNullOrEmpty(_filename) && File.Exists(_filename))
            {
                string jsonData = File.ReadAllText(_filename);
                data = JsonSerializer.Deserialize<List<T>>(jsonData);
            }
            else
            {
                data = new List<T>();
            }
        }
        return data ?? new List<T>();
    }

    public bool Write(List<T> data)
    {
        if (string.IsNullOrEmpty(_filename))
            return false;

        try
        {
            string jsonData = JsonSerializer.Serialize(data);
            File.WriteAllText(_filename, jsonData);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}

//public class FromTXT<T> : IFileHandler<T>
//{
//    private List<T>? data;
//    private string _filename;

//    public string Filename { get => _filename; set => _filename = value; }

//    public FromTXT(string filename)
//    {
//        _filename = filename + ".txt";
//    }

//    public List<T> Read()
//    {
//        if (data == null)
//        {
//            if (!string.IsNullOrEmpty(_filename) && File.Exists(_filename))
//            {
//                string txtData = File.ReadAllText(_filename);
//                data = textData.split
//            }
//            else
//            {
//                data = new List<T>();
//            }
//        }
//        return data ?? new List<T>();
//    }

//    public bool Write(List<T> data)
//    {
//        if (string.IsNullOrEmpty(_filename))
//            return false;

//        try
//        {
//            string jsonData = JsonSerializer.Serialize(data);
//            File.WriteAllText(_filename, jsonData);
//            return true;
//        }
//        catch (Exception)
//        {
//            return false;
//        }
//    }
//}