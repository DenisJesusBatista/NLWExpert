using Microsoft.AspNetCore.Mvc;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.UseCases.Auctions.GetCurrent;

/*
 * CTRL + R + G : Remove os usigs que não está sendo utilizados e coloca em ordem alfabetica os usings
 * 
 * Controller: Dá um contexto
 * agrupamento de várias funcionalidade
 * 
 * Using
 * Namespace: Organizar nossa classe
 */

namespace RocketseatAuction.API.Controllers;

[Route("[controller]")]
[ApiController]
public class AuctionController : RocketseatAuctionBaseController
{
    [HttpGet] /*Tipo de Endpoint: Recuperar as informações*/
    [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    //public IActionResult GetCurrentAuction([FromServices] GetCurrentAuctionUseCase useCase)
    //{   
    //    var result = useCase.Execute();

    //    if (result is null)
    //        return NoContent();

    //    return Ok(result);
    //}

    public IActionResult GetCurrentAuction([FromServices] GetCurrentAuctionUseCase useCase)
    {
        var result = useCase.Execute();

        //if (result == null || !result.())
        //    return NoContent();

        return Ok(result);
    }

}
