using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqDemo
{
    internal static class Program
    {
        private static void Main()
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            var result = arr.Where(s => s > 1);
            foreach (var s in result)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("======================MyWhere===============================");

            //MyWhere 
            var resule1 = MyWhere(arr, s => s > 1);
            foreach (var item in resule1)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("=======================MyWhereYield==============================");
            //MyWhereYield 
            var resule2 = MyWhereYield(arr, s => s > 1);
            foreach (var item in resule2)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// 自己实现的where
        /// </summary>
        /// <param name="arr">源</param>
        /// <param name="func">拉姆达</param>
        /// <typeparam name="T">类型</typeparam>
        /// <returns></returns>
        private static IEnumerable<T> MyWhere<T>(IEnumerable<T> arr, Func<T, bool> func)
        {
            List<T> result = new List<T>();

            foreach (var item in arr)
            {
                if (!func(item)) continue;
                Console.WriteLine("Mywhere:" + item);
                result.Add(item);
            }

            return result;

            #region print

            /*
            ======================MyWhere===============================
             Mywhere:2
             Mywhere:3
             Mywhere:4
             Mywhere:5
             2
             3
             4
             5
            */

            #endregion
        }


        /// <summary>
        /// yield 版 where
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="func">拉姆达</param>
        /// <typeparam name="T">类型</typeparam>
        /// <returns></returns>
        private static IEnumerable<T> MyWhereYield<T>(IEnumerable<T> source, Func<T, bool> func)
        {
            foreach (var item in source)
            {
                if (!func(item)) continue;
                Console.WriteLine("MyWhereYid:" + item);
                yield return item;
            }

            #region print

            /*
             *=======================MyWhereYield==============================
             MyWhereYid:2
             2
             MyWhereYid:3
             3
             MyWhereYid:4
             4
             MyWhereYid:5
             5
             */

            #endregion
        }
    }
}