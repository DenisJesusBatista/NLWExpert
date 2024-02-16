using Bogus;
using FluentAssertions;
using Moq;
using RocketseatAuction.API.Comumunication.Request;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Services;
using RocketseatAuction.API.UseCases.Offers.CreateOffer;

namespace UseCases.Test.Offers.CreateOffer;
public class CreateOfferUseCaseTest
{
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void Success(int itemId)
    {
        //Criterio dos AAA 

        //Arrange: Iniciazar tudo que precisa


        /*Pacote vai gerar infprmações aleatórias ( pluggin: BOGUS ) */

        var request = new Faker<RequestCreateOfferJson>()
            .RuleFor(request => request.Price, f => f.Random.Decimal(1, 100)).Generate() /*Generate para consultar a entidade (entity)*/;


        /*MOQ == MOCK: Nosso repositorio fake.*/
        var offerRepository = new Mock<IOfferRepository>();
        var loggedUser = new Mock<ILoggedUser>();

        loggedUser.Setup(i => i.User()).Returns(new User());


        var useCase = new CreateOfferUseCase(loggedUser.Object, offerRepository.Object);


        //ACT: Ação
        /*Executando teste várias vezes trocando o paramentro ItemId usando Theory*/
        var act = () => useCase.Execute(itemId, request);

        //ASSERT: Verifica se o resultado devolvido é o esperado.
        /*Do proprio .NET*/

        act.Should().NotThrow();

        //Assert.NotNull(auction);


    }
}
