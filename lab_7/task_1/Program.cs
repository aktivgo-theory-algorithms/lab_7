using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace task_1
{
    internal static class Program
    {
        private static List<int> list;
        private static Stopwatch time;

        private static int N;

        private const bool PrintArrays = false;
        private const int SearchElement = 5;

        public static void Main()
        {
            time = new Stopwatch();

            ReadN();
            LineSearchTask(SearchElement);
            LineSearchBarrierTask(SearchElement);
            BubbleSortTask();
            SelectionSortTask();
        }

        private static void ReadN()
        {
            Console.Write("enter N: ");
            N = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.WriteLine();
        }

        private static void LineSearchTask(int searchElement)
        {
            Console.WriteLine("line search");
            
            PrintSearchElement(searchElement);
            
            // -----------------Worst case--------------------
            list = CreateLineSearchBadList(N, searchElement);
            Console.WriteLine("worst case");

            if (PrintArrays) PrintList(list);

            time.Start();
            var res = LineSearch(list, searchElement);
            time.Stop();
            
            PrintElapsedTime(time);
            PrintSearchResult(res);
            
            time.Reset();
            
            // -----------------Average case-------------------
            list = CreateLineSearchRandomList(N);
            Console.WriteLine("average case");

            if (PrintArrays) PrintList(list);

            time.Start();
            res = LineSearch(list, searchElement);
            time.Stop();
            
            PrintElapsedTime(time);
            PrintSearchResult(res);
            
            time.Reset();
            
            // ------------------Best case---------------------
            list = CreateLineSearchBestList(N, searchElement);
            Console.WriteLine("best case");

            if (PrintArrays) PrintList(list);

            time.Start();
            res = LineSearch(list, searchElement);
            time.Stop();
            
            PrintElapsedTime(time);
            PrintSearchResult(res);
            
            time.Reset();
        }
        
        private static void LineSearchBarrierTask(int searchElement)
        {
            Console.WriteLine("line search with barrier");

            PrintSearchElement(searchElement);
            
            // -----------------Worst case--------------------
            list = CreateLineSearchBadList(N, searchElement);
            Console.WriteLine("worst case");

            if (PrintArrays) PrintList(list);

            time.Start();
            var res = LineSearchBarrier(list, searchElement);
            time.Stop();
            
            PrintElapsedTime(time);
            PrintSearchResult(res);
            
            time.Reset();
            
            // -----------------Average case-------------------
            list = CreateLineSearchRandomList(N);
            Console.WriteLine("average case");

            if (PrintArrays) PrintList(list);

            time.Start();
            res = LineSearchBarrier(list, searchElement);
            time.Stop();
            
            PrintElapsedTime(time);
            PrintSearchResult(res);
            
            time.Reset();
            
            // ------------------Best case---------------------
            list = CreateLineSearchBestList(N, searchElement);
            Console.WriteLine("best case");

            if (PrintArrays) PrintList(list);

            time.Start();
            res = LineSearchBarrier(list, searchElement);
            time.Stop();
            
            PrintElapsedTime(time);
            PrintSearchResult(res);
            
            time.Reset();
        }

        private static void PrintSearchElement(int searchElement)
        {
            Console.WriteLine("search element: " + searchElement);
            Console.WriteLine();
        }
        
        private static void PrintSearchResult(int result)
        {
            Console.WriteLine((result == -1 ? "false" : "true: " + result) + "\n");
        }
        
        private static void PrintList(List<int> list)
        {
            foreach (var element in list)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }

        private static void BubbleSortTask()
        {
            Console.WriteLine("sorting by simple exchange method\n");
            
            // -----------------Worst case--------------------
            list = CreateSortBadList(N);
            Console.WriteLine("worst case");
            
            if (PrintArrays) PrintList(list);

            time.Start();
            var res = BubbleSort(list);
            time.Stop();
            
            PrintElapsedTime(time);
            
            if (PrintArrays) PrintList(res);
            
            Console.WriteLine();
            
            time.Reset();
            
            // -----------------Average case-------------------
            list = CreateSortRandomList(N);
            Console.WriteLine("average case");
            
            if (PrintArrays) PrintList(list);

            time.Start();
            res = BubbleSort(list);
            time.Stop();
            
            PrintElapsedTime(time);
            
            if (PrintArrays) PrintList(res);
            
            Console.WriteLine();
            
            time.Reset();
            
            // ------------------Best case---------------------
            list = CreateSortBestList(N);
            Console.WriteLine("best case");
            
            if (PrintArrays) PrintList(list);

            time.Start();
            res = BubbleSort(list);
            time.Stop();
            
            PrintElapsedTime(time);
            
            if (PrintArrays) PrintList(res);
            
            Console.WriteLine();
            
            time.Reset();
        }
        
        private static void SelectionSortTask()
        {
            Console.WriteLine("sorting by simple selection method\n");
            
            // -----------------Worst case--------------------
            list = CreateSortBadList(N);
            Console.WriteLine("worst case");

            if (PrintArrays) PrintList(list);

            time.Start();
            var res = SelectionSort(list);
            time.Stop();
            
            PrintElapsedTime(time);
            
            if (PrintArrays) PrintList(res);
            Console.WriteLine();
            
            time.Reset();
            
            // -----------------Average case-------------------
            list = CreateSortBadList(N);
            Console.WriteLine("average case");

            if (PrintArrays) PrintList(list);

            time.Start();
            res = SelectionSort(list);
            time.Stop();
            
            PrintElapsedTime(time);
            
            if (PrintArrays) PrintList(res);
            Console.WriteLine();
            
            time.Reset();
            
            // ------------------Best case---------------------
            list = CreateSortBadList(N);
            Console.WriteLine("best case");

            if (PrintArrays) PrintList(list);

            time.Start();
            res = SelectionSort(list);
            time.Stop();

            PrintElapsedTime(time);
            
            if (PrintArrays) PrintList(res);
            Console.WriteLine();
            
            time.Reset();
        }

        private static void PrintElapsedTime(Stopwatch time)
        {
            Console.WriteLine("time: " + time.ElapsedMilliseconds + "ms or " +  time.ElapsedTicks + "tc");
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
                res.Add(rand.Next(2 * size));
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
        
        private static List<int> CreateSortRandomList(int size)
        {
            var res = new List<int>();

            for (var i = 0; i < size; i++)
            {
                res.Add(i);
            }

            return res;
        }
        
        private static List<int> CreateSortBestList(int size)
        {
            var res = new List<int>();
            var rand = new Random();

            for (var i = 0; i < size; i++)
            {
                res.Add(rand.Next(size));
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