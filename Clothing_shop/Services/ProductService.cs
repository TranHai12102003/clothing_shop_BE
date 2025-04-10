using Clothing_shop.Mappings;
using Clothing_shop.Repositories.IRepositories;
using Clothing_shop.Services.IService;
using Clothing_shop.VModel;
using Microsoft.AspNetCore.Mvc;
using OA.Domain.Common.Models;
using WebPizza_API_BackEnd.Common.Models;

namespace Clothing_shop.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepo;
        public ProductService(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<ResponseResult> Create(ProductCreateVModel product)
        {
            var response = new ResponseResult();
            try
            {
                var productSaved =ProductMapping.VModelToEntity(product);
                await _productRepo.Create(productSaved);
                response = new SuccessResponseResult(productSaved, "Thêm sản phẩm mới thành công");
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
                var product = await _productRepo.GetById(id);
                if (product == null)
                {
                    return new ErrorResponseResult("Không tìm thấy sản phẩm");
                }
                await _productRepo.Delete(product);
                response = new SuccessResponseResult("Xóa sản phẩm thành công");
                return response;
            }
            catch (Exception ex)
            {
                return new ErrorResponseResult(ex.Message);
            }
        }

        public async Task<ActionResult<PaginationModel<ProductGetVModel>>> GetAll(ProductFilterParams parameters)
        {
            var products = await _productRepo.GetAll(parameters);
            var ds = products.Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize).Select(x => ProductMapping.EntityToVModel(x)).ToList();
            return new PaginationModel<ProductGetVModel>
            {
                Records = ds,
                TotalRecords = ds.Count
            };
        }

        public async Task<ActionResult<PaginationModel<ProductGetVModel>>> GetByCategoryId(ProductFilterParams parameters, int categoryId)
        {
            var products = await _productRepo.GetByCategoryId(parameters, categoryId);
            var ds = products.Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize).Select(x => ProductMapping.EntityToVModel(x)).ToList();
            return new PaginationModel<ProductGetVModel>
            {
                Records = ds,
                TotalRecords = ds.Count
            };
        }

        public async Task<ActionResult<ProductGetVModel>> GetById(int id)
        {
            var product = await _productRepo.GetById(id);
            if (product == null)
            {
                return new NotFoundObjectResult(new ErrorResponseResult("Không tìm thấy sản phẩm"));
            }
            var productVModel = ProductMapping.EntityToVModel(product);
            return productVModel;
        }

        public async Task<ResponseResult> Update(ProductUpdateVModel product)
        {
            var response = new ResponseResult();
            try
            {
                var productSaved = ProductMapping.VModelToEntity(product);
                await _productRepo.Update(productSaved);
                response = new SuccessResponseResult(productSaved, "Cập nhật sản phẩm thành công");
                return response;
            }
            catch (Exception ex)
            {
                return new ErrorResponseResult(ex.Message);
            }
        }
    }
}
