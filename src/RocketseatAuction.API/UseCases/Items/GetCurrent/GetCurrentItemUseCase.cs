using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.UseCases.Items.GetCurrent;

public class GetCurrentItemUseCase
{
    private readonly IItemsRepository _repository;  

    public GetCurrentItemUseCase(IItemsRepository repository) => _repository = repository;

    public List<Item?> Execute()
    {
        return _repository.GetCurrent();
    }
   
}
