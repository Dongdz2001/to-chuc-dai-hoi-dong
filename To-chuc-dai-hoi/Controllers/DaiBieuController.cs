using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using To_chuc_dai_hoi.Data;
using To_chuc_dai_hoi.DTO;
using To_chuc_dai_hoi.Repositories.DaiBieuRePo;

namespace To_chuc_dai_hoi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DaiBieuController : ControllerBase
    {
        private readonly iDaiBieuService _daiBieuService;

        public DaiBieuController(iDaiBieuService daiBieuService )
        {
            _daiBieuService = daiBieuService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllResultDaiBieuAsync()
        {
            try
            {
                return Ok(await _daiBieuService.GetAllDaiBieuAsync());
            }catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddDaiBieuMoi(DaiBieuDTO daibieu)
        {
            try
            {
                await _daiBieuService.AddDaiBieuAsync(daibieu);
                return Ok(daibieu);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("AddMultiple")]
        public async Task<IActionResult> AddMultipleDaiBieu(List<DaiBieuDTO> listDaiBieu)
        {
            try
            {
                string result = await _daiBieuService.AddMultiplelDaiBieuAsync(listDaiBieu);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDaiBieu(string id , DaiBieu daibieu)
        {
            try
            {
                await _daiBieuService.UpdateDaiBieuAsync(id, daibieu);
                return Ok(daibieu);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDaiBieu(string id)
        {
            try
            {
                await _daiBieuService.DeleteDaiBieuAsync(id);
                return Ok("Delete Succed " + id);
            }catch  (Exception ex)
            {
                return BadRequest(ex.Message);      
            }
        }
       

    }
}
