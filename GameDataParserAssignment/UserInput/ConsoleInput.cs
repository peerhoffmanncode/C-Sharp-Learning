﻿// See https://aka.ms/new-console-template for more information





public class ConsoleInput : IUserInputHandler
{
    public ConsoleInput(IUserInterfaceLogger userInterface, IFileHandler<List<Game>> fileHandler)
    {
        UserInterface = userInterface;
        FileHandler = fileHandler;
    }

    IUserInterfaceLogger UserInterface { get; }
    IFileHandler<List<Game>> FileHandler { get; }

    public string GetFileName()
    {
        bool ValidInput = false;
        string _filename = "";
        do
        {
            try
            {
                _filename = Console.ReadLine();
                if (_filename == "")
                {
                    UserInterface.Message("File name cannot be empty.", "", 0);
                    continue;
                }
                else if (_filename is null)
                {
                    UserInterface.Message("File name cannot be null.", "", 0);
                    continue;
                }
                ValidInput = true;
            }
            catch (ArgumentNullException ex)
            {
                UserInterface.Message("File name cannot be null.", ex.StackTrace, 0);
            }

        } while (ValidInput != true);

        // return vailde filename
        return _filename;
    }
}
