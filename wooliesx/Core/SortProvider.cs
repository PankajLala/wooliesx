using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Antiforgery;
using wooliesx.Models;
using wooliesx.Services;

namespace wooliesx.Core
{
    public class SortProvider:ISortProvider
    {
        private readonly IDataProvider _dataProvider;
        public SortProvider(IDataProvider dataProvider )
        {
            _dataProvider = dataProvider;
        }
        public ISortingStrategy GetSortingStrategy(SortOptions option)
        {
            return option switch
            {
                SortOptions.Low => new LowPriceSortStrategy(_dataProvider),
                SortOptions.High => new HighPriceSortStrategy(_dataProvider),
                SortOptions.Ascending => new AscendingNameSortStrategy(_dataProvider),
                SortOptions.Descending => new DescendingNameSortStrategy(_dataProvider),
                SortOptions.Recommended => new RecomendedSortStrategy(_dataProvider),
                _ => null,
            };
        }
    }
}
