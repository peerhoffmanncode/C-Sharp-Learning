using AssignmentRecursiveFubunacciWithTests;
using NUnit.Framework;


namespace Assignment_RecursiveFubunacciWithTests
{
    [TestFixture]
    internal class FibonacciGeneratorTests
    {

        [Test]
        public static void RecursiveFibonacciWithCache_ShallRetrunZero_ForInputZero()
        {
            Assert.AreEqual(0, FibonacciGenerator.RecursiveFibonacciWithCache(0));
        }

        [Test]
        public static void RecursiveFibonacciWithCache_ShallRetrunOne_ForInputOne()
        {
            Assert.AreEqual(1, FibonacciGenerator.RecursiveFibonacciWithCache(1));
        }

        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(3, 2)]
        [TestCase(4, 3)]
        [TestCase(5, 5)]        
        public static void RecursiveFibonacciWithCache_ShallRetrunExpected_ForInput(int input, int expected)
        {
            Assert.AreEqual(expected, FibonacciGenerator.RecursiveFibonacciWithCache(input));
        }

        [TestCase(-1, 0)]
        public static void RecursiveFibonacciWithCache_ShallRetrunZero_ForNegativeInput(int input, int expected)
        {
            Assert.AreEqual(expected, FibonacciGenerator.RecursiveFibonacciWithCache(input));
        }

        [TestCase(46, 1836311903)]
        public static void RecursiveFibonacciWithCache_ShallRetrunExpected_ForInputMaxValue46(int input, int expected)
        {
            Assert.AreEqual(expected, FibonacciGenerator.RecursiveFibonacciWithCache(input));
        }

        [TestCase(47, -1)]
        [TestCase(9999, -1)]
        public static void RecursiveFibonacciWithCache_ShallThrowArgumentException_ForInputBiggerMaxValue46(int input, int expected)
        {
            Assert.Throws<ArgumentException>(() => FibonacciGenerator.RecursiveFibonacciWithCache(input));
        }

    }
}
