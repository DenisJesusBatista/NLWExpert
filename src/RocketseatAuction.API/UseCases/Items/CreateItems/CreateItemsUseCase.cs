using RocketseatAuction.API.Comumunication.Request;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Services;

namespace RocketseatAuction.API.UseCases.Items.CreateItems;

public class CreateItemsUseCase
{
    private readonly ILoggedUser _loggedUser;
    private readonly IItemsRepository _repository;

    public CreateItemsUseCase(ILoggedUser loggedUser, IItemsRepository repository)
    {
        _loggedUser = loggedUser;
        _repository = repository;
    }

    public int Execute(RequestCreateItemsJson request)
    {
        var auctionId = _loggedUser.User();

        var item = new Item
        {
            //Id = ++_lastItemId,
            Name = request.Name,
            Brand = request.Brand,
            BasePrice = request.BasePrice,
            AuctionId = request.AuctionId,
        };

        _repository.Add(item);

        return item.Id;
    }

}
