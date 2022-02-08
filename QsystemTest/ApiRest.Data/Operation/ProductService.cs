using ApiRest.Data.Entities;
using ApiRest.Data.Repository.Interface;
using ApiRest.Infraestructure.Dtos;
using ApiRest.Infraestructure.Helpers.Validators;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRest.Data.Operation
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductoCreateValidator ProductReg { get; set ; } = new ProductoCreateValidator();
        public ProductUpdateValidator ProductUp { get; set; } = new ProductUpdateValidator();

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }
        public async Task<List<ProductDto>> GetAllProducts()
        {
            return mapper.Map<List<ProductDto>>(await productRepository.GetAllAsync());
        }
        public async Task<ProductDto> GetProductById(int id)
        {
            return mapper.Map<ProductDto>(await productRepository.GetByIdAsync(id));
        }
        public async Task<ProductDto> CreateProductAsync(ProductDtoForCreate product)
        {
            if (product.FechaRegistro == DateTime.MinValue)
            {
                product.FechaRegistro = DateTime.Now;
            }

            var result = await productRepository.CreateAsync(mapper.Map<Producto>(product));

            if (result != 0 && result > 0)
            {
                var prod = await GetProductById(result);

                return prod ?? null;
            }
            else
                return null;
        }
        public async Task<int> UpdateProductAsync(int id, ProductDtoForUpdate product)
        {
            var productBase = await productRepository.GetByIdAsync(id);

            if (productBase != null)
            {
                mapper.Map(product, productBase);

                return await productRepository.UpdateAsync(productBase);
            }
            else
            {
                return 0;
            }
        }

        public async Task<int> DeleteProductAsync(int id)
        {
            var product = await productRepository.GetByIdAsync(id);
            if (product != null)
            {
                return await productRepository.DeleteAsync(mapper.Map<Producto>(product));
            }
            else
            {
                return 0;
            }
        }

    }
}
