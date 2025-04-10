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
    public class SizeController : ControllerBase
    {
        private readonly ISizeService _sizeService;
        public SizeController(ISizeService sizeService)
        {
            _sizeService = sizeService;
        }
        [HttpGet]
        public async Task<ActionResult<PaginationModel<SizeGetVModel>>> GetAll([FromQuery] SizeFilterParams parameters)
        {
            var results = await _sizeService.GetAll(parameters);
            return results;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SizeGetVModel?>> GetById(int id)
        {
            var result = await _sizeService.GetById(id);
            if (result == null)
            {
                return NotFound(new ErrorResponseResult("Không tìm thấy size"));
            }
            return result;
        }
        [HttpPost]
        public async Task<ActionResult<ResponseResult>> Create([FromBody] SizeCreateVModel size)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            var result = await _sizeService.Create(size);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut]
        public async Task<ActionResult<ResponseResult>> Update([FromBody] SizeUpdateVModel size)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            var result = await _sizeService.Update(size);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseResult>> Delete(int id)
        {
            var result = await _sizeService.Delete(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
