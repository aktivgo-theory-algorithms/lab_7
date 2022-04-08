using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace task_1
{
    internal class Program
    {
        private static List<int> list;
        private static Stopwatch time;

        private const int N = 100000000;

        private const bool Print = false;

        public static void Main()
        {
            time = new Stopwatch();
            
            LineSearchTask();
            LineSearchBarrierTask();
            BubbleSortTask();
            SelectionSortTask();
        }

        private static void PrintList(List<int> list)
        {
            foreach (var element in list)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }
        
        private static void LineSearchTask()
        {
            Console.WriteLine("Линейный поиск");
            
            const int searchElement = 5;
            Console.WriteLine("Элемент поиска: " + searchElement);
            Console.WriteLine();
            
            // -----------------------------------------------
            list = CreateLineSearchBadList(N, searchElement);
            Console.WriteLine("Худший случай: ");

            if(Print) PrintList(list);

            time.Start();
            var res = LineSearch(list, searchElement);
            time.Stop();
            
            Console.WriteLine("time = " + (double)time.ElapsedMilliseconds / 1000000);
            
            Console.WriteLine((res == -1 ? "false" : "true: " + res) + "\n");
            
            time.Reset();
            
            // ------------------------------------------------
            list = CreateLineSearchRandomList(N);
            Console.WriteLine("Средний случай: ");

            if(Print) PrintList(list);

            time.Start();
            res = LineSearch(list, searchElement);
            time.Stop();
            
            Console.WriteLine("time = " + (double)time.ElapsedMilliseconds / 1000000);
            
            Console.WriteLine((res == -1 ? "false" : "true: " + res) + "\n");
            
            time.Reset();
            
            // ------------------------------------------------
            list = CreateLineSearchBestList(N, searchElement);
            Console.WriteLine("Лучший случай: ");

            if(Print) PrintList(list);

            time.Start();
            res = LineSearch(list, searchElement);
            time.Stop();
            
            Console.WriteLine("time = " + (double)time.ElapsedMilliseconds / 1000000);
            
            Console.WriteLine((res == -1 ? "false" : "true: " + res) + "\n");
            
            time.Reset();
        }
        
        private static void LineSearchBarrierTask()
        {
            Console.WriteLine("Линейный поиск с барьером");
            
            const int searchElement = 5;
            
            list = CreateLineSearchBadList(N, searchElement);

            if (Print) PrintList(list);

            time.Start();
            var res = LineSearchBarrier(list, searchElement);
            time.Stop();
            
            Console.WriteLine("time = " + (double)time.ElapsedMilliseconds / 1000);
            
            Console.WriteLine((res == -1 ? "false" : "true: " + res) + "\n");
            
            time.Reset();
        }

        private static void BubbleSortTask()
        {
            Console.WriteLine("Сортировка методом простого обмена");
            
            list = CreateSortBadList(N);

            if (Print) PrintList(list);

            time.Start();
            var res = BubbleSort(list);
            time.Stop();
            
            Console.WriteLine("time = " + (double)time.ElapsedMilliseconds / 1000);
            
            if (Print) PrintList(res);
            
            Console.WriteLine();
            
            time.Reset();
        }
        
        private static void SelectionSortTask()
        {
            Console.WriteLine("Сортировка методом простого выбора");
            
            list = CreateSortBadList(N);

            if (Print) PrintList(list);

            time.Start();
            var res = SelectionSort(list);
            time.Stop();
            
            Console.WriteLine("time = " + (double)time.ElapsedMilliseconds / 1000);
            
            if (Print) PrintList(res);
            Console.WriteLine();
            
            time.Reset();
        }

        private static List<int> CreateLineSearchBestList(int size, int searchElement)
        {
            var res = new List<int> { searchElement };
            
            for (var i = 0; i < size - 1; i++)
            {
                res.Add(i);
            }

            return res;
        }
        
        private static List<int> CreateLineSearchRandomList(int size)
        {
            var res = new List<int>();

            var rand = new Random();
            
            for (var i = 0; i < size; i++)
            {
                res.Add(rand.Next(0, size));
            }

            return res;
        }
        
        private static List<int> CreateLineSearchBadList(int size, int searchElement)
        {
            var res = new List<int>();

            for (var i = 0; i < size; i++)
            {
                res.Add(i == searchElement ? i + 1 : i);
            }

            return res;
        }
        
        private static List<int> CreateSortBadList(int size)
        {
            var res = new List<int>();

            for (var i = 0; i < size; i++)
            {
                res.Add(size - i);
            }

            return res;
        }

        private static int LineSearch(IReadOnlyList<int> list, int searchElement)
        {
            for (var i = 0; i < list.Count; i++)
            {
                if (list[i] == searchElement)
                {
                    return i;
                }
            }
            
            return -1;
        }
        
        private static int LineSearchBarrier(IList<int> list, int searchElement)
        {
            list.Add(searchElement);
            
            var i = 0;
            while (list[i] != searchElement)
            {
                i++;
            }

            return i < list.Count - 1 ? i : -1;
        }

        private static List<int> BubbleSort(IEnumerable<int> list)
        {
            var res = list.ToList();

            for (var i = 0; i < res.Count - 1; i++)
            {
                for (var j = 0; j < res.Count - 1; j++)
                {
                    if (res[j] > res[j + 1])
                    {
                        (res[j], res[j + 1]) = (res[j + 1], res[j]);
                    }
                }
            }

            return res;
        }
        
        private static List<int> SelectionSort(IEnumerable<int> list)
        {
            var res = list.ToList();

            for (var i = 0; i < res.Count - 1; i++)
            {
                var min = i;
                
                for (var j = i + 1; j < res.Count; j++)
                {
                    if (res[j] < res[min])
                    {
                        min = j;
                    }
                }
                
                (res[i], res[min]) = (res[min], res[i]);
            }

            return res;
        }
    }
}