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
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpGet]
        public async Task<ActionResult<PaginationModel<RoleGetVModel>>> GetAll()
        {
            var response = await _roleService.GetAll();
            return response;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<RoleGetVModel>> GetById(int id)
        {
            var response = await _roleService.GetById(id);
            if (response == null)
            {
                return NotFound();
            }
            return response;
        }
        [HttpPost]
        public async Task<ActionResult<ResponseResult>> Create(RoleCreateVModel model)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            var response = await _roleService.Create(model);
            return response;
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseResult>> Update(int id, RoleUpdateVModel model)
        {
            if (id <= 0 || id != model.Id)
            {
                return BadRequest();
            }
            var response = await _roleService.Update(model);
            return response;
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseResult>> Remove(int id)
        {
            if (id <= 0)
                return BadRequest();
            var response = await _roleService.Delete(id);
            return response;
        }
    }
}
