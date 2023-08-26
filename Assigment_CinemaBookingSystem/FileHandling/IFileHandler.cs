internal interface IFileHandler
{
    string CreateFullFilePath(string filename, string subFolder);
    bool Exists(string filename);
    List<string> Read(string filename);
    bool Write(string filename, List<string> Data);
}