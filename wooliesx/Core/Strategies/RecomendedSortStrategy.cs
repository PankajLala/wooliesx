using System.Collections.Generic;
using System.Threading.Tasks;
using wooliesx.Models;
using wooliesx.Services;
using System.Linq;

namespace wooliesx.Core
{
    internal class RecomendedSortStrategy : ISortingStrategy
    {
        private readonly IDataProvider _dataProvider;

        public RecomendedSortStrategy(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }
        public async Task<IEnumerable<Product>> Sort()
        {
            var result = await _dataProvider.GetShoppingHistory();


            return result.SelectMany(x => x.Products).GroupBy(p => p.Name)
                .Select(g => new Product {Name = g.Key, Price = g.First().Price , Quantity = g.Sum(c => c.Quantity)});
        }
    }
}