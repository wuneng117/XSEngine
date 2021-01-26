using System;
using System.Collections.Generic;
using System.Threading;
/// <summary>
/// 这是一个线程安全的洗牌算法
/// https://stackoverflow.com/a/1262619
/// 
/// 使用范例
/// class Program
/// {
///     private static void Main(string[] args)
///     {
            // var numbers = new List<int>(Enumerable.Range(1, 75));
            // numbers.Shuffle();
            // Debug.Log("The winning numbers are: {0}" + string.Join(",  ", numbers.GetRange(0, 5)));
///     }
/// }
/// </summary>
namespace XSEngine
{
    public static class ThreadSafeRandom
    {
        [ThreadStatic] private static Random Local;

        public static Random ThisThreadsRandom
        {
            get { return Local ?? (Local = new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId))); }
        }
    }

    public static class MyExtensions
    {
        /// <summary> 洗混数组 </summary>
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}