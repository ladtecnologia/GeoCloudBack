using Microsoft.AspNetCore.Mvc;
using GeoCloudAI.Application.Contracts;

namespace GeoCloudAI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {  
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }
    
        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get(string? term)
        {
            try
            {
                var result = await _countryService.Get(term!);
                if(result == null) return NotFound("No countries found");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                   $"Error when trying to recover countries. Error: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("getById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _countryService.GetById(id);
                if(result == null) return NotFound("No country found");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                   $"Error when trying to recover country. Error: {ex.Message}");
            }
        }

    }
}