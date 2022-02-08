using ApiRest.Data.Operation;
using ApiRest.Infraestructure.Dtos;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProductos()
        {
            try
            {
                return Ok(await productService.GetAllProducts());
            }
            catch (Exception ex)
            {
                return StatusCode(500,$"error no se pudo procesar la peticion {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProduct(int id)
        {
            try
            {
                var product = await productService.GetProductById(id);

                return (product != null) ? Ok(product) : NotFound("El producto no existe");
            }
            catch (Exception ex)
            {
                return StatusCode(500,$"error no se pudo procesar la peticion {ex.Message}");
            }
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDtoForCreate product)
        {
            try
            {
                if (product == null)
                {
                    return NotFound();
                }

                productService.ProductReg.Validate(product, options => options.ThrowOnFailures());

                //if (!productService.ProductReg.Validate(product).IsValid)
                //{
                //    productService.ProductReg.ValidateAndThrow(product);
                //}

                var response = await productService.CreateProductAsync(product);

                return (response != null) ? CreatedAtAction(nameof(GetProduct), new { id = response.Id}, response): BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500,$"error no se pudo procesar la peticion {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDtoForUpdate product)
        {
            try
            {
                if (id == 0 || id < 0 || product == null)
                {
                    return NotFound();
                }

                productService.ProductUp.Validate(product, options => options.ThrowOnFailures());

                var response = await productService.UpdateProductAsync(id,product);

                return (response != 0) ? Ok() : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"error no se pudo procesar la peticion {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                if (id == 0 || id < 0)
                {
                    return NotFound();
                }

                var response = await productService.DeleteProductAsync(id);

                return (response != 0) ? Ok() : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"error no se pudo procesar la peticion {ex.Message}");
            }
        }

    }
}
