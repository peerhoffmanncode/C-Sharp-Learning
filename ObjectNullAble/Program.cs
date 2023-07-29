internal class Program
{
    private static void Main(string[] args)
    {

        Random rnd = new();

        string key = "";
        while (true)
        {
            int num = rnd.Next(0, 236745);
            TestObject obj1 = new TestObject(num);

            if (obj1 is not null)
            {
                Console.WriteLine($"Instance of class: {obj1.GetType()} is not null, its hash is {obj1.GetHashCode()}");
                Console.WriteLine($"The instance says: {obj1}");
            }
            else { Console.WriteLine("Obj is null ???"); }

            // Check for key press without blocking
            if (Console.KeyAvailable)
            {
                key = Console.ReadLine();
                if (key is null || key == "")
                {
                    key = " ";
                }

                if (key.ToLower()[0] == 'q')
                {
                    break; // Exit the loop if 'q' is pressed
                }
            }
        }
    }

    public class TestObject
    {
        private int _number;

        public int Number { get => _number; }

        public TestObject(int number)
        {
            _number = number;
        }

        public override string ToString()
        {
            return $"I am a TestObject class and my value of Number is: {this.Number}";
        }
    }
}