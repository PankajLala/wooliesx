using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wooliesx.Models;

namespace wooliesx.Core
{
    public interface ISortingStrategy
    {
        Task<IEnumerable<Product>> Sort();
    }
}
