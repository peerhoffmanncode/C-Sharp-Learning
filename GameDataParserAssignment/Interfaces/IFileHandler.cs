// See https://aka.ms/new-console-template for more information







public interface IFileHandler<T>
{
    string CreateFullFilePath(string filename, string subFolder);
    bool Exists(string filename);

    T Read(string filename);

    bool Write(string filename, T Data);
}
