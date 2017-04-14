using SortAlgorithms.Stable;
using System;
using System.Collections.Generic;
using System.Linq;
using SortAlgorithms.Unstable;

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

            for (var i = 0; i < count << 10; ++i)
            {
                var index = random.Next(0, originalElements.Count - 1);
                var otherIndex = random.Next(0, originalElements.Count - 1);
                var range = random.Next(5, 10);

                if (index + range < originalElements.Count - 1)
                    for (var rangeIndex = 0; rangeIndex < range; ++rangeIndex)
                        originalElements[index + rangeIndex] = originalElements[otherIndex];
            }

            var referenceElements = (from oe in originalElements
                                     orderby oe.Value
                                     select oe).ToList();

            Action < ISortAlgorithm, string> run = (sortAlgorithm, name) =>
            {
                var elements = new List<Element>(originalElements);

                var timeBefore = (double) Environment.TickCount;
                elements = (List<Element>) sortAlgorithm.Sort(elements);
                var timeAfter = (double) Environment.TickCount;

                Console.WriteLine(
                    "{0}: {1}s -- Sorting {2} -- {3}",
                    name, (timeAfter - timeBefore) / 1000.0,
                    elements.Where((t, i) => t.CompareTo(referenceElements[i]) != 0).Any() ? "FAILED" : "OK",
                    elements.Where((t, i) => t != referenceElements[i]).Any() ? "UNSTABLE" : "STABLE");
            };
                
            run(new InsertionSort(), "Insertion-Sort");
            run(new InsertionSortOptimized(), "Insertion-Sort-Optimized");
            run(new SelectionSort(), "Selection-Sort");
            run(new BubbleSort(), "Bubble-Sort");
            run(new ShellSort(), "Shell-Sort");
            run(new MergeSort(), "Merge-Sort");
            run(new Heapsort(), "Heap-Sort");
        }
    }
}
