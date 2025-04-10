using Clothing_shop.Mappings;
using Clothing_shop.Repositories.IRepositories;
using Clothing_shop.Services.IService;
using Clothing_shop.VModel;
using Microsoft.AspNetCore.Mvc;
using OA.Domain.Common.Models;
using WebPizza_API_BackEnd.Common.Models;

namespace Clothing_shop.Services
{
    public class SizeService : ISizeService
    {
        private readonly ISizeRepo _sizeRepo;
        public SizeService(ISizeRepo sizeRepo)
        {
            _sizeRepo = sizeRepo;
        }
        public async Task<ActionResult<PaginationModel<SizeGetVModel>>> GetAll(SizeFilterParams parameters)
        {
            var sizes= await _sizeRepo.GetAll(parameters);
            var ds = sizes.Skip((parameters.PageNumber - 1) * parameters.PageSize)
                 .Take(parameters.PageSize).Select(x => SizeMapping.EntityToVmodel(x)).ToList();
            return new PaginationModel<SizeGetVModel>
            {
                Records = ds,
                TotalRecords = ds.Count
            };
        }
        public async Task<ActionResult<SizeGetVModel?>> GetById(int id)
        {
            var size = await _sizeRepo.GetById(id);
            if (size == null)
            {
                return new NotFoundObjectResult(new ErrorResponseResult
                {
                    IsSuccess = false,
                    Message = "Không tìm thấy size"

                });
            }
            return SizeMapping.EntityToVmodel(size);
        }
        public async Task<ResponseResult> Create(SizeCreateVModel size)
        {
            var response = new ResponseResult();
            try
            {
                var entity = SizeMapping.VModelToEntity(size);
                await _sizeRepo.Create(entity);
                response = new SuccessResponseResult(entity, "Thêm size thành công");
                return response;
            }
            catch(Exception ex)
            {
                return new ErrorResponseResult(ex.Message);
            }
        }
        public async Task<ResponseResult> Update(SizeUpdateVModel size)
        {
            var response = new ResponseResult();
            try
            {
                var entity = SizeMapping.VModelToEntity(size);
                await _sizeRepo.Update(entity);
                response = new SuccessResponseResult(entity, "Cập nhật size thành công");
                return response;
            }
            catch (Exception ex)
            {
                return new ErrorResponseResult(ex.Message);
            }
        }
        public async Task<ResponseResult> Delete(int id)
        {
            var response = new ResponseResult();
            try
            {
                var size = await _sizeRepo.GetById(id);
                if (size == null)
                {
                    return new ErrorResponseResult("Không tìm thấy size");
                }
                await _sizeRepo.Delete(size);
                response = new SuccessResponseResult(size,"Xóa size thành công");
                return response;
            }
            catch (Exception ex)
            {
                return new ErrorResponseResult(ex.Message);
            }
        }
    }
}
