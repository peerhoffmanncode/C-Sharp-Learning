

var numbers = new[] { 10, -8, 2, 12, -17 };

var onlyPositives = GetOnlyPositive(numbers, out int nonPositiveCount);

foreach (var positive in onlyPositives)
{
    Console.WriteLine(positive);
}
Console.WriteLine($"Non positive values: {nonPositiveCount}");
Console.ReadKey();


List<int> GetOnlyPositive(int[] numbers, out int countOfNonPositives)
{
    var result = new List<int>();
    countOfNonPositives = 0;

    foreach (var number in numbers)
    {
        if (number > 0)
        {
            result.Add(number);
        }
        else
        { countOfNonPositives++; }
    }
    return result;
}