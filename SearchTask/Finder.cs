using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchTask
{
    public class Finder
    {
        public void FindElementsForSum(List<uint> list, ulong sum, out int start, out int end)
        {
            if (list == null)
            {
                throw new NullReferenceException("List reference not set to an instance of an object.");
            }
            if (list.Count == 0)
            {
                throw new InvalidOperationException("List contains no elements");
            }
            start = end = 0;
        }
    }
}
