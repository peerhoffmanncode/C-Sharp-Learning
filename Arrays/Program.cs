Console.WriteLine("fuu");

public class Exercise
{
    public static string BuildHelloString()
    {
        char[] letters = { 'h', 'e', 'l', 'l', 'o' };
        var result = "";
        for (int i = 0; i < letters.Length; ++i)
        {
            result += letters[i];
        }
        return result;



        // add a return result + 5

    }
}

