using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms.Stable
{
    public class BubbleSort : ISortAlgorithm
    {
        public IList<T> Sort<T>(IList<T> elements) where T : IComparable<T>
        {
            var n = elements.Count;

            do
            {
                var nn = 0;

                for (var i = 1; i <= n - 1; ++i)
                {
                    if (elements[i - 1].CompareTo(elements[i]) > 0)
                    {
                        var tmp = elements[i - 1];
                        elements[i - 1] = elements[i];
                        elements[i] = tmp;
                        nn = i;
                    }
                }

                n = nn;

            } while (n > 0);

            return elements;
        }
    }
}
