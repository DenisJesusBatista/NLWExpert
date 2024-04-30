using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Input;

namespace RocketseatAuction.API.Contracts;

public interface IAuctionRepository
{
    AuctionDto? GetCurrent();


    //IEnumerable Auction? RecuperarTodosAuction();

    //IEnumerable<Auction> RecuperarTodosAuction();

    AuctionDto ObterAuctionDto();
}
