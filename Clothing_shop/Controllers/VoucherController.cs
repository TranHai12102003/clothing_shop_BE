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
    public class VoucherController : ControllerBase
    {
        private readonly IVoucherService _voucherService;
        public VoucherController(IVoucherService voucherService)
        {
            _voucherService = voucherService;
        }
        [HttpGet]
        public async Task<ActionResult<PaginationModel<VoucherGetVModel>>> GetAll([FromQuery] VoucherFilterParams parameters)
        {
            var result = await _voucherService.GetAll(parameters);
            if (result == null)
                return NotFound();
            return result;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<VoucherGetVModel>> GetById(int id)
        {
            var result = await _voucherService.GetById(id);
            if (result == null)
                return NotFound();
            return result;
        }
        [HttpPost]
        public async Task<ActionResult<ResponseResult>> Create([FromBody] VoucherCreateVModel VModel)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            var response = await _voucherService.Create(VModel);
            return response;
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseResult>> Update(int id, [FromBody] VoucherUpdateVModel VModel)
        {
            if (id <= 0 || id != VModel.Id)
            {
                return BadRequest();
            }
            var response = await _voucherService.Update(VModel);
            return response;
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseResult>> Remove(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var response = await _voucherService.Delete(id);
            return response;
        }
    }
}
