using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using wooliesx.Models;
using wooliesx.Services;

namespace wooliesx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productsService;

        public ProductController(ILogger<ProductController> logger, IProductService productsService)
        {
            _logger = logger;
            _productsService = productsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(SortOptions sortOption)
        {
            var result = await _productsService.GetSortedList(sortOption);
            return Ok(result);
        }
    }
}
