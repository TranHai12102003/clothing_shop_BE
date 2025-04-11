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
    public class VariantController : ControllerBase
    {
        private readonly IVariantService _variantService;
        public VariantController(IVariantService variantService)
        {
            _variantService = variantService;
        }
        [HttpGet]
        public async Task<ActionResult<PaginationModel<VariantGetVModel>>> GetAll([FromQuery] VariantFilterParams parameters)
        {
            var variants = await _variantService.GetAll(parameters);
            return variants;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<VariantGetVModel?>> GetById(int id)
        {
            var variant = await _variantService.GetById(id);
            if (variant == null)
            {
                return NotFound("Không tìm thấy biến thể");
            }
            return variant;
        }
        [HttpPost]
        public async Task<ActionResult<ResponseResult>> Create([FromForm] VariantCreateVModel model)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            var response = await _variantService.Create(model);
            return response;
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseResult>> Update(int id, [FromForm] VariantUpdateVModel model)
        {
            if (id <= 0 || id != model.Id)
            {
                return BadRequest();
            }
            var response = await _variantService.Update(model);
            return response;
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseResult>> Delete(int id)
        {
            var response = await _variantService.Delete(id);
            return response;
        }
    }
}
