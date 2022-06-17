using WebApi.Library.Models;

namespace WebApi.Library.Data
{
    public interface IProductsData
    {
        Task AddAsync(ProductAddModel model);
        Task Delete(string ProductId);
        Task<IEnumerable<ProductModel>> GetAsync();
        Task UpdatePriceAsync(string ProductId, decimal newPrice);
        Task UpdateQuantityAsync(string ProductId, int newQuantity);
    }
}