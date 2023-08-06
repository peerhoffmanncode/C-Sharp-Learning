// See https://aka.ms/new-console-template for more information
public class Game
{
    public Game(string title, int releaseYear, decimal rating)
    {
        Title = title;
        ReleaseYear = releaseYear;
        Rating = rating;
    }

    public string Title { get; init; }
    public int ReleaseYear { get; init; }
    public decimal Rating { get; init; }

    public override string ToString()
    {
        return $"{this.Title}, released in {this.ReleaseYear}, rating: {this.Rating}";
    }
}
