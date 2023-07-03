using To_chuc_dai_hoi.Data;
using To_chuc_dai_hoi.DTO;

namespace To_chuc_dai_hoi.Repositories.CategoriesRepo
{
    public interface ICategoryService
    {
        Task<string> AddCategoryAsync(CategoryDTO category);
        Task<string> AddMultipleCategoriesAsync(List<CategoryDTO> categoryList);
        Task DeleteCategoryAsync(string categoryId);
        Task<List<Category>> GetAllCategoriesAsync();
        Task UpdateCategoryAsync(string categoryId, CategoryDTO category);
    }
}
