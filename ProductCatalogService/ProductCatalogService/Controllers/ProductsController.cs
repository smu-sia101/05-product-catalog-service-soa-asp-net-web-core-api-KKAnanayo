using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using ProductCatalogService.Data;
using ProductCatalogService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductCatalogService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMongoCollection<Product> _products;

        public ProductsController(ProductCatalogContext context)
        {
            _products = context.Products;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _products.Find(product => true).ToListAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(string id)
        {
            var product = await _products.Find<Product>(p => p.Id == id).FirstOrDefaultAsync();
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            // Ensure the Id is not set by the client
            product.Id = null;

            await _products.InsertOneAsync(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(string id, Product updatedProduct)
        {
            var result = await _products.ReplaceOneAsync(p => p.Id == id, updatedProduct);
            if (result.MatchedCount == 0)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var result = await _products.DeleteOneAsync(p => p.Id == id);
            if (result.DeletedCount == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
