using MinimalApi.Dominio.Entidades;

namespace Test.Domain.Entidades;

[TestClass]
public sealed class VeiculoTest
{
    [TestMethod]
    public void TestarGetSetPropriedades()
    {
        //Arrange - variáveis que vamos criar
        var veiculo = new Veiculo();

        //Act - Ação que irá executar
        veiculo.Id = 1;
        veiculo.Nome = "HB20S";
        veiculo.Marca = "Hyundai";
        veiculo.Ano = 2025;

        //Assert - validação dos dados

        Assert.AreEqual(1, veiculo.Id);
        Assert.AreEqual("HB20S", veiculo.Nome);
        Assert.AreEqual("Hyundai", veiculo.Marca);
        Assert.AreEqual(2025, veiculo.Ano);


    }
}
