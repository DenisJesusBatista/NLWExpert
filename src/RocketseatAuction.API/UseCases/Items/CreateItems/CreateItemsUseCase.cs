using RocketseatAuction.API.Comumunication.Request;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Services;

namespace RocketseatAuction.API.UseCases.Items.CreateItems;

public class CreateItemsUseCase
{
    private readonly IItemsRepository _repository;

    public CreateItemsUseCase(IItemsRepository repository)
    {
        _repository = repository;
    }

    public int Execute( RequestCreateItemsJson request)
    {

        var item = new Item
        {
            Name = request.Name,
            Brand = request.Brand,
            //Condition = request.Condition,
            BasePrice = request.BasePrice,
        };

        _repository.Add(item);

        return item.Id;
    }
}
