namespace OOP_DiceRollGame.Game.Die
{
    public class Die
    {
        // instanz variables
        private const int sidesCount = 6;
        private int _value;
        private readonly Random _rnd;

        public Die()
        {
            _rnd = new Random();
            Roll(_rnd.Next(1, SidesCount + 1));
        }

        // property to get the Die's current value
        public int Value { get => _value; private set { _value = value; } }

        public static int SidesCount => sidesCount;

        // Method to roll the Die (set the value)
        public int Roll(int rnd)
        {
            _value = rnd;
            return Value;
        }
    }
}