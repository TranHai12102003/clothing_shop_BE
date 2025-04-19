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
    public class CustomerTypeController : ControllerBase
    {
        private readonly ICustomerTypeService _customerTypeService;
        public CustomerTypeController(ICustomerTypeService customerTypeService)
        {
            _customerTypeService = customerTypeService;
        }
        [HttpGet]
        public async Task<ActionResult<PaginationModel<CustomerTypeGetVModel>>> GetAll()
        {
            var result = await _customerTypeService.GetAll();
            return result;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerTypeGetVModel>> GetById(int id)
        {
            var result = await _customerTypeService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }
        [HttpPost]
        public async Task<ActionResult<ResponseResult>> Create([FromBody] CustomerTypeCreateVModel vModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _customerTypeService.Create(vModel);
            return result;
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseResult>> Update(int id, CustomerTypeUpdateVModel vModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _customerTypeService.Update(vModel);
            return result;
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseResult>> Delete(int id)
        {
            var result = await _customerTypeService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }
    }
}
