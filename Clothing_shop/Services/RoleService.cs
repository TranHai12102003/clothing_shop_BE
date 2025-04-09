using Clothing_shop.Entities;
using Clothing_shop.Mappings;
using Clothing_shop.Repositories;
using Clothing_shop.Repositories.IRepositories;
using Clothing_shop.Services.IService;
using Clothing_shop.VModel;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OA.Domain.Common.Models;
using WebPizza_API_BackEnd.Common.Models;

namespace Clothing_shop.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepo _roleRepo;
        public RoleService(IRoleRepo roleRepo)
        {
            _roleRepo = roleRepo;
        }

        public async Task<ResponseResult> Create(RoleCreateVModel vModel)
        {
            var response = new ResponseResult();
            try
            {
                var role = RoleMapping.VModelToEntity(vModel);
                await _roleRepo.Create(role);
                response = new SuccessResponseResult(role, "Thêm vai trò thành công");
                return response;
            }
            catch (Exception ex)
            {
                return new ErrorResponseResult(ex.Message);
            }
        }

        public async Task<ResponseResult> Delete(int id)
        {
            var role = await _roleRepo.GetById(id);
            if (role == null)
            {
                return new ErrorResponseResult("Không tìm thấy vai trò");
            }
            await _roleRepo.Delete(role);
            return new SuccessResponseResult("Xóa vai trò thành công");
        }

        public async Task<ActionResult<PaginationModel<RoleGetVModel>>> GetAll()
        {
            var colors = await _roleRepo.GetAll();
            var ds = colors.Select(x => RoleMapping.EntityGetVModel(x)).ToList();
            return new PaginationModel<RoleGetVModel>
            {
                Records = ds,
                TotalRecords = ds.Count
            };
        }

        public async Task<ActionResult<RoleGetVModel?>> GetById(int id)
        {
            var role = await _roleRepo.GetById(id);
            if (role == null)
            {
                return null;
            }
            return RoleMapping.EntityGetVModel(role);
        }

        public async Task<ResponseResult> Update(RoleUpdateVModel roleUpdateVModel)
        {
            var response = new ResponseResult();
            try
            {
                var entity = await _roleRepo.GetById(roleUpdateVModel.Id); // Dùng id từ tham số
                if (entity == null)
                {
                    return new ErrorResponseResult("Không tìm thấy vai trò");
                }
                entity.RoleName = roleUpdateVModel.RoleName;
                await _roleRepo.Update(entity);
                response = new SuccessResponseResult(entity, "Cập nhật vai trò thành công");
                return response;
            }
            catch (Exception ex)
            {
                return new ErrorResponseResult(ex.Message);
            }
        }
    }
}
