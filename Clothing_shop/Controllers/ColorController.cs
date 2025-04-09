using Clothing_shop.Services.IService;
using Clothing_shop.VModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using OA.Domain.Common.Models;
using WebPizza_API_BackEnd.Common.Models;

namespace Clothing_shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly IColorService _colorService;
        public ColorController(IColorService colorService) { 
            _colorService = colorService;
        }
        [HttpGet]
        public async Task<ActionResult<PaginationModel<ColorGetVModel>>> GetAll([FromQuery] ColorFilterParams parameters)
        {
            var response = await _colorService.GetAll(parameters);
            return response;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ColorGetVModel>> GetById(int id)
        {
            var response = await _colorService.GetById(id);
            if(response == null)
            {
                return NotFound();
            }
            return response;
        }
        [HttpPost]
        public async Task<ActionResult<ResponseResult>> Create(ColorCreateVModel model)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            var response = await _colorService.Create(model);
            return response;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseResult>> Update(int id, ColorUpdateVModel model)
        {
            if (id <= 0 || id != model.Id)
            {
                return BadRequest();
            }
            var response = await _colorService.Update(model);
            return response;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseResult>> Remove(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var response = await _colorService.Delete(id);
            return response;
        }
    }
}
