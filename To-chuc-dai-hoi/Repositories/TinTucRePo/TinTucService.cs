using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using To_chuc_dai_hoi.Data;
using To_chuc_dai_hoi.DTO;
using To_chuc_dai_hoi.Repositories.TinTucRePo;

namespace To_chuc_dai_hoi.Services
{
    public class TintucService : iTinTucService
    {
        private readonly ToChucDaiHoiContext _context;
        private readonly IMapper _mapper;

        public TintucService(ToChucDaiHoiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TintucDTO>> GetAllTintucAsync()
        {
            var tintuc = await _context.Tintucs.ToListAsync();
            return _mapper.Map<List<TintucDTO>>(tintuc);
        }

        public async Task<TintucDTO> GetTintucByIdAsync(int id)
        {
            var tintuc = await _context.Tintucs.FindAsync(id);
            return _mapper.Map<TintucDTO>(tintuc);
        }

        public async Task<TintucDTO> AddTintucAsync(TintucDTO tintucDTO)
        {
            var tintuc = _mapper.Map<Tintuc>(tintucDTO);
            tintuc.Id = Guid.NewGuid().ToString();
            _context.Tintucs.Add(tintuc);
            await _context.SaveChangesAsync();

            return _mapper.Map<TintucDTO>(tintuc);
        }

        public async Task AddMultipleTintucAsync(List<TintucDTO> tintucs)
        {
            List<Tintuc> tintucList = new List<Tintuc>();
            foreach (var tintuc in tintucs)
            {
                tintuc.Id = System.Guid.NewGuid().ToString();
                var tintucmoi = _mapper.Map<Tintuc>(tintuc);
                tintucList.Add(tintucmoi);
            }
            await _context.Tintucs.AddRangeAsync(tintucList);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateTintucAsync(int id, TintucDTO tintucDTO)
        {
            var tintucToUpdate = await _context.Tintucs.FindAsync(id);

            if (tintucToUpdate != null)
            {
                _mapper.Map(tintucDTO, tintucToUpdate);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteTintucAsync(int id)
        {
            var tintuc = await _context.Tintucs.FindAsync(id);
            if (tintuc != null)
            {
                _context.Tintucs.Remove(tintuc);
                await _context.SaveChangesAsync();
            }
        }
    }
}
