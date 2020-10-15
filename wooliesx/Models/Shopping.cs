using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wooliesx.Models
{
    public class Shopping
    {
        public int CustomerId { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
