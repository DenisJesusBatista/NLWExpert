using RocketseatAuction.API.Comumunication.Request;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Services;

namespace RocketseatAuction.API.UseCases.Items.CreateItems;

public class CreateItemsUseCase
{
    private readonly IItemsRepository _repository;
    private static int _lastItemId = 7;

    public int Execute(RequestCreateItemsJson request)
    {
        var item = new Item
        {
            Id = ++_lastItemId,
            Name = request.Name,
            Brand = request.Brand,
            BasePrice = request.BasePrice,
            AuctionId = request.AuctionId,
        };

        _repository.Add(item);

        return item.Id;
    }

}
