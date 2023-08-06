// See https://aka.ms/new-console-template for more information





public class ConsoleInput : IUserInputHandler
{
    public ConsoleInput(IUserInterfaceLogger userInterface)
    {
        UserInterface = userInterface;
    }

    IUserInterfaceLogger UserInterface { get; }

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
                    UserInterface.Message("File name cannot be empty.", "", false);
                    continue;
                }
                else if (_filename is null)
                {
                    UserInterface.Message("File name cannot be null.", "", false);
                    continue;
                }
                ValidInput = true;
            }
            catch (ArgumentNullException ex)
            {
                UserInterface.Message("File name cannot be null.", ex.StackTrace, false);
            }

        } while (ValidInput != true);

        // return vailde filename
        return _filename;
    }
}
