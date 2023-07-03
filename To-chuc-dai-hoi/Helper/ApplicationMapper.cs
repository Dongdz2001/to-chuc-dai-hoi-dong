using AutoMapper;
using To_chuc_dai_hoi.Data;
using To_chuc_dai_hoi.DTO;

namespace To_chuc_dai_hoi.Helper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<DaiBieu, DaiBieuDTO>().ReverseMap();
            CreateMap<Tintuc, TintucDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<PeopleChooseProduct, PeopleChooseProductDTO>().ReverseMap();

        }
    }
}
