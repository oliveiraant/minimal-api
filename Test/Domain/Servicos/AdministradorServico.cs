using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Servicos;
using MinimalApi.Infraestrutura.Db;

namespace Test.Domain.Entidades;

[TestClass]

public class AdministradorServicoTest
{

    //Configurar o ConfigurationBuilder
    private DbContexto CriarContextoDeTeste()
    {
        var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var path = Path.GetFullPath(Path.Combine(assemblyPath ?? "", "..", "..", ".."));        
       
        var builder = new ConfigurationBuilder()
        .SetBasePath(path ?? Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables();

        var configuration = builder.Build();

        return new DbContexto(configuration);
    }
    

    [TestMethod]
    public void TestandoBuscaPorId()
    {
        //Arrange - variáveis que vamos criar
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");

        var adm = new Administrador();
        adm.Id = 1;
        adm.Email = "teste@teste.com";
        adm.Senha = "teste";
        adm.Perfil = "Adm";
         context = CriarContextoDeTeste();
        var administradorServico = new AdministradorServico(context);

        //Act - Ação que irá executar
        administradorServico.Incluir(adm);
        var admDobanco = administradorServico.BuscaPorId(adm.Id);


        //Assert - validação dos dados

        Assert.AreEqual(1, admDobanco.Id);
        


    }
}
