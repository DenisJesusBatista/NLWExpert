using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Repositories;

namespace RocketseatAuction.API.UseCases.Auctions.GetCurrent;

public class GetCurrentAuctionUseCase
{
    public Auction? Execute()
    {
        var repository = new RocketseatAuctionDbContext();


        /*Forcar NoContent*/
        var today = DateTime.Now;


        return repository
            .Auctions
            .Include(aucion => aucion.Items)
            //.FirstOrDefault(auction => today >= auction.Starts && today <= auction.Ends); /*Retornar apenas os leiloes conforma a data today*/
            .First(); /*Retornar todos os leiloes*/
       
    }
}
