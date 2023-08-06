// See https://aka.ms/new-console-template for more information





public interface IUserInterfaceLogger
{
    void Message(string msg, string stackTrace, bool error);
    void ShowGames(List<Game> listOfGames);
}
