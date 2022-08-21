namespace Nttdata.Steven.Jurado.Api.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Nttdata.Steven.Jurado.Api.Controllers.Base;
    using Nttdata.Steven.Jurado.Application.DTOs;
    using Nttdata.Steven.Jurado.Application.Services;
    using System;
    using System.Net.Mime;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class ClientController : BaseController
    {

        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }


        [HttpGet]
        [Route("Client")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetClient()
        {
            try
            {

                var responseService = await _clientService.GetClientAsync();

                return responseService.Count > 0 ? Ok(responseService) : NoContent();
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }

        }

        [HttpGet()]
        [Route("ClientId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetClientId([FromQuery] Guid IdClient)
        {
            try
            {

                var responseService = await _clientService.GetClientIdAsync(IdClient);

                return responseService is not null ? Ok(responseService) : NoContent();
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }

        }

        [HttpPost]
        [Route("ClientAdd")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddClient([FromBody] ClientRequest clientRequest)
        {

            try
            {
                if (string.IsNullOrWhiteSpace(clientRequest.UserName))
                    clientRequest = GenerateUserName(clientRequest);

                DeleteWhiteSpace(clientRequest);


                return await _clientService.AddClientAsync(clientRequest) ? Created("Usuario", clientRequest) : NoContent();
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }

        }

        [HttpPut]
        [Route("ClientUpdate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateClient([FromBody] ClientRequest clientRequest)
        {

            try
            {

                DeleteWhiteSpace(clientRequest);

                if (string.IsNullOrWhiteSpace(clientRequest.UserName))
                    return BadRequest("Campo User Name Requerido");

                return await _clientService.UpdateClientAsync(clientRequest) ? Ok() : NotFound();
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }

        }

        [HttpDelete]
        [Route("ClientDelete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteClient([FromQuery] Guid IdClient)
        {

            try
            {

                return await _clientService.DeleteClientAsync(IdClient) ? Ok() : NotFound();
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }

        }
    }
}
