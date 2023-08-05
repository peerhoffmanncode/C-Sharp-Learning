﻿using System.Text.Json;

class GameDataParser
{

    // properties
    public IFileHandler<List<Game>> FileHandler { get; }
    public IUserInputHandler UserInput { get; }
    public IUserInterfaceLogger UserInterface { get; }

    // Constructer with dependency injection
    public GameDataParser(IFileHandler<List<Game>> fileHandler, IUserInterfaceLogger userInterface, IUserInputHandler userInput)
    {
        FileHandler = fileHandler;
        UserInterface = userInterface;
        UserInput = userInput;
    }

    public void run()
    {
        string FullFilePath, ValidFileName = "";
        List<Game> listOfGames;
        while (true)
        {
            UserInterface.Message("Enter the name of the file you want to read:", "", 0);
            ValidFileName = UserInput.GetFileName();
            FullFilePath = FileHandler.CreateFullFilePath(ValidFileName, "data");

            if (FileHandler.Exists(FullFilePath) != true)
            {
                UserInterface.Message("File not found. " + FileHandler.CreateFullFilePath(ValidFileName, "data"), "", 0);
                continue;
            }
            else
            {
                // Read data from valid file
                try
                {
                    if (!string.IsNullOrEmpty(FullFilePath))
                    {
                        listOfGames = FileHandler.Read(FullFilePath);
                        break;
                    }
                }
                catch (JsonException ex)
                {
                    UserInterface.Message($"JSON in the file: {ValidFileName} was not in a valid format. JSON body: {ex.Message}", ex.StackTrace, 1);
                }
            }
        }

        if (listOfGames != null)
        {
            // Visualize loaded data
            UserInterface.ShowGames(listOfGames);
        }
        else
        {
            UserInterface.Message("No games are present in the input file.", "", 0);
        }
    }
}
