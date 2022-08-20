namespace Nttdata.Steven.Jurado.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Nttdata.Steven.Jurado.Application.DTOs;
    using Nttdata.Steven.Jurado.Application.Services;
    using System;
    using System.Net.Mime;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class BankAccountController : ControllerBase
    {

        private IBankAccountService _bankAccountService;

        public BankAccountController(IBankAccountService bankAccountService)
        {
            _bankAccountService = bankAccountService;
        }

        [HttpGet]
        [Route("Accounts")]
        public async Task<ActionResult> GetBankAccount()
        {
            try
            {
                var responseService = await _bankAccountService.GetBankAccountsAsync();

                return responseService.Count > 0 ? Ok(responseService) : NoContent();

            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }

        [HttpGet]
        [Route("AccountId")]
        public async Task<ActionResult> GetBankAccountId([FromQuery] Guid idBankAccount)
        {
            try
            {
                var responseService = await _bankAccountService.GetBankAccountIdAsync(idBankAccount);

                return responseService is not null ? Ok(responseService) : NoContent();
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }

        [HttpPost]
        [Route("AccountAdd")]
        public async Task<ActionResult> AddBankAccount([FromBody] BankAccountRequest bankAccountRequest)
        {
            try
            {
                return await _bankAccountService.AddBankAccountAsync(bankAccountRequest) ? Created("BankAccount", bankAccountRequest) : NoContent();
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }

        [HttpPut]
        [Route("AccountUpdate")]
        public async Task<ActionResult> UpdateBankAccount([FromBody] BankAccountRequest bankAccountRequest)
        {
            try
            {
                return await _bankAccountService.UpdateBankAccountAsync(bankAccountRequest) ? Ok() : NoContent();
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }

        [HttpDelete]
        [Route("AccountDelete")]
        public async Task<ActionResult> DeleteBankAccount([FromQuery] Guid idBankAccount)
        {
            try
            {
                return await _bankAccountService.DeleteBankAccountsAsync(idBankAccount) ? Ok() : NotFound();
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }
    }
}
