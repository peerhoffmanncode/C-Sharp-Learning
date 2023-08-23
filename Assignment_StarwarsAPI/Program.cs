// See https://aka.ms/new-console-template for more information

using Assignment_StarwarsAPI.ApiReader;
using Assignment_StarwarsAPI.Display;
using Assignment_StarwarsAPI.Utils;

// define constants
const string BaseUrl = "https://swapi.dev/api/";
const string UriResource = "planets";

// define default columns
List<string> possibleColumns = new() { "Name", "Population", "Diameter", "SurfaceWater", "OrbitalPeriod", "Gravity" };

// instanciate ApiReader
AsyncApiReader reader = new();
// Get data from API
(Planets PlanetOverview, List<PlanetData> AllPlanetsData) = await reader.ReadAll(BaseUrl, UriResource);

// Setup and show Table of Content
TableOfContent table = new(PlanetOverview, AllPlanetsData);
table.Show("\nTable of content for all read planets", possibleColumns);

// promt user to pick a colum for mix / max values
do
{
    string selectedColumn = UserInterface.SelectColumn(possibleColumns);
    if (selectedColumn == "exit")
        break;
    if (possibleColumns.Contains(selectedColumn))
    {
        // get instances holding min and max values
        (PlanetData? MinValue, PlanetData? MaxValue) = Utils.FindMinMax(AllPlanetsData, selectedColumn);
        // show table of content with just the min and max entries
        table.AllPlanets = new List<PlanetData>() { MinValue!, MaxValue! };
        table.Show($"\nTable of content for minimal and maximal values: {selectedColumn}", possibleColumns);
    }
    else
    {
        UserInterface.PrintMessage("Unknow column, please try again.");
    }
} while (true);

// finish
UserInterface.PrintMessage("Press any key to close ...");
Console.ReadKey();


