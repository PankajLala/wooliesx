using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wooliesx.Models;

namespace wooliesx.Core
{
    public interface ISortProvider
    {
        ISortingStrategy GetSortingStrategy(SortOptions option);
    }
}
