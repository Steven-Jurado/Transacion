namespace Nttdata.Steven.Jurado.Api.Test
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Nttdata.Steven.Jurado.Application.DTOs;
    using Nttdata.Steven.Jurado.Repository.Sql.Context;
    using System.Threading.Tasks;

    [TestClass]
    public class TransactionTest
    {


        private DbContextOptions<TransactionContext> dbContextOptions = new DbContextOptionsBuilder<TransactionContext>()
        //.UseInMemoryDatabase(databaseName: "PrimeDb")
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
            ////Preparar Ambiente De Prueba
            ////Act Ejecusion De Prueba
            ////Assert Validacion de Metodo

            //var asdasd = new WebApplicationFactory<Program>();

            //var httpclient = asdasd.CreateDefaultClient();

            //var ClientServices = new Mock<IClientService>();
            //ClientServices.Setup(x => x.AddClientAsync(ClientRequest));

            //var ClientRepository = new Mock<IClientRepository>();
            //var responseConvert = ConvertHelper.ConvertType<Client>(ClientRequest);
            //ClientRepository.Setup(x=>x.AddClientAsync(responseConvert));


            //var ClientRepositoryLog = new Mock<ILogger<ClientRepository>>().Object;



            //var Context = new TransactionContext(dbContextOptions);
            ////await Context.SaveChangesAsync();

            //IClientService services = new ClientService(ClientRepository.Object);
            //IClientRepository clientRepository = new ClientRepository(Context, ClientRepositoryLog);

            //var controller = new ClientController(ClientServices.Object);

            //var responseController = await controller.AddClient(ClientRequest);

            //var jaja = await services.AddClientAsync(ClientRequest);


            //var responseRepository = await clientRepository.AddClientAsync(responseConvert);

            //var result = responseController as CreatedResult;

            ////Assert.IsNotNull(result);
            //Assert.IsTrue(responseRepository);
            ////Assert.AreEqual(201, result.StatusCode);

        }

        [TestMethod]
        public void CreateBankAccountTest()
        {

        }

        [TestMethod]
        public void TransactionMovementTest()
        {
        }
    }
}
