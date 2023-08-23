// See https://aka.ms/new-console-template for more information

public class TableOfContent
{

    public Planets PlanetOverview { get; set; }
    public List<PlanetData> AllPlanets { get; set; }

    public TableOfContent(Planets _planetOverview, List<PlanetData> _allPlanets)
    {
        PlanetOverview = _planetOverview;
        AllPlanets = _allPlanets;
    }

    public void Show(string headline, List<string> _columns)
    {
        const string seperator = " | ";
        const string trailEnd = " | ";
        const char line = '-';

        // setup dictionary for column width
        Dictionary<string, int> columnWidths = new();

        // Calculate the maximum width for each column based on column headers and data
        foreach (var column in _columns)
        {
            int maxWidth = Math.Max(column.Length, AllPlanets.Max(planet => GetPropertyValueLength(planet, column)));
            columnWidths[column] = maxWidth;
        }

        // Build the header using LINQ and concatenate the elements
        string columnHeader = string.Join(seperator, _columns.Select(col => col.PadRight(columnWidths[col]))) + trailEnd;

        // Print the header
        UserInterface.PrintMessage(headline);
        // Print separator line
        UserInterface.PrintMessage(new string(line, columnWidths.Values.Sum() + (3 * _columns.Count - 1)));
        // Print column names
        UserInterface.PrintMessage(columnHeader);

        // Print separator line
        UserInterface.PrintMessage(new string(line, columnWidths.Values.Sum() + (3 * _columns.Count - 1)));

        // Print each planet's data
        foreach (var planet in AllPlanets)
        {
            var rowData = new List<string>();
            foreach (var column in _columns)
            {
                var value = GetPropertyValue(planet, column);
                rowData.Add(value.PadRight(columnWidths[column]));
            }

            UserInterface.PrintMessage(string.Join(seperator, rowData) + trailEnd);
        }
    }

    private int GetPropertyValueLength(object obj, string propertyName)
    {
        var propertyInfo = obj.GetType().GetProperty(propertyName);
        if (propertyInfo != null)
        {
            var value = propertyInfo.GetValue(obj);
            return value != null ? value.ToString()!.Length : 0;
        }
        return 0;
    }

    private string GetPropertyValue(object obj, string propertyName)
    {
        var propertyInfo = obj.GetType().GetProperty(propertyName);
        if (propertyInfo != null)
        {
            var value = propertyInfo.GetValue(obj);
            return value != null ? value.ToString()! : "N/A";
        }
        return "N/A";
    }
}