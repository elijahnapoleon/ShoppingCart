using Microsoft.AspNetCore.Mvc;
using ShoppingCart.API.EC;
using ShoppingCartLibrary.Models;
using ShoppingCartLibrary.DTO;

namespace ShoppingCart.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly ILogger<InventoryController> _logger;
        public InventoryController(ILogger<InventoryController> logger)
        {
            _logger = logger;
        }

        [HttpGet()]
        public async Task<IEnumerable<Item>> Get()
        {
            return await new InventoryEC().Get();
        }

        [HttpPost("Search")]
        public async Task<IEnumerable<Item>> Get(Query query)
        {
            return await new InventoryEC().Search(query.QueryString);
        }

        [HttpPost()]
        public async Task<Item> AddOrUpdate([FromBody] Item p)
        {
            return await new InventoryEC().AddOrUpdate(p);
        }

        [HttpDelete("/{id}")]
        public async Task<Item?> Delete(int id)
        {
            return await new InventoryEC().Delete(id);
        }
    }
}
