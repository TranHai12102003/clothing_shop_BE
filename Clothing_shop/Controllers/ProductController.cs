using Clothing_shop.Services;
using Clothing_shop.Services.IService;
using Clothing_shop.VModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.Domain.Common.Models;
using WebPizza_API_BackEnd.Common.Models;

namespace Clothing_shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<ActionResult<PaginationModel<ProductGetVModel>>> GetAll([FromQuery] ProductFilterParams parameters)
        {
            var products = await _productService.GetAll(parameters);
            return products;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductGetVModel>> GetById(int id)
        {
            var product = await _productService.GetById(id);
            if (product == null)
            {
                return NotFound("Không tìm thấy sản phẩm");
            }
            return product;
        }
        [HttpGet("category/{categoryId}")]
        public async Task<ActionResult<PaginationModel<ProductGetVModel>>> GetByCategoryId([FromQuery] ProductFilterParams parameters, int categoryId)
        {
            var products = await _productService.GetByCategoryId(parameters, categoryId);
            return products;
        }
        [HttpPost]
        public async Task<ActionResult<ResponseResult>> Create([FromForm] ProductCreateVModel product)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            var response = await _productService.Create(product);
            return response;
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseResult>> Update(int id, [FromForm] ProductUpdateVModel product)
        {
            if (id <= 0 || id != product.Id)
            {
                return BadRequest();
            }
            var response = await _productService.Update(product);
            return response;
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseResult>> Remove(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var response = await _productService.Delete(id);
            return response;
        }
    }
}
