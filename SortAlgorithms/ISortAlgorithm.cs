using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms
{
    public interface ISortAlgorithm
    {
        IList<T> Sort<T>(IList<T> elements) where T : IComparable<T>;
    }
}
