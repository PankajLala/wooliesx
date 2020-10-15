using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wooliesx.Models;

namespace wooliesx.Core
{
    public class SortingStrategy:ISortingStrategy
    {
        public Task<IEnumerable<Product>> Sort()
        {
            throw new NotImplementedException();
        }
    }
}
