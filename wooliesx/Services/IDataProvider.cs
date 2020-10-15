using System.Collections.Generic;
using System.Threading.Tasks;
using wooliesx.Models;

namespace wooliesx.Services
{
    public interface IDataProvider
    {
        Task<IEnumerable<Product>> GetProducts();

        Task<IEnumerable<Shopping>> GetShoppingHistory();
        
    }
}