
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("UnitTest001_Tests")]

namespace UnitTest_001;

class Program
{
    static void Main()
    {
        int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        Console.WriteLine(numbers.SumOfEvenNumbers());
        Console.ReadKey();
    }
}

internal static class EnumerableExtention
{
    public static int SumOfEvenNumbers(this IEnumerable<int> numbers)
    {
        return numbers.Where(x => x % 2 == 0).Sum();

        //int result = 0;
        //foreach (var number in numbers)
        //{
        //    if (number % 2 == 0)
        //    {
        //        result += number;
        //    }
        //}
        //return result;
    }

}
