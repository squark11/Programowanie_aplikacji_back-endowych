using ServiceApp.Library.DbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Library.Models;

namespace WebApi.Library.Data
{
    public class ProductsData : IProductsData
    {
        private readonly ISqlDataAccess _data;
        private string dbName = "ServiceApp";

        public ProductsData(ISqlDataAccess data)
        {
            _data = data;
        }
        public async Task AddAsync(ProductAddModel model)
        {
            await _data.SaveDataAsync("sp_ProductsAdd", model, dbName);
        }
        public async Task<IEnumerable<ProductModel>> GetAsync()
        {
            return await _data.LoadDataAsync<ProductModel, dynamic>("sp_ProductsGet", new { }, dbName);
        }
        public async Task UpdatePriceAsync(string ProductId, decimal newPrice)
        {
            await _data.SaveDataAsync("sp_ProductsUpdatePrice", new { ProductId, NewPrice = newPrice }, dbName);
        }
        public async Task UpdateQuantityAsync(string ProductId, int newQuantity)
        {
            await _data.SaveDataAsync("sp_ProductsUpdateQuantity", new { ProductId, NewQuantity = newQuantity }, dbName);
        }
        public async Task Delete(string ProductId)
        {
            await _data.SaveDataAsync("sp_ProductsDel", new { ProductId }, dbName);
        }
    }
}
