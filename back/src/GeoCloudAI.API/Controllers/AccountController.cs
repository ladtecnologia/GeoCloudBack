using Microsoft.AspNetCore.Mvc;
using GeoCloudAI.Application.Dtos;
using GeoCloudAI.Application.Contracts;
using GeoCloudAI.Persistence.Models;
using GeoCloudAI.API.Extensions;

namespace GeoCloudAI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {  
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
    
        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get([FromQuery]PageParams pageParams)
        {
            try
            {
                var result = await _accountService.Get(pageParams);
                if(result == null) return NotFound("No accounts found");

                Response.AddPagination(result.TotalCount, result.CurrentPage, result.PageSize, result.TotalPages);
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                   $"Error when trying to recover accounts. Error: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("getById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _accountService.GetById(id);
                if(result == null) return NotFound("No account found");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                   $"Error when trying to recover account. Error: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(AccountDto accountDto)
        {
            try
            {
                var result = await _accountService.Add(accountDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                   $"Error when trying to add account. Error: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(AccountDto accountDto)
        {
            try
            {
                var result = await _accountService.Update(accountDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                   $"Error when trying to update account. Error: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _accountService.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                   $"Error when trying to delete account. Error: {ex.Message}");
            }
        }

    }
}