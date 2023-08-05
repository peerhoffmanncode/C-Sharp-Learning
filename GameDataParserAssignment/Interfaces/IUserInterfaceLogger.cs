// See https://aka.ms/new-console-template for more information





public interface IUserInterfaceLogger
{
    void Message(string msg, string stackTrace, int level);
    void ShowGames(List<Game> listOfGames);
}
