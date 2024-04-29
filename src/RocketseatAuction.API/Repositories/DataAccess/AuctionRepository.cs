using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Repositories.DataAccess;

public class AuctionRepository: IAuctionRepository
{
    private readonly RocketseatAuctionDbContext _dbContext; /*Recebe como injecao de depedência o context*/
    
    public AuctionRepository(RocketseatAuctionDbContext dbContext) => _dbContext = dbContext;

    public interface IAuctionRepository
    {
        IEnumerable<Auction> RecuperarTodosAuction();
    }


    public Auction? GetCurrent()
    {


        /*Forcar NoContent*/
        //var today = DateTime.Now;
        // Definindo a data manualmente e convertendo para UTC
        DateTime manualDate = new DateTime(2024, 4, 27, 0, 0, 0, DateTimeKind.Utc);


        return _dbContext
            .Auction
            .Include(aucion => aucion.Items)
            .FirstOrDefault(auction => manualDate >= auction.Starts && manualDate <= auction.Ends); /*Retornar apenas os leiloes conforma a data today*/
        //.First(); /*Retornar todos os leiloes*/

    }

    public async Task<IList<Auction>> RecuperarTodosAuction()
    {
        return await _dbContext.Auction.AsNoTracking().ToListAsync();
    }

    //IEnumerable<Auction> IAuctionRepository.RecuperarTodosAuction()
    //{
    //    DateTime manualDate = new DateTime(2024, 4, 27, 0, 0, 0, DateTimeKind.Utc);

    //    return _dbContext
    //        .Auction
    //        .Include(auction => auction.Items)
    //        .Where(auction => manualDate >= auction.Starts && manualDate <= auction.Ends)
    //        .ToList();
    //}

    IEnumerable<Auction> Contracts.IAuctionRepository.RecuperarTodosAuction()
    {
        DateTime manualDate = new DateTime(2024, 4, 27, 0, 0, 0, DateTimeKind.Utc);

        return _dbContext
        .Auction
        .Include(auction => auction.Items)
        .Where(auction => manualDate >= auction.Starts && manualDate <= auction.Ends)
        .ToList();
    }


    //public async Auction RecuperarTodosAuction()
    //{
    //    return await _dbContext.Auctions.AsNoTracking().ToListAsync();
    //}

    //public async Task<IList<Auction>> RecuperarTodosContatos()
    //{
    //    return await _dbContext.Auctions.AsNoTracking().ToListAsync();
    //}
}
