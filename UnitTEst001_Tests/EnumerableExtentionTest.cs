using NUnit.Framework;
using UnitTest_001;


namespace UnitTest001_Tests
{
    [TestFixture]
    public class EnumerableExtentionTest
    {

        [Test]
        public void SumOfEvenNumbers_ShallReturnZero_ForEmptyCollection()
        {
            var input = Enumerable.Empty<int>();

            Assert.AreEqual(0, input.SumOfEvenNumbers());
        }

        [Test]
        public void SumOfEvenNumbers_ShallReturn42_ForCollectionTilNumber12()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

            Assert.AreEqual(42, numbers.SumOfEvenNumbers());
        }

        [Test]
        public void SumOfEvenNumbers_ShallReturnOnylOneItem_ForCollectionWithOneItem()
        {
            int[] numbers = new int[] { 2 };
            Assert.AreEqual(2, numbers.SumOfEvenNumbers());
        }

        [TestCase(3, 0)]
        [TestCase(5, 0)]
        [TestCase(-7, 0)]
        [TestCase(33, 0)]
        public void SumOfEvenNumbers_ShallReturnZeroForOnlyUnevenElements_ForCollectionWithOneUnevenItem(int data, int result)
        {
            int[] numbers = new int[] { data };

            Assert.AreEqual(result, numbers.SumOfEvenNumbers());
        }


        [Test]
        public void SumOfEvenNumbers_ShallThrowArgumentNullException_ForCollectionNull()
        {
            IEnumerable<int>? numbers = null;

            var exception = Assert.Throws<ArgumentNullException>(() => numbers!.SumOfEvenNumbers());

        }
    }
}