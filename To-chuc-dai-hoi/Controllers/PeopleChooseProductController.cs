using Microsoft.AspNetCore.Mvc;
using To_chuc_dai_hoi.Data;
using To_chuc_dai_hoi.DTO;
using To_chuc_dai_hoi.Repositories.PeopleChooseProductRepo;

namespace To_chuc_dai_hoi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleChooseProductController : ControllerBase
    {
        private readonly IPeopleChooseProductService _peopleChooseProductService;

        public PeopleChooseProductController(IPeopleChooseProductService peopleChooseProductService)
        {
            _peopleChooseProductService = peopleChooseProductService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllPeopleChooseProducts()
        {
            try
            {
                var peopleChooseProducts = await _peopleChooseProductService.GetAllPeopleChooseProductsAsync();
                return Ok(peopleChooseProducts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("categories")]
        public async Task<ActionResult<List<dynamic>>> GetPeopleProductCategories()
        {
            var result = await _peopleChooseProductService.GetPeopleProductCategories();
            return Ok(result);
        }

        [HttpGet("groupProduct")]
        public async Task<ActionResult<List<dynamic>>> GetPeopleProductCategoriesDynamic()
        {
            var result = await _peopleChooseProductService.GetPeopleProductCategoriesDynamic();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddPeopleChooseProduct(PeopleChooseProductDTO peopleChooseProduct)
        {
            try
            {
                string id = await _peopleChooseProductService.AddPeopleChooseProductAsync(peopleChooseProduct);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePeopleChooseProduct(int id, PeopleChooseProduct peopleChooseProduct)
        {
            try
            {
                await _peopleChooseProductService.UpdatePeopleChooseProductAsync(id, peopleChooseProduct);
                return Ok(peopleChooseProduct);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePeopleChooseProduct(int id)
        {
            try
            {
                await _peopleChooseProductService.DeletePeopleChooseProductAsync(id);
                return Ok($"Delete Successful: {id}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
