// See https://aka.ms/new-console-template for more information


var numbers = new List<int> { 1, 2, 3, 4, 5 };
var numbersWith10 = numbers.Append(10);
numbersWith10 = numbersWith10.Append(11);

var oddNumber = numbersWith10
    .Where(x => x % 2 == 1)
    .OrderBy(x => -x);

foreach (var number in oddNumber)
{
    Console.WriteLine(number);
}

Console.ReadKey();



