using Clothing_shop.Entities;
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
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionService _promotionService;
        public PromotionController(IPromotionService promotionService)
        {
            _promotionService = promotionService;
        }
        [HttpGet]
        public async Task<ActionResult<PaginationModel<PromotionGetVModel>>> GetAll([FromQuery] PromotionFilterParams parameters)
        {
            var promotions = await _promotionService.GetAll(parameters);
            return promotions;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PromotionGetVModel>> GetById(int id)
        {
            var promotion = await _promotionService.GetById(id);
            return promotion;
        }
        [HttpPost]
        public async Task<ActionResult<ResponseResult>> Create([FromBody] PromotionCreateVModel model)
        {
            var response = await _promotionService.Create(model);
            return response;
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseResult>> Update(int id,[FromBody] PromotionUpdateVModel model)
        {
            if (id <= 0 || id != model.Id)
            {
                return BadRequest();
            }
            var response = await _promotionService.Update(model);
            return response;
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseResult>> Delete(int id)
        {
            var response = await _promotionService.Delete(id);
            return response;
        }
    }
}
