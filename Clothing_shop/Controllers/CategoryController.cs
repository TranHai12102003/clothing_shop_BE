using Clothing_shop.Services.IService;
using Clothing_shop.VModel;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.Domain.Common.Models;
using WebPizza_API_BackEnd.Common.Models;

namespace Clothing_shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<CategoryController> _logger;
        private readonly Cloudinary _cloudinary;
        public CategoryController(ICategoryService categoryService,Cloudinary cloudinary, ILogger<CategoryController> logger)
        {
            _categoryService = categoryService;
            _cloudinary = cloudinary;
            _logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult<PaginationModel<CategoryGetVModel>>> GetAll([FromQuery] CategoryFilterParams parameters)
        {
            var results = await _categoryService.GetAllCategories(parameters);
            return results;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryGetVModel>> GetById(int id)
        {
            var result = await _categoryService.GetCategoryById(id);
            if (result == null)
            {
                return NotFound(new ErrorResponseResult("Không tìm thấy danh mục"));
            }
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseResult>> Create([FromForm] CategoryCreateVModel model, IFormFile ImageFile)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            string imageUrl = null;
                if (ImageFile != null && ImageFile.Length > 0)
                {
                    string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };
                    var fileExtension = Path.GetExtension(ImageFile.FileName).ToLower();

                    if (!allowedExtensions.Contains(fileExtension))
                        return BadRequest("Unsupported file type");

                    var uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(ImageFile.FileName, ImageFile.OpenReadStream()),
                        Transformation = new Transformation().Width(500).Height(500).Crop("fill"),
                        Folder = "upload_clothingshop", //Chỉ định folder
                        UseFilename = true,
                        UniqueFilename = false // hoặc true nếu bạn muốn Cloudinary tự thêm hậu tố ngẫu nhiên
                    };
                    
                    var uploadResult = await _cloudinary.UploadAsync(uploadParams);

                    if (uploadResult.Error != null)
                    {
                        _logger.LogError("Cloudinary upload error: {ErrorMessage}", uploadResult.Error.Message);
                        return BadRequest($"Cloudinary upload failed: {uploadResult.Error.Message}");
                    }

                    imageUrl = uploadResult.SecureUrl.AbsoluteUri;

                }
            var response = await _categoryService.CreateCategory(model,imageUrl);
            return response;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseResult>> Update(int id, [FromForm] CategoryUpdateVModel model, IFormFile ImageFile)
        {
            try
            {
                // Kiểm tra danh mục có tồn tại hay không
                var existingCategory = await _categoryService.GetCategoryById(id);
                if (existingCategory == null)
                {
                    return NotFound(new ErrorResponseResult("Không tìm thấy danh mục"));

                }
                // Xử lý upload ảnh nếu có ảnh mới
                string imageUrl = existingCategory.Value?.ImageUrl; // Giữ ảnh cũ nếu không có ảnh mới
                if (ImageFile != null && ImageFile.Length > 0)
                {
                    string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };
                    var fileExtension = Path.GetExtension(ImageFile.FileName).ToLower();

                    if (!allowedExtensions.Contains(fileExtension))
                        return BadRequest(new { Message = "Unsupported file type" });

                    var uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(ImageFile.FileName, ImageFile.OpenReadStream()),
                        Transformation = new Transformation().Width(500).Height(500).Crop("fill"),
                        Folder = "upload_clothingshop", //Chỉ định folder
                        UseFilename = true,
                        UniqueFilename = false // hoặc true nếu bạn muốn Cloudinary tự thêm hậu tố ngẫu nhiên
                    };

                    var uploadResult = await _cloudinary.UploadAsync(uploadParams);

                    if (uploadResult.Error != null)
                    {
                        _logger.LogError("Cloudinary upload error: {ErrorMessage}", uploadResult.Error.Message);
                        return BadRequest(new { Message = $"Cloudinary upload failed: {uploadResult.Error.Message}" });
                    }

                    imageUrl = uploadResult.SecureUrl.AbsoluteUri;
                }

                // Gọi service để cập nhật sản phẩm
                model.ImageUrl = imageUrl; // Cập nhật URL ảnh vào model
                var result = await _categoryService.UpdateCategory(id, model);

                if (!result.IsSuccess)
                {
                    return BadRequest(new { Message = result.Message });
                }

                return Ok(new { Message = "Product updated successfully", ProductId = id });
            }
            catch (Exception ex)
            {
                _logger.LogError("Error updating product: {Error}", ex.Message);
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseResult>> Remove(int id)
        {
            var result = await _categoryService.DeleteCategory(id);
            if (result is ErrorResponseResult)
            {
                return NotFound(result);
            }
            return result;
        }
    }
}
