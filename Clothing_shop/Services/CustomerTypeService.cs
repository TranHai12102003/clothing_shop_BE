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
    public class CustomerTypeService : ICustomerTypeService
    {
        private readonly ICustomerTypeRepo _customerTypeRepo;
        public CustomerTypeService(ICustomerTypeRepo customerTypeRepo)
        {
            _customerTypeRepo = customerTypeRepo;
        }
        public async Task<ActionResult<PaginationModel<CustomerTypeGetVModel>>> GetAll()
        {
            var customerTypes = await _customerTypeRepo.GetAll();
            var ds = customerTypes.Select(x => CustomerTypeMapping.EntityToVModel(x)).ToList();
            return new PaginationModel<CustomerTypeGetVModel>
            {
                Records = ds,
                TotalRecords = ds.Count
            };
        }
        public async Task<ActionResult<CustomerTypeGetVModel>> GetById(int id)
        {
            var customerType = await _customerTypeRepo.GetById(id);
            if (customerType == null)
            {
                return null;
            }
            var result = CustomerTypeMapping.EntityToVModel(customerType);
            return result;
        }
        public async Task<ResponseResult> Create(CustomerTypeCreateVModel vModel)
        {
            var response = new ResponseResult();
            try
            {
                var customerType = CustomerTypeMapping.VModelToEntity(vModel);
                await _customerTypeRepo.Create(customerType);
                response = new SuccessResponseResult(customerType, "Thêm loại khách hàng thành công");
                return response;
            }
            catch (Exception ex)
            {
                return new ErrorResponseResult(ex.Message);
            }
        }
        public async Task<ResponseResult> Update(CustomerTypeUpdateVModel vModel)
        {
            var response = new ResponseResult();
            try
            {
                var customerType = CustomerTypeMapping.VModelToEntity(vModel);
                await _customerTypeRepo.Update(customerType);
                response = new SuccessResponseResult(customerType, "Cập nhật loại khách hàng thành công");
                return response;
            }
            catch (Exception ex)
            {
                return new ErrorResponseResult(ex.Message);
            }
        }
        public async Task<ResponseResult> Delete(int id)
        {
            var customerType = await _customerTypeRepo.GetById(id);
            if (customerType == null)
            {
                return new ErrorResponseResult("Không tìm thấy loại khách hàng");
            }
            await _customerTypeRepo.Delete(customerType);
            return new SuccessResponseResult("Xóa loại khách hàng thành công");
        }
    }
}
