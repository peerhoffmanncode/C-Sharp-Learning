namespace Coding.Exercise
{

    internal class Program
    {
        private static void Main(string[] args)
        {
            List<string> data = new List<string> { "Hello", "WaaassUp", "FrikenSHiiat!" };
            foreach (var item in Exercise.ProcessAll(data))
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
    public static class Exercise
    {
        public static List<string> ProcessAll(List<string> words)
        {
            var stringsProcessors = new List<StringsProcessor>
                {
                    new StringsTrimmingProcessor(),
                    new StringsUppercaseProcessor()
                };

            List<string> result = words;
            foreach (var stringsProcessor in stringsProcessors)
            {
                result = stringsProcessor.Process(result);
            }
            return result;
        }
    }


    public class StringsProcessor
    {
        public virtual List<string> Process(List<string> values) => values;
    }

    public class StringsUppercaseProcessor : StringsProcessor
    {
        public override List<string> Process(List<string> values)
        {
            List<string> result = new List<string>();
            foreach (string value in values)
            { result.Add(value.ToUpper()); }
            return result;
        }
    }

    public class StringsTrimmingProcessor : StringsProcessor
    {
        public override List<string> Process(List<string> values)
        {
            List<string> result = new List<string>();
            foreach (string value in values)
            { result.Add(value.Substring(0, (int)(value.Length / 2))); }
            return result;
        }
    }

}
