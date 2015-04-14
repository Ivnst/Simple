using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simple.Arithmetics;
using Simple.Sorting;

namespace Simple.Tests.Arithmetics
{
    [TestClass]
    public class ArithmeticsTests
    {
        /// <summary>
        /// Проверка алгоритма вычисления наибольшего общего делителя (НОД)
        /// </summary>
        [TestMethod]
        public void GCD_Test()
        {
            //Разные простые числа
            int[] nums1 = {2, 5, 11, 17, 23, 31, 41, 47, 59, 67, 73, 83, 97, 103, 109, 127, 137, 149};
            int[] nums2 = {3, 7, 13, 19, 29, 37, 43, 53, 61, 71, 79, 89, 101, 107, 113, 131, 139, 151};

            //Рандомайзер
            var rnd  = new Random((int)DateTime.Now.Ticks);

            for (int i = 0; i < 1000000; i++)
            {
                //Выбираем произвольное НОД, которое будем вычислять
                var gcd = rnd.Next(1000) + 1;

                var num1 = nums1[rnd.Next(nums1.Length)]*gcd;
                var num2 = nums2[rnd.Next(nums2.Length)]*gcd;
                Assert.AreEqual(gcd, Arith.GCD(num1, num2));
            }
            
        }

        /// <summary>
        /// Проверка алгоритма вычисления наибольшего общего делителя (НОД)
        /// </summary>
        [TestMethod]
        public void GCD_WithoutRecursion_Test()
        {
            //Разные простые числа
            int[] nums1 = { 2, 5, 11, 17, 23, 31, 41, 47, 59, 67, 73, 83, 97, 103, 109, 127, 137, 149 };
            int[] nums2 = { 3, 7, 13, 19, 29, 37, 43, 53, 61, 71, 79, 89, 101, 107, 113, 131, 139, 151 };

            //Рандомайзер
            var rnd = new Random((int)DateTime.Now.Ticks);

            for (int i = 0; i < 1000000; i++)
            {
                //Выбираем произвольное НОД, которое будем вычислять
                var gcd = rnd.Next(1000) + 1;

                var num1 = nums1[rnd.Next(nums1.Length)] * gcd;
                var num2 = nums2[rnd.Next(nums2.Length)] * gcd;
                Assert.AreEqual(gcd, Arith.GCD_WithoutRecursion(num1, num2));
            }

        }


        /// <summary>
        /// Проверка алгоритма вычисления наименьшего общего кратного (НОК)
        /// </summary>
        [TestMethod]
        public void LCM_Test()
        {
            //Разные простые числа
            int[] nums =
            {
                2, 3, 5, 7, 11, 13, 17,
                19, 23, 29, 31, 37, 41,
                43, 47, 53, 59, 61, 67,
                71, 73, 79, 83, 89, 97,
                101, 103, 107, 109, 113,
                127, 131, 137, 139, 149,
                151, 157
            };

            //Рандомайзер
            var rnd = new Random((int) DateTime.Now.Ticks);

            for (int i = 0; i < 1000000; i++)
            {
                var num1 = nums[rnd.Next(nums.Length)];
                var num2 = nums[rnd.Next(nums.Length)];

                var lcm = num1*num2;

                if (num1 == num2)
                {
                    Assert.AreEqual(num1, Arith.LCM(num1, num2));
                }
                else
                {
                    Assert.AreEqual(lcm, Arith.LCM(num1, num2));
                }
                
            }

        }
    }

}
