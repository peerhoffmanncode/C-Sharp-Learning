// See https://aka.ms/new-console-template for more information

using System.Text.Json;

namespace Assignment_StarwarsAPI.ApiReader;

public class AsyncApiReader : IAsyncApiReader
{
    public async Task<string> Read(string BaseUrl, string UriResource)
    {
        if (BaseUrl == null)
        {
            throw new ArgumentNullException($"The BaseUrl should be set, was null!");
        }
        else if (UriResource == null)
        {
            throw new ArgumentNullException($"The UriResource should be set, was null!");
        }

        // make sure the BaseUrl & UriResource is not set twice
        BaseUrl = BaseUrl.ToLower().Replace(UriResource.ToLower(), "");
        UriResource = UriResource.ToLower().Replace(BaseUrl.ToLower(), "");

        // instanciate client
        using var client = new HttpClient();

        // configure connection
        client.BaseAddress = new Uri(BaseUrl);

        // get response        
        HttpResponseMessage response = await client.GetAsync(UriResource);
        response.EnsureSuccessStatusCode();

        // await data and return
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<(Planets, List<PlanetData>)> ReadAll(string BaseUrl, string UriResource)
    {
        Planets _planets;
        List<PlanetData> _allPlanets = new();
        do
        {
            string? jsonString = await Read(BaseUrl, UriResource);
            if (IsVaildJson(jsonString, out _planets))
            {
                _allPlanets.AddRange(_planets.Results.ToList());
            }
            await Console.Out.WriteLineAsync($"{_allPlanets.Count} of {_planets.Count} planets read from the API");
            UriResource = _planets.Next;
        } while (!string.IsNullOrEmpty(UriResource));

        return (_planets, _allPlanets);
    }

    public static bool IsVaildJson(string jsonString, out Planets _data)
    {
        if (jsonString != null)
        {
            _data = JsonSerializer.Deserialize<Planets>(jsonString)!;
            if (_data == null)
            {
                throw new InvalidOperationException("could not parse data from API!");
            }
        }
        else
        {
            throw new InvalidOperationException("could not retrieve data from API!");
        }
        return true;
    }
}