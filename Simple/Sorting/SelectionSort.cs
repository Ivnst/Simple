using System;
using System.Collections.Generic;

namespace Simple.Sorting
{
    /// <summary>
    /// Сортировка выбором. Сложность: O(n^2)
    /// </summary>
    public class SelectionSort : ISorting
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
                var minItem = items[i];
                var minItemIndex = i;

                for (var j = i + 1; j < items.Count; j++)
                {
                    if (minItem.CompareTo(items[j]) > 0)
                    {
                        minItemIndex = j;
                        minItem = items[j];
                    }
                }

                if (minItemIndex != i)
                {
                    items[minItemIndex] = items[i];
                    items[i] = minItem;
                }
            }
        }
    }
}
