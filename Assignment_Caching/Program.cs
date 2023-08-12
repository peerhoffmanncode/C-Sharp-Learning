
Cache<String, String> CacheStoreage = new();

IDataDownloader dataDownloader = new SlowDataDownloader(CacheStoreage);
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

public class SlowDataDownloader : IDataDownloader
{
    private Cache<String, String> _CacheStorage;
    public SlowDataDownloader(Cache<String, String> CacheStorage)
    {
        _CacheStorage = CacheStorage;
    }
    public string DownloadData(string resourceId)
    {
        var (inStorage, data) = _CacheStorage.Read(resourceId);

        if (!inStorage)
        {
            //let's imagine this method downloads real data,
            //and it does it slowly
            Thread.Sleep(1000);
            data = $"Some data for {resourceId}";
            _CacheStorage.Write(resourceId, data);
        }
        return data;
    }
}


public class Cache<TKey, Tvalue> where TKey : notnull
{
    private Dictionary<TKey, Tvalue> _storage;
    public Cache()
    {
        _storage = new Dictionary<TKey, Tvalue>();
    }
    public void Write(TKey identifierKey, Tvalue dataToStore)
    {
        this._storage[identifierKey] = dataToStore;
    }

    public (bool Status, Tvalue Data) Read(TKey identifierKey)
    {
        if (this._storage.ContainsKey(identifierKey))
        {
            return (true, this._storage[identifierKey]);
        }
        return (false, default(Tvalue?));
    }
}