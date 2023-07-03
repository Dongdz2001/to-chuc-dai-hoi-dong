using To_chuc_dai_hoi.Data;
using To_chuc_dai_hoi.DTO;

namespace To_chuc_dai_hoi.Repositories.ProductRepo
{
    public interface IProductService
    {
        Task<string> AddMultipleProductsAsync(List<ProductDTO> productList);
        Task<string> AddProductAsync(ProductDTO product);
        Task DeleteProductAsync(string productId);
        Task<List<Product>> GetAllProductsAsync();
        Task UpdateProductAsync(string productId, ProductDTO product);
    }
}
