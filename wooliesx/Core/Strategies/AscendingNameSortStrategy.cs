using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wooliesx.Models;
using wooliesx.Services;

namespace wooliesx.Core
{
    internal class AscendingNameSortStrategy : ISortingStrategy
    {
        private readonly IDataProvider _dataProvider;

        public AscendingNameSortStrategy(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }
        public async Task<IEnumerable<Product>> Sort()
        {
            var result = await _dataProvider.GetProducts();

            return result.OrderBy(x => x.Name);
        }
    }
}