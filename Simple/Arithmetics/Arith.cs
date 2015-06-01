using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Arithmetics
{
    /// <summary>
    /// Некоторые алгоритмы из арифметики
    /// </summary>
    public static class Arith
    {
        /// <summary>
        /// Greatest Common Divisor (Наибольший общий делитель, НОД) для заданных двух чисел
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a%b);
        }


        /// <summary>
        /// Greatest Common Divisor (Наибольший общий делитель, НОД) для заданных двух чисел (без рекурсии)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static int GCD_WithoutRecursion(int a, int b)
        {
            while (true)
            {
                if (b == 0) return a;
                var a1 = a;
                a = b;
                b = a1%b;
            }
        }

        /// <summary>
        /// Least Common Multiplier (Наименьшее общее кратное, НОК) для заданных двух чисел
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static int LCM(int a, int b)
        {
            return a/GCD(a, b)*b;
        }

        /// <summary>
        /// Факториал числа (с рекурсией)
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int Factorial(int a)
        {
            if (a <= 1) return 1;
            return Factorial(a - 1)*a;
        }

        /// <summary>
        /// Факториал числа (без рекурсией)
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int Factorial_WithoutRecursion(int a)
        {
            if (a <= 1) return 1;
            int result = 1;
            for (int i = 1; i <= a; i++)
                result *= i;
            return result;
        }
    }
}
