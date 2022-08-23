namespace Nttdata.Steven.Jurado.Api.Controllers.Base
{
    using Microsoft.AspNetCore.Mvc;
    using Nttdata.Steven.Jurado.Application.DTOs;

    [ApiController]
    public class BaseController : ControllerBase
    {

        protected ClientRequest GenerateUserName(ClientRequest clientRequest)
        {

            clientRequest.UserName = $"{clientRequest.Name.Substring(0, 3)}-{clientRequest.Telephone.Substring(0, 3)}";

            return clientRequest;
        }


        protected void DeleteWhiteSpace(ClientRequest clientRequest)
        {

            clientRequest?.UserName?.Trim();
            clientRequest?.Password?.Trim();
            clientRequest?.Name?.Trim();
            clientRequest?.Address?.Trim();
            clientRequest?.Telephone?.Trim();

        }

    }
}
