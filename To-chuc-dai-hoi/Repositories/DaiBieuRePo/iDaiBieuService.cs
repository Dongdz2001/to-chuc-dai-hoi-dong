using To_chuc_dai_hoi.Data;
using To_chuc_dai_hoi.DTO;

namespace To_chuc_dai_hoi.Repositories.DaiBieuRePo
{
    public interface iDaiBieuService
    {
        Task<string> AddDaiBieuAsync(DaiBieuDTO daibieu);
        Task<string> AddMultiplelDaiBieuAsync(List<DaiBieuDTO> listDaiBieu);
        Task DeleteDaiBieuAsync(string id);
        Task<List<DaiBieu>> GetAllDaiBieuAsync();
        Task UpdateDaiBieuAsync(string id, DaiBieu daibieu);
    }
}