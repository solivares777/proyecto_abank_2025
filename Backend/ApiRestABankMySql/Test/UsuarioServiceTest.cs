namespace ApiRestABankMySql.Test
{
    using ApiRestABankMySql.Model;
    using Moq;
    using Mysqlx.Crud;
    using Xunit;

    public class UsuarioServiceTest
    {
        [Fact]
        public async Task GetUsuarios_ReturnsList()
        {
            var mockRepo = new Mock<IUsuarioRepository>();

            mockRepo.Setup(r => r.GetAll())
                .ReturnsAsync(new List<Usuario>
                {
                new Usuario { Id = 1, Nombres = "Juan" }
                });

            var service = new UsuarioService(mockRepo.Object);

            var result = await service.GetUsuarios();

            Assert.Single(result);
        }
    }
}
