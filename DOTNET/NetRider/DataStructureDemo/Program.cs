using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructureDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Arror 数组
            
            MyArrayList arrayList = new MyArrayList();
            for (int i = 0; i < 10; i++)
            {
                arrayList.Add(i, i);
            }

            Console.WriteLine(arrayList);

            #endregion

            #region Link 链表

            #endregion

            #region 集合 Set

            #endregion

            #region 字典

            #endregion

            Console.WriteLine("Hello World!");
        }
    }
}