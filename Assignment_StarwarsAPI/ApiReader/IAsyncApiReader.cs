// See https://aka.ms/new-console-template for more information

public interface IAsyncApiReader
{
    Task<string> Read(string BaseUrl, string UriResource);
    Task<(Planets, List<PlanetData>)> ReadAll(string BaseUrl, string UriResource);
}