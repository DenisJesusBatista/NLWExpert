using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Repositories.DataAccess;

public class ItemRepository: IItemsRepository
{
    private readonly RocketseatAuctionDbContext _dbContext; /*Recebe como injecao de depedência o context*/
    public ItemRepository(RocketseatAuctionDbContext dbContext) => _dbContext = dbContext;


    public Item? GetCurrent()
    {
        return _dbContext.items.First(item => item.Id.Equals(1));


    }

    //public List<Item?> GetAllItems()
    //{
    //    return _dbContext.items.ToList();
    //}
}
