using ApiRest.Infraestructure.Dtos;
using ApiRest.Infraestructure.Helpers.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRest.Data.Operation
{
    public interface IProductService
    {
        public Task<List<ProductDto>> GetAllProducts();
        public Task<ProductDto> GetProductById(int id);
        public Task<ProductDto> CreateProductAsync(ProductDtoForCreate product);
        public Task<int> UpdateProductAsync(int id, ProductDtoForUpdate product);
        public Task<int> DeleteProductAsync(int id);
        ProductoCreateValidator ProductReg { get; set; }
        ProductUpdateValidator ProductUp { get; set; }
    }
}
