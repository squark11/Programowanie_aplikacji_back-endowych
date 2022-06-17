using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Library.Data;
using WebApi.Library.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsData _data;

        public ProductsController(IProductsData data)
        {
            _data = data;
        }
        [HttpGet]
        public async Task<IEnumerable<ProductModel>> Get()
        {
            return await _data.GetAsync();
        }
        [Authorize]
        [HttpPost]
        public async Task Create(ProductAddModel product)
        {
            await _data.AddAsync(product);
        }
        [Authorize]
        [HttpPut("/UpdatePrice")]
        public async Task UpdatePrice(string productId, decimal newPrice)
        {
            await _data.UpdatePriceAsync(productId, newPrice);
        }
        [Authorize]
        [HttpPut("/UpdateQuantity")]
        public async Task UpdateQuantity(string productId, int newQuantity)
        {
            await _data.UpdateQuantityAsync(productId, newQuantity);
        }
        [Authorize]
        [HttpDelete]
        public async Task Delete(string productId)
        {
            await _data.Delete(productId);
        }
    }
}
