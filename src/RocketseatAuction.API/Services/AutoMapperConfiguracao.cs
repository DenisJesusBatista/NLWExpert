using AutoMapper;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Repositories.DataAccess;
using System.Diagnostics.CodeAnalysis;

namespace RocketseatAuction.API.Services;

/*Realizar a configuração do AutoMapper*/
[ExcludeFromCodeCoverage]
public class AutoMapperConfiguracao: Profile
{
    public AutoMapperConfiguracao()
    {
        //Funcao    

        // Mapeamento de RequisicaoRegistrarContatoJson para Contato


        CreateMap<AuctionRepository, Auction>();
    }

}
