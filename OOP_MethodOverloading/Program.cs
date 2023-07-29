// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");


class MediacApointment
{
    private string _patientName;
    private DateTime _date;


    public MediacApointment(string patientName) : this(patientName, 7)
    { }

    public MediacApointment(string patientName, int daysFromNow)
    {
        _patientName = patientName;
        _date = DateTime.Now.AddDays(daysFromNow);
    }

    public MediacApointment(string patientName, DateTime date)
    {
        _patientName = patientName;
        _date = date;
    }

    public void Reschedule(DateTime date)
    { _date = date; }

    public void OverwriteMonthAndDay(int month, int day)
    { _date = new DateTime(_date.Year, month, day); }

    public void AddMonthAndDay(int monthToAdd, int dayToAdd)
    { _date = new DateTime(_date.Year, _date.Month + monthToAdd, _date.Day + dayToAdd); }
}
