
IDataDownloader dataDownloader = new DecoratedDataDownloader(new SlowDataDownloader(), new Cache<String, String>());
for (int i = 0; i < 10; i++)
{
    Console.WriteLine(dataDownloader.DownloadData("id1"));
    Console.WriteLine(dataDownloader.DownloadData("id2"));
    Console.WriteLine(dataDownloader.DownloadData("id3"));
    Console.WriteLine(dataDownloader.DownloadData("id1"));
    Console.WriteLine(dataDownloader.DownloadData("id3"));
    Console.WriteLine(dataDownloader.DownloadData("id1"));
    Console.WriteLine(dataDownloader.DownloadData("id2"));
}

Console.ReadKey();

public interface IDataDownloader
{
    string DownloadData(string resourceId);
}

public class DecoratedDataDownloader : IDataDownloader
{
    private readonly IDataDownloader _download;
    private readonly Cache<String, String> _cacheStorage;
    public DecoratedDataDownloader(IDataDownloader Downloader, Cache<String, String> CacheStorage)
    {
        _download = Downloader;
        _cacheStorage = CacheStorage;
    }

    public string DownloadData(string resourceId)
    {
        return _cacheStorage.Read(resourceId, _download.DownloadData);
    }
}

public class SlowDataDownloader : IDataDownloader
{
    public string DownloadData(string resourceId)
    {
        //let's imagine this method downloads real data,
        //and it does it slowly
        Thread.Sleep(1000);
        return $"Some data for {resourceId}";
    }
}


public class Cache<TKey, TValue> where TKey : notnull where TValue : notnull
{
    private readonly Dictionary<TKey, TValue> _storage = new();
    public TValue Read(TKey identifierKey, Func<TKey, TValue> predicate)
    {
        if (!this._storage.ContainsKey(identifierKey))
        {
            this._storage[identifierKey] = predicate(identifierKey);
        }
        return this._storage[identifierKey];
    }
    public void Write(TKey identifierKey, Func<TKey, TValue> predicate)
    {
        this._storage[identifierKey] = predicate(identifierKey);
    }

}