using Bogus;
using FluentAssertions;
using Moq;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Enums;
using RocketseatAuction.API.UseCases.Auctions.GetCurrent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.Test.Auctions.GetCurrent;
public class GetCurrentAuctionUseCaseTest
{
    [Fact]
    public void Success()
    {
        //Criterio dos AAA 

        //Arrange: Iniciazar tudo que precisa


        /*Pacote vai gerar infprmações aleatórias ( pluggin: BOGUS ) */

        var entity = new Faker<Auction>()
            .RuleFor(auction => auction.Id, f => f.Random.Number(1, 100))
            .RuleFor(auction => auction.Name, f => f.Lorem.Word())
            .RuleFor(auction => auction.Starts, f => f.Date.Past())
            .RuleFor(auction => auction.Ends, f => f.Date.Future())
            .RuleFor(auction => auction.Items, (f, auction )=> new List<Item>
            {
                new Item
                {
                    Id = f.Random.Number(1, 100),
                    Name = f.Commerce.ProductName(),
                    Brand = f.Commerce.Department(),
                    BasePrice = f.Random.Decimal(50, 1000),
                    Condition = f.PickRandom<Condition>(),
                    AuctionId = auction.Id

                }
            }).Generate() /*Generate para consultar a entidade (entity)*/;


        /*MOQ == MOCK: Nosso repositorio fake.*/
        var mock = new Mock<IAuctionRepository>();
        mock.Setup(i => i.GetCurrent()).Returns(entity);

        var useCase = new GetCurrentAuctionUseCase(mock.Object);


        //ACT: Ação
       var auction = useCase.Execute();

        //ASSERT: Verifica se o resultado devolvido é o esperado.
        /*Do proprio .NET*/
        //Assert.NotNull(auction);

        /*Mais usado no mercado, usando o pluginn FluentAssertions*/
        auction.Should().NotBeNull();

        /*Condição: Esse ID deveria ser o mesmo valor de entidade.ID*/
        auction.Id.Should().Be(entity.Id);
        auction.Name.Should().Be(entity.Name);


    }
}
