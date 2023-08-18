// See https://aka.ms/new-console-template for more information


const string path = "C:\\Users\\Peer\\Documents\\C-Sharp-Learning\\CSV Read Class\\bin\\Debug\\net7.0\\sampleData.csv";

var _csvReader = new CsvReader();
var data = _csvReader.Read(path);

Console.ReadKey();


public class CsvReader
{

    public CsvData Read(string path)
    {

        using var streamReader = new StreamReader(path);

        const string Seperator = ",";
        var columns = streamReader.ReadLine().Split(Seperator);
        var rows = new List<string[]>();
        
        while(!streamReader.EndOfStream)
        {
            rows.Add(streamReader.ReadLine().Split(Seperator));
        }

        return new CsvData(columns, rows);
    }
}

public class CsvData
{
    public CsvData(string[] columns)
    {
        Columns = columns;
    }

    public string[] Columns { get; }
    public IEnumerable<string[]> Rows { get; }

    public CsvData(string[] columns, IEnumerable<string[]> rows)
    {
        Columns = columns;
        Rows = rows;        
    }
}