using System;
using System.Collections.Generic;

namespace Simple.Sorting
{
    /// <summary>
    /// Интерфейс для алгоритма сортировки
    /// </summary>
    public interface ISorting
    {
        /// <summary>
        /// Сортировка указанных элементов
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        void Perform<T>(IList<T> items) where T : IComparable<T>;
    }
}
