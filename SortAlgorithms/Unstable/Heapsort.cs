using System;
using System.Collections.Generic;

namespace SortAlgorithms.Unstable
{
    public class Heapsort : ISortAlgorithm
    {
        public IList<T> Sort<T>(IList<T> elements) where T : IComparable<T>
        {
            var heapSize = elements.Count;

            for (var p = (heapSize - 1) / 2; p >= 0; p--)
                Heapify(elements, heapSize, p);

            for (var i = elements.Count - 1; i > 0; i--)
            {
                var temp = elements[i];
                elements[i] = elements[0];
                elements[0] = temp;

                Heapify(elements, --heapSize, 0);
            }

            return elements;
        }

        private void Heapify<T>(IList<T> elements, int heapSize, int index) where T : IComparable<T>
        {
            var left = (index + 1) * 2 - 1;
            var right = (index + 1) * 2;
            int largest;

            if (left < heapSize && elements[left].CompareTo(elements[index]) > 0)
                largest = left;
            else
                largest = index;

            if (right < heapSize && elements[right].CompareTo(elements[largest]) > 0)
                largest = right;

            if (largest != index)
            {
                var temp = elements[index];
                elements[index] = elements[largest];
                elements[largest] = temp;

                Heapify(elements, heapSize, largest);
            }
        }
    }
}
