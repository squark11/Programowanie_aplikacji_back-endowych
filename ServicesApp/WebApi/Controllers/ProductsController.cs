using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Library.Data;
using WebApi.Library.Helpers;
using WebApi.Library.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsData _data;
        private readonly ILogSender _log;

        public ProductsController(IProductsData data, ILogSender log)
        {
            _data = data;
            _log = log;
        }
        [HttpGet]
        public async Task<IEnumerable<ProductModel>> Get()
        {
            var products = await _data.GetAsync();
            await Send(null,"Getting products", products.ToString());
            return await _data.GetAsync();
        }
        [Authorize]
        [HttpPost]
        public async Task Create(ProductAddModel product)
        {
            await _data.AddAsync(product);
            await Send($"{product}", $"Creating product", null);
        }
        [Authorize]
        [HttpPut("/UpdatePrice")]
        public async Task UpdatePrice(string productId, decimal newPrice)
        {
            await _data.UpdatePriceAsync(productId, newPrice);
            await Send($"{productId}, {newPrice}", $"Updating product price {productId} to {newPrice}", null);
        }
        [Authorize]
        [HttpPut("/UpdateQuantity")]
        public async Task UpdateQuantity(string productId, int newQuantity)
        {
            await _data.UpdateQuantityAsync(productId, newQuantity);
            await Send($"{productId}, {newQuantity}", $"Updating product quantity {productId} to {newQuantity}", null);
        }
        [Authorize]
        [HttpDelete]
        public async Task Delete(string productId)
        {
            await _data.Delete(productId);
            await Send(productId, $"Deleting product: {productId}", null);
        }
        private async Task Send(string? args, string descrioption, string? responseMessage)
        {
            await _log.Send(this.User?.Identity?.Name, this.Request?.Path.ToString(), this.Request?.Method, args, descrioption, responseMessage);
        }
    }
}
