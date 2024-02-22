using Bogus;
using FluentAssertions;
using Moq;
using RocketseatAuction.API.Comumunication.Request;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Services;
using RocketseatAuction.API.UseCases.Items.CreateItems;
using RocketseatAuction.API.UseCases.Offers.CreateOffer;

namespace UseCases.Test.Items.CreateItems;
public class CreateItemsUseCaseTest
{
    [Fact]
    public void Success()
    {
        //Criterio dos AAA 

        //Arrange: Iniciazar tudo que precisa


        /*Pacote vai gerar infprmações aleatórias ( pluggin: BOGUS ) */

        var request = new Faker<RequestCreateItemsJson>()
            .RuleFor(request => request.Name, f => f.Commerce.ProductName())
            .RuleFor(request => request.Brand, f => f.Commerce.Department())
            .RuleFor(request => request.Condition, f => f.Random.Number(1, 100))
            .RuleFor(request => request.BasePrice, f => f.Random.Decimal(1, 100))
            .RuleFor(request => request.AuctionId, f => f.Random.Decimal(1, 1))
            .Generate() /*Generate para consultar a entidade (entity)*/;


        /*MOQ == MOCK: Nosso repositorio fake.*/
        var itemRepository = new Mock<IItemsRepository>();
     

        var useCase = new CreateItemsUseCase(itemRepository.Object);


        //ACT: Ação
        /*Executando teste várias vezes trocando o paramentro ItemId usando Theory*/
        var act = () => useCase.Execute(request);

        //ASSERT: Verifica se o resultado devolvido é o esperado.
        /*Do proprio .NET*/

        act.Should().NotThrow();

        //Assert.NotNull(auction);


    }
}
