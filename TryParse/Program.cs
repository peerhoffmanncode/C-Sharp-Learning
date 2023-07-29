// See https://aka.ms/new-console-template for more information

Console.WriteLine("Enter a number");

bool isParseable;
do
{
    var myInput = Console.ReadLine();
    isParseable = int.TryParse(myInput, out int number);
    if (isParseable)
    {
        Console.WriteLine("Return :" + number);
    }
    else
    {
        Console.WriteLine("Was not a number");
    }
} while (!isParseable);
Console.WriteLine("Cya...");

Console.ReadKey();