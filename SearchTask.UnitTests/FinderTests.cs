namespace SearchTask.UnitTests
{
    [TestFixture]
    internal class FinderTests
    {
        private Finder finder;
        private int actualStartIndex;
        private int actualEndIndex;

        [SetUp]
        public void Setup()
        {
            finder = new Finder();
            actualStartIndex = 0;
            actualEndIndex = 0;
        }

        #region Exceptions test
        [Test]
        public void FindElementsForSum_NullReference_ThrowNullReferenceException()
        {
            NullReferenceException nullReference = Assert.Catch<NullReferenceException>(
                () => finder.FindElementsForSum(null, 2, out _, out _));
            StringAssert.Contains("List reference not set to an instance of an object.", nullReference.Message);
        }
        [Test]
        public void FindElementsForSum_EmptyList_ThrowArgumentException()
        {
            InvalidOperationException operationException = Assert.Catch<InvalidOperationException>(
                () => finder.FindElementsForSum(new List<uint>(), 100, out _, out _));
            StringAssert.Contains("List contains no elements", operationException.Message);
        }
        #endregion

        #region One element equal sum
        [Test]
        public void FindElementsForSum_OneElementEqualSum_AssignIndexes()
        {
            finder.FindElementsForSum(
                new List<uint> { 23, 72, 2, 73, 63, 24, 4, 85, 100, 91, 81, 84, 16, 53, 26, 46, 30, 31, 90, 94 },
                24, out actualStartIndex, out actualEndIndex);
            Assert.Multiple(() =>
            {
                Assert.That(actualStartIndex, Is.EqualTo(5));
                Assert.That(actualEndIndex, Is.EqualTo(6));
            });
        }
        [Test]
        public void FindElementsForSum_SomeElementsEqualSum_AssignNearestIndexes()
        {
            finder.FindElementsForSum(
                new List<uint> { 22, 83, 60, 67, 99, 82, 83, 76, 83, 91, 34, 50, 77, 26, 85, 31, 83, 52, 11, 49 },
                83, out actualStartIndex, out actualEndIndex);
            Assert.Multiple(() =>
            {
                Assert.That(actualStartIndex, Is.EqualTo(1));
                Assert.That(actualEndIndex, Is.EqualTo(2));
            });
        }
        #endregion

        #region Sequence of numbers equal sum
        [Test]
        public void FindElementsForSum_SumInitialValues_AssignIndexes()
        {
            finder.FindElementsForSum(
                new List<uint> { 7, 23, 60, 66, 41, 5, 67, 27, 50, 98, 77, 58, 72, 1, 68, 33, 85, 19, 86, 2 },
                269, out actualStartIndex, out actualEndIndex);
            Assert.Multiple(() =>
            {
                Assert.That(actualStartIndex, Is.EqualTo(0));
                Assert.That(actualEndIndex, Is.EqualTo(7));
            });
        }
        [Test]
        public void FindElementsForSum_SumMiddleValues_AssignIndexes()
        {
            finder.FindElementsForSum(
                new List<uint> { 52, 89, 41, 79, 2, 25, 43, 30, 30, 33, 77, 11, 4, 94, 61, 26, 95, 76, 70, 56 },
                181, out actualStartIndex, out actualEndIndex);
            Assert.Multiple(() =>
            {
                Assert.That(actualStartIndex, Is.EqualTo(7));
                Assert.That(actualEndIndex, Is.EqualTo(12));
            });
        }
        [Test]
        public void FindElementsForSum_SumLastValues_AssignIndexes()
        {
            finder.FindElementsForSum(
                new List<uint> { 78, 87, 61, 82, 80, 24, 46, 87, 35, 68, 67, 51, 47, 24, 50, 89, 34, 74, 24, 2 },
                273, out actualStartIndex, out actualEndIndex);
            Assert.Multiple(() =>
            {
                Assert.That(actualStartIndex, Is.EqualTo(14));
                Assert.That(actualEndIndex, Is.EqualTo(20));
            });
        }
        [Test]
        public void FindElementsForSum_InitialSequenceAndLastSequenceEqualSum_AssignNearestIndexes()
        {
            finder.FindElementsForSum(
                new List<uint> { 92, 0, 98, 6, 34, 16, 53, 98, 67, 70, 92, 10, 51, 39, 48, 57, 63, 8, 36, 82 },
                246, out actualStartIndex, out actualEndIndex);
            Assert.Multiple(() =>
            {
                Assert.That(actualStartIndex, Is.EqualTo(0));
                Assert.That(actualEndIndex, Is.EqualTo(6));
            });
        }
        [Test]
        public void FindElementsForSum_SumIsResultOffAddingAllElements_AssignIndexes()
        {
            finder.FindElementsForSum(
                new List<uint> { 33, 64, 99, 89, 22, 58, 39, 70, 63, 11, 75, 45, 51, 89, 49, 26, 15, 80, 69, 66 },
                1113, out actualStartIndex, out actualEndIndex);
            Assert.Multiple(() =>
            {
                Assert.That(actualStartIndex, Is.EqualTo(0));
                Assert.That(actualEndIndex, Is.EqualTo(20));
            });
        }
        #endregion

        #region None of the sequences is equal to the sum
        [Test]
        public void FindElementsForSum_SumIsUlongMaxValue_AssignZeroIndexes()
        {
            finder.FindElementsForSum(
                new List<uint> { 3, 29, 27, 95, 31, 1, 0, 86, 14, 16, 47, 12, 41, 38, 59, 88, 1, 49, 52, 87 },
                ulong.MaxValue, out actualStartIndex, out actualEndIndex);
            Assert.Multiple(() =>
            {
                Assert.That(actualStartIndex, Is.EqualTo(0));
                Assert.That(actualEndIndex, Is.EqualTo(0));
            });
        }
        [Test]
        public void FindElementsForSum_NoneSequenceEqualSum_AssignZeroIndexes()
        {
            finder.FindElementsForSum(
                new List<uint> { 100, 79, 69, 22, 48, 12, 78, 45, 4, 23, 13, 85, 58, 34, 75, 38, 9, 34, 25, 80 },
                0, out actualStartIndex, out actualEndIndex);
            Assert.Multiple(() =>
            {
                Assert.That(actualStartIndex, Is.EqualTo(0));
                Assert.That(actualEndIndex, Is.EqualTo(0));
            });
        }
        #endregion
    }
}