namespace Nttdata.Steven.Jurado.Api.Test
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Nttdata.Steven.Jurado.Api.Controllers;
    using Nttdata.Steven.Jurado.Application.AppServices;
    using Nttdata.Steven.Jurado.Application.DTOs;
    using Nttdata.Steven.Jurado.Application.Helpers;
    using Nttdata.Steven.Jurado.Application.Services;
    using Nttdata.Steven.Jurado.Domain.Entities;
    using Nttdata.Steven.Jurado.Repository.Interfaces;
    using Nttdata.Steven.Jurado.Repository.Repositories;
    using Nttdata.Steven.Jurado.Repository.Sql.Context;
    using System.Threading.Tasks;

    [TestClass]
    public class TransactionTest
    {


        private DbContextOptions<TransactionContext> dbContextOptions = new DbContextOptionsBuilder<TransactionContext>()
        .UseSqlServer("Server=localhost,14333;Database=nttdata;User Id=SA;Password=nttdata1234;")
        .Options;

        private static ClientRequest ClientRequest =>
           new()
           {
               Name = "Jose Lema",
               Address = "Otavalo sn y principal",
               Telephone = "0998254785",
               Password = "1234",
               Status = Domain.Helpers.Status.Active,
               Age = 21,
               Gender = Domain.Helpers.Gender.Male,
               UserName = "Jos-099"
           };

        [TestMethod]
        public async Task CreateClientTest()
        {
            //Preparar Ambiente De Prueba
            //Act Ejecusion De Prueba
            //Assert Validacion de Metodo

            var ClientServices = new Mock<IClientService>();

            var ClientRepository = new Mock<IClientRepository>();
            var responseConvert = ConvertHelper.ConvertType<Client>(ClientRequest);


            var ClientRepositoryLog = new Mock<ILogger<ClientRepository>>().Object;
            var Context = new TransactionContext(dbContextOptions);

            IClientService services = new ClientService(ClientRepository.Object);
            IClientRepository clientRepository = new ClientRepository(Context, ClientRepositoryLog);

            var controller = new ClientController(ClientServices.Object);

            //var responseController = await controller.AddClient(ClientRequest);

            //var reponseService = await services.AddClientAsync(ClientRequest);


            var responseRepository = await clientRepository.AddClientAsync(responseConvert);

            //var result = responseController as CreatedResult;

            Assert.IsTrue(responseRepository);

            //Assert.IsNotNull(result);
            //Assert.AreEqual(201, result.StatusCode);

        }

        [TestMethod]
        public async Task ListClientTest()
        {

            var ClientRepositoryLog = new Mock<ILogger<ClientRepository>>().Object;
            var Context = new TransactionContext(dbContextOptions);

            IClientRepository clientRepository = new ClientRepository(Context, ClientRepositoryLog);

            var responseRepository = await clientRepository.GetclientAsync();

            Assert.IsTrue(responseRepository.Count > 0);

        }

    }
}
