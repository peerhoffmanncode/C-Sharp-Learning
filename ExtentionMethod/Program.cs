// See https://aka.ms/new-console-template for more information

var data = new Stack<string>();
data.Push("stuff");
data.Push("other stuff");
data.Push("dings");
data.Push("bums");

Console.WriteLine(data.DoesContainAny("Test"));
Console.WriteLine(data.DoesContainAny("bums"));
Console.ReadKey();

public static class StackExtensions
{
    public static bool DoesContainAny(this Stack<string> itemToExtent, params string[] toCheck)
    {
        foreach (var word in toCheck)
        {
            if (itemToExtent.Contains(word))
            {
                return true;
            }
        }
        return false;
    }
}