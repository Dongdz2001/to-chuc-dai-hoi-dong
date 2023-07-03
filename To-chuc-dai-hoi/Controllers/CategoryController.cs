using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using To_chuc_dai_hoi.Data;
using To_chuc_dai_hoi.DTO;
using To_chuc_dai_hoi.Repositories.CategoriesRepo;
using To_chuc_dai_hoi.Repositories.CategoryRePo;

namespace To_chuc_dai_hoi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            try
            {
                return Ok(await _categoryService.GetAllCategoriesAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryDTO category)
        {
            try
            {
                await _categoryService.AddCategoryAsync(category);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddMultiple")]
        public async Task<IActionResult> AddMultipleCategories(List<CategoryDTO> categoryList)
        {
            try
            {
                string result = await _categoryService.AddMultipleCategoriesAsync(categoryList);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(string id, CategoryDTO category)
        {
            try
            {
                await _categoryService.UpdateCategoryAsync(id, category);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            try
            {
                await _categoryService.DeleteCategoryAsync(id);
                return Ok("Delete Succeeded " + id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

