using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Input;

namespace RocketseatAuction.API.UseCases.Auctions.GetCurrent;

public class GetCurrentAuctionUseCase
{
    private readonly IAuctionRepository _repository;

    public GetCurrentAuctionUseCase(IAuctionRepository repository) => _repository = repository;



    public AuctionDto Execute()
    {
        var auction = _repository.GetCurrent();
    //            .FirstOrDefault()

        return new AuctionDto()
        {
            Id = auction.Id,
            Name = auction.Name,
            Starts = auction.Starts,
            Ends = auction.Ends
        };
        //return _repository.RecuperarTodosAuction();
    }

    //public IEnumerable<Auction> Execute()
    //{
    //    return _repository.RecuperarTodosAuction();
    //}

    //public AuctionDto Execute()
    //{
    //    var auction = _repository.ObterAuctionDto
    //            .FirstOrDefault()
    //            ?? throw new Exception("Esse cliente não existe");
    //   
    //}

    //public async Task<Auction> Executar()
    //{
    //    var contato = await _repository.RecuperarTodosAuction();

    //    //var contatosJson = contato.Select(c => _mapper.Map<ContatoJson>(c)).ToList();

    //    return _repository.RecuperarTodosAuction();

    //}
}
