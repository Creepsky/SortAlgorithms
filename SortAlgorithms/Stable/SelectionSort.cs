using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms.Stable
{
    public class SelectionSort : ISortAlgorithm
    {
        public IList<T> Sort<T>(IList<T> elements) where T : IComparable<T>
        {
            for (var i = 0; i < elements.Count; ++i)
            {
                var min = i;

                for (var j = i + 1; j < elements.Count; ++j)
                    if (elements[j].CompareTo(elements[min]) < 0)
                        min = j;

                var tmp = elements[i];
                elements[i] = elements[min];
                elements[min] = tmp;
            }

            return elements;
        }
    }
}
