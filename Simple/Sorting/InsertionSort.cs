using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Sorting
{
    /// <summary>
    /// Сортировка вставками
    /// </summary>
    public class InsertionSort : ISorting
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

            for (var i = 1; i < items.Count; i++)
            {
                for (var j = i; j > 0; j--)
                {
                    if (items[j].CompareTo(items[j - 1]) < 0)
                    {
                        var temp = items[j];
                        items[j] = items[j - 1];
                        items[j - 1] = temp;
                    }
                }
            }
        }
    }
}
