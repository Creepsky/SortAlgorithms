using System;
using System.Collections.Generic;
using System.Linq;

namespace SortAlgorithms.Stable
{
    public class MergeSort : ISortAlgorithm
    {
        public IList<T> Sort<T>(IList<T> elements) where T : IComparable<T>
        {
            if (elements.Count <= 1)
                return elements;

            var middle = elements.Count / 2;
            IList<T> left = elements.Take(middle).ToList();
            IList<T> right = elements.Skip(middle).ToList();

            left = Sort(left);
            right = Sort(right);

            return Merge(left, right);
        }

        private static IList<T> Merge<T>(IList<T> left, IList<T> right) where T : IComparable<T>
        {
            var elements = CreateEmptyList<T>(left.Count + right.Count);
            int l = 0, r = 0, s = 0;

            while (l < left.Count && r < right.Count)
            {
                if (left[l].CompareTo(right[r]) < 0)
                    elements[s++] = left[l++];
                else
                    elements[s++] = right[r++];
            }

            while (l < left.Count)
                elements[s++] = left[l++];

            while (r < right.Count)
                elements[s++] = right[r++];

            return elements;
        }

        private static List<T> CreateEmptyList<T>(int count)
        {
            var list = new List<T>(count);
            list.AddRange(Enumerable.Repeat(default(T), count));
            return list;

        }
    }
}
