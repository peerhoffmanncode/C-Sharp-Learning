// See https://aka.ms/new-console-template for more information
public class ListOfGames
{
    public ListOfGames()
    {
    }

    public ListOfGames(Game[]? games)
    {
        Games = games;
    }

    public Game[]? Games { get; }
}
