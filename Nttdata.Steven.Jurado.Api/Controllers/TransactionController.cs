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
    public class TransactionController : ControllerBase
    {

        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        [Route("Transactions")]
        public async Task<ActionResult> GetTransacctions([FromQuery] DateTime startDate, DateTime endDate, Guid idClient)
        {
            try
            {
                
                if (idClient.Equals(Guid.Empty))
                    return BadRequest("Identificacion Cliente Es Requerido");

                var responseService = await _transactionService.GetTransacctionsAsync(startDate, endDate, idClient);

                return responseService.Count > 0 ? Ok(responseService) : NoContent();
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }


        [HttpGet]
        [Route("TransactionId")]
        public async Task<ActionResult> GetTransacctionId([FromQuery] Guid idTransaction)
        {
            try
            {
                var responseService = await _transactionService.GetransacctionIdAsync(idTransaction);

                return responseService is not null ? Ok(responseService) : NoContent() ;
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }

        [HttpPost]
        [Route("TransactionSave")]
        public async Task<ActionResult> SaveTransacction([FromBody] TransacctionRequest transacctionRequest)
        {
            try
            {

                return await _transactionService.SaveTransacctionAsync(transacctionRequest) ? Ok() : NoContent();
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }
    }
}
