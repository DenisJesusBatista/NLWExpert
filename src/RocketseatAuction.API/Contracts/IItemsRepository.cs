using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Contracts;

public interface IItemsRepository
{
    List<Item?> GetCurrent();

    //Item? GetAllItems();
}
