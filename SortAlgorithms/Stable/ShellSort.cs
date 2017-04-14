using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms.Stable
{
    public class ShellSort : ISortAlgorithm
    {
        public IList<T> Sort<T>(IList<T> elements) where T : IComparable<T>
        {
            var gaps = new [] { 701, 301, 132, 57, 23, 10, 4, 1 };

            foreach (var gap in gaps)
            {
                for (var i = gap; i < elements.Count; ++i)
                {
                    var tmp = elements[i];
                    var j = i;

                    for (; j >= gap && elements[j - gap].CompareTo(tmp) > 0; j -= gap)
                        elements[j] = elements[j - gap];

                    elements[j] = tmp;
                }
            }

            return elements;
        }
    }
}
