using System.Linq.Expressions;
using Clothing_shop.Entities;
using Clothing_shop.Mappings;
using Clothing_shop.Repositories;
using Clothing_shop.Repositories.IRepositories;
using Clothing_shop.Services.IService;
using Clothing_shop.VModel;
using Microsoft.AspNetCore.Mvc;
using OA.Domain.Common.Models;
using WebPizza_API_BackEnd.Common.Models;

namespace Clothing_shop.Services
{
    public class ColorService : IColorService
    {
        private readonly IColorRepo _colorRepo;
        public ColorService(IColorRepo colorRepo)
        {
            _colorRepo = colorRepo;
        }

        public async Task<ResponseResult> Create(ColorCreateVModel model)
        {
            var response = new ResponseResult();
            try
            {
                var color = ColorMapping.VModelToEntity(model);
                await _colorRepo.AddAsync(color);
                response = new SuccessResponseResult(response, "Thêm màu sắc thành công");
                return response;
            }
            catch (Exception ex)
            {
                return new ErrorResponseResult(ex.Message);
            }
        }

        public async Task<ResponseResult> Delete(int id)
        {
            var color = await _colorRepo.GetByIdAsync(id);
            if (color == null)
            {
                return new ErrorResponseResult("Không tìm thấy màu sắc");
            }
            await _colorRepo.DeleteAsync(color);
            return new SuccessResponseResult("Xóa màu sắc thành công");
        }

        public async Task<ActionResult<PaginationModel<ColorGetVModel>>> GetAll(ColorFilterParams parameters)
        {
            var colors = await _colorRepo.GetAllAsync(parameters);
            var ds = colors.Skip((parameters.PageNumber - 1) * parameters.PageSize)
                 .Take(parameters.PageSize).Select(x => ColorMapping.EntityToVModel(x)).ToList();

            return new PaginationModel<ColorGetVModel>
            {
                Records = ds,
                TotalRecords = ds.Count
            };
        }

        public async Task<ActionResult<ColorGetVModel>> GetById(int id)
        {
            var color = await _colorRepo.GetByIdAsync(id);
            if (color == null)
            {
                return new NotFoundObjectResult(new ErrorResponseResult
                {
                    IsSuccess = false,
                    Message = "Không tìm thấy màu sắc"
                });
            }
            return ColorMapping.EntityToVModel(color);
        }

        public async Task<ResponseResult> Update(ColorUpdateVModel model)
        {
            try
            {
                var entity = await _colorRepo.GetByIdAsync(model.Id); // Dùng id từ tham số
                if (entity == null)
                {
                    return new ErrorResponseResult("Không tìm thấy màu sắc");
                }

                entity.ColorName = model.ColorName;
                entity.ColorCode = model.ColorCode;
                entity.CreatedDate = model.CreatedDate;
                entity.UpdatedDate = DateTime.Now;
                await _colorRepo.UpdateAsync(entity);

                return new SuccessResponseResult("Cập nhật màu sắc thành công");
            }
            catch (Exception ex)
            {
                return new ErrorResponseResult(ex.Message);
            }
        }
    }
}
