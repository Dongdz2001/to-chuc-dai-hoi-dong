using AutoMapper;
using Microsoft.EntityFrameworkCore;
using To_chuc_dai_hoi.Data;
using To_chuc_dai_hoi.DTO;

namespace To_chuc_dai_hoi.Repositories.DaiBieuRePo
{
    public class DaiBieuService : iDaiBieuService
    {
        private readonly ToChucDaiHoiContext _contex;
        private readonly IMapper _mapper;

        public DaiBieuService(ToChucDaiHoiContext context, IMapper mapper)
        {
            _contex = context;
            _mapper = mapper;
        }

        public async Task<List<DaiBieu>> GetAllDaiBieuAsync()
        {
            var listDaiBieu = _contex.DaiBieus.ToListAsync().Result;
            return _mapper.Map<List<DaiBieu>>(listDaiBieu);
        }


        public async Task<string> AddDaiBieuAsync(DaiBieuDTO daibieu)
        {
            daibieu.Id = System.Guid.NewGuid().ToString();
            var newDaiBieu = _mapper.Map<DaiBieu>(daibieu);
            await _contex.DaiBieus.AddAsync(newDaiBieu);
            await _contex.SaveChangesAsync();
            return daibieu.Id;
        }

        public async Task DeleteDaiBieuAsync(string id)
        {
            var daiBieu = await _contex.DaiBieus.SingleOrDefaultAsync(db => db.Id == id);
            if (daiBieu != null)
            {
                _contex.DaiBieus.Remove(daiBieu);
                await _contex.SaveChangesAsync();
            }
        }

        public async Task UpdateDaiBieuAsync(string id, DaiBieu daibieu)
        {
            var daibieuTemp = await _contex.DaiBieus.FindAsync(id);
            if (daibieuTemp != null)
            {
                daibieuTemp.Name = daibieu.Name;
                daibieuTemp.Age = daibieu.Age;
                daibieuTemp.WorkPlace = daibieu.WorkPlace;
                daibieuTemp.Position = daibieu.Position;
                daibieuTemp.Contact = daibieu.Contact;
                daibieuTemp.Status = daibieu.Status;
                await _contex.SaveChangesAsync();
            }
        }

        public async Task<string> AddMultiplelDaiBieuAsync(List<DaiBieuDTO> listDaiBieu)
        {
            if (listDaiBieu.Count != 0)
            {
                List<DaiBieu> daibieuList = new List<DaiBieu>();
                foreach (var daibieu in listDaiBieu)
                {
                    daibieu.Id = System.Guid.NewGuid().ToString();
                    var newDaiBieu = _mapper.Map<DaiBieu>(daibieu);
                    daibieuList.Add(newDaiBieu);
                }

                await _contex.DaiBieus.AddRangeAsync(daibieuList);
                await _contex.SaveChangesAsync();

                return "Số lượng đại biểu đã thêm: " + listDaiBieu.Count;
            }
            return "Danh sách đại biểu là rỗng";
        }



    }
}
