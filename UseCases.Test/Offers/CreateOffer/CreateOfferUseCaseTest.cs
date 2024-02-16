using Bogus;
using Moq;
using RocketseatAuction.API.Comumunication.Request;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Services;
using RocketseatAuction.API.UseCases.Offers.CreateOffer;

namespace UseCases.Test.Offers.CreateOffer;
public class CreateOfferUseCaseTest
{
    [Fact]
    public void Success()
    {
        //Criterio dos AAA 

        //Arrange: Iniciazar tudo que precisa


        /*Pacote vai gerar infprmações aleatórias ( pluggin: BOGUS ) */

        var request = new Faker<RequestCreateOfferJson>()
            .RuleFor(request => request.Price, f => f.Random.Decimal(1, 100)).Generate() /*Generate para consultar a entidade (entity)*/;


        /*MOQ == MOCK: Nosso repositorio fake.*/
        var mock = new Mock<IOfferRepository>();
        var loggedUser = new Mock<ILoggedUser>();

        loggedUser.Setup(i => i.User()).Returns(new User());


        //var useCase = new CreateOfferUseCase(,mock.Object);


        //ACT: Ação
        //var id = useCase.Execute(0, request);

        //ASSERT: Verifica se o resultado devolvido é o esperado.
        /*Do proprio .NET*/
        //Assert.NotNull(auction);


    }
}
