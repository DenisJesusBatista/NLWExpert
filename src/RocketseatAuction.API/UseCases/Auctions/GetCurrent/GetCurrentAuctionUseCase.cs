using AutoMapper;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.UseCases.Auctions.GetCurrent;

public class GetCurrentAuctionUseCase
{
    private readonly IAuctionRepository _repository;

    public GetCurrentAuctionUseCase(IAuctionRepository repository) => _repository = repository;



    //public Auction Execute()
    //{
    //    return _repository.RecuperarTodosAuction();
    //}

    public IEnumerable<Auction> Execute()
    {
        return _repository.RecuperarTodosAuction();
    }

    //public async Task<Auction> Executar()
    //{
    //    var contato = await _repository.RecuperarTodosAuction();

    //    //var contatosJson = contato.Select(c => _mapper.Map<ContatoJson>(c)).ToList();

    //    return _repository.RecuperarTodosAuction();

    //}
}
