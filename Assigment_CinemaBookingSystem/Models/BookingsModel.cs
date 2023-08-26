using System.Globalization;

internal record BookingsModel
{
    private DateTime date;

    public string Title { get; init; }
    public DateTime Date { get => date; init => date = value; }

    public BookingsModel(string title, DateTime date)
    {
        Title = title;
        Date = date;
    }

    public string getInvaruant()
    {
        return $"{this.Date.Date.ToString("d", CultureInfo.InvariantCulture)} | {this.Date.TimeOfDay.ToString("t", CultureInfo.InvariantCulture)}";
    }
}
