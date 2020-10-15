using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wooliesx.Models;
using wooliesx.Services;

namespace wooliesx.Core
{
    internal class DescendingNameSortStrategy : ISortingStrategy
    {
        private readonly IDataProvider _dataProvider;

        public DescendingNameSortStrategy(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }
        public async Task<IEnumerable<Product>> Sort()
        {
            var result = await _dataProvider.GetProducts();

            return result.OrderByDescending(x => x.Name);
        }
    }
}