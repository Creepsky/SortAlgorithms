using SortAlgorithms.Stable;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SortAlgorithms
{
    internal class Program
    {
        /// <summary>
        /// Just a class element for instance checking in/stability of algorithms
        /// </summary>
        internal class Element : IComparable<Element>
        {
            public int Value;

            public int CompareTo(Element other)
            {
                return Value.CompareTo(other.Value);
            }
        }

        private static void Main(string[] args)
        {
            var random = new Random();
            const int count = 1 << 15;
            var originalElements = new List<Element>(count);

            for (var i = 0; i < originalElements.Capacity; ++i)
                originalElements.Add(new Element { Value = random.Next() });

            var referenceElements = new List<Element>(originalElements);
            referenceElements.Sort();

            Action<ISortAlgorithm, string> run = (sortAlgorithm, name) =>
            {
                var elements = new List<Element>(originalElements);

                var timeBefore = (double) Environment.TickCount;
                elements = (List<Element>) sortAlgorithm.Sort(elements);
                var timeAfter = (double) Environment.TickCount;

                Console.WriteLine(
                    (!elements.Where((t, i) => t != referenceElements[i] || t.CompareTo(referenceElements[i]) != 0)
                        .Any()
                        ? "{0} is OK!"
                        : "{0} FAILED!") + " ({1}s)",
                    name, (timeAfter - timeBefore) / 1000.0);
            };
                
            run(new InsertionSort(), "Insertion-Sort");
            run(new InsertionSortOptimized(), "Insertion-Sort-Optimized");
            run(new SelectionSort(), "Selection-Sort");
            run(new BubbleSort(), "Bubble-Sort");
            run(new ShellSort(), "Shell-Sort");
            run(new MergeSort(), "Merge-Sort");
        }
    }
}
