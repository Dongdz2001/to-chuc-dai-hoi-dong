using To_chuc_dai_hoi.DTO;

namespace To_chuc_dai_hoi.Repositories.TinTucRePo
{
    public interface iTinTucService
    {
        Task<TintucDTO> AddTintucAsync(TintucDTO tintucDTO);
        Task AddMultipleTintucAsync(List<TintucDTO> tintucs);

        Task DeleteTintucAsync(int id);
        Task<List<TintucDTO>> GetAllTintucAsync();
        Task<TintucDTO> GetTintucByIdAsync(int id);
        Task UpdateTintucAsync(int id, TintucDTO tintucDTO);
    }
}
