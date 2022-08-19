namespace Nttdata.Steven.Jurado.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Nttdata.Steven.Jurado.Application.Services;
    using System.Net.Mime;

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
        [Route("Transaction")]
        public ActionResult Get()
        {
            return Ok();
        }

    }
}
