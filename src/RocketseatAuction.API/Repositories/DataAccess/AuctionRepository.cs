using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Repositories.DataAccess;

public class AuctionRepository: IAuctionRepository
{
    private readonly RocketseatAuctionDbContext _dbContext;
    
    public AuctionRepository(RocketseatAuctionDbContext dbContext) => _dbContext = dbContext;
    
    public Auction? GetCurrent()
    {


        /*Forcar NoContent*/
        var today = DateTime.Now;

        return _dbContext
            .Auctions
            .Include(aucion => aucion.Items)
            .FirstOrDefault(auction => today >= auction.Starts && today <= auction.Ends); /*Retornar apenas os leiloes conforma a data today*/
        //.First(); /*Retornar todos os leiloes*/

    }
}
