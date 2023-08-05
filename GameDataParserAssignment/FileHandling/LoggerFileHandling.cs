namespace GameDataParserAssignment.FileHandling
{
    internal class LoggerFileHandling : IFileHandler<string>
    {

        public bool Exists(string filename)
        {
            return File.Exists(filename);
        }

        public string CreateFullFilePath(string filename, string subFolder)
        {
            if (subFolder != "")
            { subFolder = Path.DirectorySeparatorChar + subFolder; }

            return $"{Environment.CurrentDirectory}{subFolder}{Path.DirectorySeparatorChar}{filename}.json";
        }

        public string Read(string filename)
        {
            string[] data = null;
            if (!string.IsNullOrEmpty(filename) && File.Exists(filename))
            {
                string readData = File.ReadAllText(filename);
                data = readData.Split(Environment.NewLine);
            }

            return string.Join(",", data);
        }

        public bool Write(string filename, string line)
        {
            if (string.IsNullOrEmpty(filename))
                return false;

            line = $"[{DateTime.Now}], {line}{Environment.NewLine}";
            File.AppendAllText(filename, line);
            return true;
        }
    }
}
