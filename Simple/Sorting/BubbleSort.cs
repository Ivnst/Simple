using System;
using System.Collections.Generic;

namespace Simple.Sorting
{
    /// <summary>
    /// Сортировка пузырьком. Сложность: O(n^2)
    /// </summary>
    public class BubbleSort : ISorting
    {
        /// <summary>
        /// Сортировка указанных элементов
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        public void Perform<T>(IList<T> items) where T : IComparable<T>
        {
            if (items == null) throw new ArgumentNullException("items");
            if (items.Count < 2) return;

            for (var i = 0; i < items.Count; i++)
            {
                for (var j = 0; j < items.Count - i - 1; j++)
                {
                    if (items[j].CompareTo(items[j + 1]) > 0)
                    {
                        var temp = items[j];
                        items[j] = items[j + 1];
                        items[j + 1] = temp;
                    }
                }
            }
        }
    }
}
