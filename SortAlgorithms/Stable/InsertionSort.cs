using System;
using System.Collections.Generic;

namespace SortAlgorithms.Stable
{
    public class InsertionSort : ISortAlgorithm
    {
        public IList<T> Sort<T>(IList<T> elements) where T : IComparable<T>
        {
            for (var i = 1; i < elements.Count; ++i)
            {
                var currentValue = elements[i];
                var j = i - 1;

                while (j >= 0 && elements[j].CompareTo(currentValue) > 0)
                {
                    elements[j + 1] = elements[j];
                    --j;
                }

                elements[j + 1] = currentValue;
            }

            return elements;
        }
    }


    public class InsertionSortOptimized : ISortAlgorithm
    {
        public int Start { get; } = 0;

        public int End { get; } = 0;

        public IList<T> Sort<T>(IList<T> elements) where T : IComparable<T>
        {
            T x, f;

            var start = Start;
            var end = End;

            if (end == 0 || end < 0)
                end = elements.Count - 1;

            if (start < 0)
                start = 0;

            if (start > End)
                start = End;

            var k = -1;
            var i = end;

            x = elements[i];

            while (i > start)
            {
                f = elements[i - 1];

                if (x.CompareTo(f) < 0)
                {
                    elements[i - 1] = x;
                    elements[i] = f;
                    k = i;
                }
                else
                {
                    x = f;
                }

                --i;
            }

            if (k < 0)
                return elements;

            i = start + 2;

            while (i <= end)
            {
                x = elements[i];
                k = i;
                var ok = true;

                while (ok)
                {
                    f = elements[k - 1];

                    if (x.CompareTo(f) < 0)
                    {
                        elements[k] = f;
                        --k;
                    }
                    else
                    {
                        ok = false;
                    }
                }

                if (k < i)
                    elements[k] = x;

                ++i;
            }

            return elements;
        }
    }
}
