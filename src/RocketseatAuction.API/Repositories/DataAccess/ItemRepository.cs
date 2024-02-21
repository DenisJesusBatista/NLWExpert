using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;
using System;

namespace RocketseatAuction.API.Repositories.DataAccess;

public class ItemRepository: IItemsRepository
{
    private readonly RocketseatAuctionDbContext _dbContext; /*Recebe como injecao de depedência o context*/
    public ItemRepository(RocketseatAuctionDbContext dbContext) => _dbContext = dbContext;


    public List<Item?> GetCurrent()
    {
        var allItems = _dbContext.items.Where(item => item.AuctionId == 1);

        //var allItemsViewModels = allItems
        //    .Select(i => new Item());
        return _dbContext.items.ToList();


    }

    public void Add(Item item)
    {

        _dbContext.items.Add(item);

        _dbContext.SaveChanges();
    }

    //public List<Item?> GetAllItems()
    //{
    //    return _dbContext.items.ToList();
    //}
}
