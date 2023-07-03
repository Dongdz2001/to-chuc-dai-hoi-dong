using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using To_chuc_dai_hoi.Data;
using To_chuc_dai_hoi.DTO;
using To_chuc_dai_hoi.Repositories.CategoriesRepo;

namespace To_chuc_dai_hoi.Repositories.CategoryRePo
{
    public class CategoryService : ICategoryService
    {
        private readonly ToChucDaiHoiContext _context;
        private readonly IMapper _mapper;

        public CategoryService(ToChucDaiHoiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            var categoryList = await _context.Categories.ToListAsync();
            return _mapper.Map<List<Category>>(categoryList);
        }

        public async Task<string> AddCategoryAsync(CategoryDTO category)
        {
            var newCategory = _mapper.Map<Category>(category);
            newCategory.CategoryId = Guid.NewGuid().ToString();
            await _context.Categories.AddAsync(newCategory);
            await _context.SaveChangesAsync();
            return newCategory.CategoryId.ToString();
        }

        public async Task DeleteCategoryAsync(string categoryId)
        {
            var category = await _context.Categories.FindAsync(categoryId);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateCategoryAsync(string categoryId, CategoryDTO category)
        {
            var categoryTemp = await _context.Categories.FindAsync(categoryId);
            if (categoryTemp != null)
            {
                categoryTemp.Name = category.Name;
                // Update other properties as needed
                await _context.SaveChangesAsync();
            }
        }

        public async Task<string> AddMultipleCategoriesAsync(List<CategoryDTO> categoryList)
        {
            if (categoryList.Count != 0)
            {
                var newCategories = new List<Category>();
                foreach (var categoryDTO in categoryList)
                {
                    var newCategory = _mapper.Map<Category>(categoryDTO);
                    newCategory.CategoryId = Guid.NewGuid().ToString();
                    newCategories.Add(newCategory);
                }

                await _context.Categories.AddRangeAsync(newCategories);
                await _context.SaveChangesAsync();

                return "Số lượng danh mục đã thêm: " + categoryList.Count;
            }

            return "Danh sách danh mục là rỗng";
        }

    }
}

