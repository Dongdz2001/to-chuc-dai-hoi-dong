using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using To_chuc_dai_hoi.DTO;
using To_chuc_dai_hoi.Repositories.TinTucRePo;
using To_chuc_dai_hoi.Services;

namespace To_chuc_dai_hoi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TintucController : ControllerBase
    {
        private readonly iTinTucService _tintucService;

        public TintucController(iTinTucService tintucService)
        {
            _tintucService = tintucService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTintucAsync()
        {
            try
            {
                var result = await _tintucService.GetAllTintucAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTintucByIdAsync(int id)
        {
            try
            {
                var result = await _tintucService.GetTintucByIdAsync(id);
                return result != null ? Ok(result) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddTintucAsync([FromBody] TintucDTO tintuc)
        {
            try
            {
                var result = await _tintucService.AddTintucAsync(tintuc);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("addmultiple")]
        public async Task<IActionResult> AddMultipleTintucAsync([FromBody] List<TintucDTO> tintucs)
        {
            try
            {
                await _tintucService.AddMultipleTintucAsync(tintucs);
                return Ok("Thêm mới nhiều thành công");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTintucAsync(int id, [FromBody] TintucDTO tintuc)
        {
            try
            {
                await _tintucService.UpdateTintucAsync(id, tintuc);
                return Ok("Cập nhật thành công!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTintucAsync(int id)
        {
            try
            {
                await _tintucService.DeleteTintucAsync(id);
                return Ok("Xóa thành công!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
