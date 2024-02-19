using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Contracts;

public interface IItemsRepository
{
    Item? GetCurrent();

    //Item? GetAllItems();
}
