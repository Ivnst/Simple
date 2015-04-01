using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simple.Sorting;

namespace Simple.Tests.Sorting
{
    [TestClass]
    public class SortingTest : BaseSortTesting
    {
        /// <summary>
        /// Проверка алгоритма сортировки выборкой
        /// </summary>
        [TestMethod]
        public void SelectionSortTest()
        {
            SortTestRandom(new SelectionSort());
        }
        
        /// <summary>
        /// Проверка алгоритма сортировки пузырьком
        /// </summary>
        [TestMethod]
        public void BubbleSortTest()
        {
            SortTestRandom(new BubbleSort());
        }

    }
}
