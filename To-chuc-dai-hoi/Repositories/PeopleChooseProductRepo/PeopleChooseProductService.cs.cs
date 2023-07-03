using AutoMapper;
using Microsoft.EntityFrameworkCore;
using To_chuc_dai_hoi.Data;
using To_chuc_dai_hoi.DTO;
using To_chuc_dai_hoi.Repositories.PeopleChooseProductRepo;

namespace To_chuc_dai_hoi.Repositories.PeopleChooseProductRePo
{
    public class PeopleChooseProductService : IPeopleChooseProductService
    {
        private readonly ToChucDaiHoiContext _context;
        private readonly IMapper _mapper;

        public PeopleChooseProductService(ToChucDaiHoiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<dynamic>> GetPeopleProductCategories()
        {
            var query = from peopleChooseProduct in _context.PeopleChooseProducts
                        join product in _context.Products on peopleChooseProduct.ProductId equals product.ProductId
                        join ProductCategory in _context.ProductCategories on product.ProductId equals ProductCategory.ProductId
                        join category in _context.Categories on ProductCategory.CategoryId equals category.CategoryId
                        group new { peopleChooseProduct, product, category } by new { peopleChooseProduct.Id, peopleChooseProduct.PersonName, peopleChooseProduct.Contact, product.Name, CaName = category.Name } into grouped
                        select new
                        {
                            STT = grouped.Key.Id,
                            Tên_người = grouped.Key.PersonName,
                            Liên_hệ = grouped.Key.Contact,
                            Tên_sản_phẩm = grouped.Key.Name,
                            Thể_loại = grouped.Key.CaName,
                            Số_lương_sản_phẩm = grouped.Sum(x => x.peopleChooseProduct.Quantity)
                        };

            return await query.ToListAsync<dynamic>();
        }

        public async Task<List<dynamic>> GetPeopleProductCategoriesDynamic()
        {
            var query = from peopleChooseProduct in _context.PeopleChooseProducts
                        join product in _context.Products on peopleChooseProduct.ProductId equals product.ProductId into productGroup
                        from product in productGroup.DefaultIfEmpty()
                        group new { peopleChooseProduct, product } by new { peopleChooseProduct.PersonName, peopleChooseProduct.Contact } into grouped
                        select new
                        {
                            Tên_người = grouped.Key.PersonName,
                            Liên_hệ = grouped.Key.Contact,
                            Sản_Phẩm_yêu_cầu = string.Join(", ", grouped.Select(x => x.product.Name))
                        };

            var result = await query.ToListAsync<dynamic>();

            // Assign STT
            for (int i = 0; i < result.Count; i++)
            {
                result[i] = new
                {
                    STT = i + 1,
                    result[i].Liên_hệ,
                    result[i].Tên_người,
                    result[i].Sản_Phẩm_yêu_cầu
                };
            }

            return result;
        }

        public async Task<List<PeopleChooseProduct>> GetAllPeopleChooseProductsAsync()
        {
            var PeopleChooseAlls = await _context.PeopleChooseProducts.ToListAsync();
            return _mapper.Map<List<PeopleChooseProduct>>(PeopleChooseAlls);
        }

        public async Task<string> AddPeopleChooseProductAsync(PeopleChooseProductDTO peopleChooseProduct)
        {
            var newPeopleChooseProduct = _mapper.Map<PeopleChooseProduct>(peopleChooseProduct);
            await _context.PeopleChooseProducts.AddAsync(newPeopleChooseProduct);
            await _context.SaveChangesAsync();
            return newPeopleChooseProduct.Id.ToString();
        }

        public async Task DeletePeopleChooseProductAsync(int id)
        {
            var peopleChooseProduct = await _context.PeopleChooseProducts.FindAsync(id);
            if (peopleChooseProduct != null)
            {
                _context.PeopleChooseProducts.Remove(peopleChooseProduct);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdatePeopleChooseProductAsync(int id, PeopleChooseProduct peopleChooseProduct)
        {
            var existingPeopleChooseProduct = await _context.PeopleChooseProducts.FindAsync(id);
            if (existingPeopleChooseProduct != null)
            {
                existingPeopleChooseProduct.PersonName = peopleChooseProduct.PersonName;
                existingPeopleChooseProduct.Contact = peopleChooseProduct.Contact;
                existingPeopleChooseProduct.ProductId = peopleChooseProduct.ProductId;
                existingPeopleChooseProduct.Quantity = peopleChooseProduct.Quantity;
                await _context.SaveChangesAsync();
            }
        }
    }
}
