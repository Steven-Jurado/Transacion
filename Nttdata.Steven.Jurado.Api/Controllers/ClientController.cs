namespace Nttdata.Steven.Jurado.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Nttdata.Steven.Jurado.Application.Services;
    using System.Net.Mime;

    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class ClientController : ControllerBase
    {

        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }


        [HttpGet]
        [Route("Account")]
        public ActionResult Get()
        {
            return Ok();
        }

    }
}
