using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using wooliesx.Core;
using wooliesx.Models;

namespace wooliesx.Services
{
    public class ProductService : IProductService
    {
        private readonly ISortProvider _sortProvider;

        public ProductService(ISortProvider sortProvider)
        {
            _sortProvider = sortProvider;
        }
        public  async Task<IEnumerable<Product>> GetSortedList(SortOptions option)
        {
            var sortingStrategy =  _sortProvider.GetSortingStrategy(option);

            //Check for null
            Guard.Against.Null(sortingStrategy, nameof(option));

            return await sortingStrategy.Sort();
        }
    }
}
