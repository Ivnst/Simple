using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simple.Sorting;

namespace Simple.Tests.Sorting
{
    public class BaseSortTesting
    {
        #region <Properties>

        //Минимальное значение в выборке
        private const int MinValue = -1000;

        //Максимальное значение в выборке
        private const int MaxValue = 1000;

        //Количество элементов в выборке
        private const int ItemsCount = 1000;
        
        //Количество итераций (попыток)
        private const int IterationsCount = 1;

        #endregion

        #region <Methods>

        /// <summary>
        /// Проверка указанного алгоритма сортировки на выборке случайных целочисленных элементов в указанном диапазоне
        /// </summary>
        /// <param name="sorting"></param>
        protected void SortTestRandom(ISorting sorting)
        {
            for (var i = 0; i < IterationsCount; i++)
            {
                //Генерируем исходные данные
                var items = GenerateRandomIntegerSequence(MinValue, MaxValue, ItemsCount);

                //Сортируем
                sorting.Perform(items);

                //Проверяем
                if (!CheckSequence(items, false))
                    Assert.Fail();
            }
        }

        /// <summary>
        /// Генерация последовательности целочисленных элементов, состоящей из указанного количества элементов.
        /// </summary>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        protected IList<int> GenerateRandomIntegerSequence(int minValue, int maxValue, int count)
        {
            if (minValue > maxValue) throw new ArgumentException("Invalid range");
            if (count < 0) throw new ArgumentException("Invalid count");

            var rnd = new Random((int)DateTime.Now.Ticks);
            var result = new List<int>();
            var range = maxValue - minValue;

            for (var i = 0; i < count; i++)
            {
                var val = rnd.Next(range) + minValue;
                result.Add(val);
            }

            return result;
        }

        /// <summary>
        /// Проверяет плавность возрастания или убывания заданной последовательности
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="descending"></param>
        /// <returns></returns>
        protected bool CheckSequence<T>(IList<T> items, bool descending) where T : IComparable<T>
        {
            if(items == null) throw new ArgumentNullException("items");
            if (items.Count < 2) return true;

            for (var i = 0; i < items.Count - 1; i++)
            {
                if(descending)
                {
                    if (items[i].CompareTo(items[i + 1]) < 0) return false;
                }
                else
                {
                    if (items[i].CompareTo(items[i + 1]) > 0) return false;
                }
            }
            return true;
        }

        #endregion
    }
}
