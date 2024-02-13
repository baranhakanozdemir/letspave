using LetsPave.Core.Models;
using LetsPave.Core.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace LetsPave.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISaleService _service;
        private readonly ILogger<SalesController> _logger;

        public SalesController(ISaleService service, ILogger<SalesController> logger)
        {
            _logger = logger;
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _service.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Something went wrong. Internal Server Error.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetCategoryRegionSeasonReport(ProductCategorySaleItem request)
        {
            try
            {
                var response = await _service.GetCategoryRegionSeasonReport(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Something went wrong. Internal Server Error.");
            }
        }

        [HttpGet("GetSaleLookupItem")]
        public async Task<IActionResult> GetSaleLookupItem()
        {
            try
            {
                var response = await _service.GetSaleLookupItem();
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Something went wrong. Internal Server Error.");
            }
        }
    }
}
