using To_chuc_dai_hoi.Data;
using To_chuc_dai_hoi.DTO;

namespace To_chuc_dai_hoi.Repositories.PeopleChooseProductRepo
{
    public interface IPeopleChooseProductService
    {
        Task<string> AddPeopleChooseProductAsync(PeopleChooseProductDTO peopleChooseProduct);
        Task DeletePeopleChooseProductAsync(int id);
        Task<List<PeopleChooseProduct>> GetAllPeopleChooseProductsAsync();
        Task<List<dynamic>> GetPeopleProductCategories();
        Task<List<dynamic>> GetPeopleProductCategoriesDynamic();
        Task UpdatePeopleChooseProductAsync(int id, PeopleChooseProduct peopleChooseProduct);
    }
}
