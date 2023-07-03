using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using To_chuc_dai_hoi.Data;
using To_chuc_dai_hoi.DTO;
using To_chuc_dai_hoi.Repositories.ProductRepo;

namespace To_chuc_dai_hoi.Repositories.ProductRePo
{
    public class ProductService : IProductService
    {
        private readonly ToChucDaiHoiContext _context;
        private readonly IMapper _mapper;

        public ProductService(ToChucDaiHoiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            var productList = await _context.Products.ToListAsync();
            return _mapper.Map<List<Product>>(productList);
        }

        public async Task<string> AddProductAsync(ProductDTO product)
        {
            var newProduct = _mapper.Map<Product>(product);
            newProduct.ProductId = Guid.NewGuid().ToString();
            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();
            return newProduct.ProductId.ToString();
        }

        public async Task DeleteProductAsync(string productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateProductAsync(string productId, ProductDTO product)
        {
            var productTemp = await _context.Products.FindAsync(productId);
            if (productTemp != null)
            {
                productTemp.Name = product.Name;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<string> AddMultipleProductsAsync(List<ProductDTO> productList)
        {
            if (productList.Count != 0)
            {
                var newProducts = new List<Product>();
                foreach (var productDTO in productList)
                {
                    var newProduct = _mapper.Map<Product>(productDTO);
                    newProduct.ProductId = Guid.NewGuid().ToString();
                    newProducts.Add(newProduct);
                }

                await _context.Products.AddRangeAsync(newProducts);
                await _context.SaveChangesAsync();

                return "Số lượng sản phẩm đã thêm: " + productList.Count;
            }

            return "Danh sách sản phẩm là rỗng";
        }
    }
    }
