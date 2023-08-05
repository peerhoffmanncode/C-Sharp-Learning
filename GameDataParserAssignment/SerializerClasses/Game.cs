// See https://aka.ms/new-console-template for more information
public class Game
{
    public Game(string title, int releaseYear, float rating)
    {
        Title = title;
        ReleaseYear = releaseYear;
        Rating = rating;
    }

    public string Title { get; set; }
    public int ReleaseYear { get; set; }
    public float Rating { get; set; }
}
