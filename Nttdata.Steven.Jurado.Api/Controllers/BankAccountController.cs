namespace Nttdata.Steven.Jurado.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Nttdata.Steven.Jurado.Application.Services;
    using System.Net.Mime;

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
        [Route("Account")]
        public ActionResult Get()
        {
            return Ok();
        }


    }
}
