using Microsoft.AspNetCore.Mvc;
using RocketseatAuction.API.Comumunication.Request;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.UseCases.Items.GetCurrent;

namespace RocketseatAuction.API.Controllers;


[Route("[controller]")]
[ApiController]
public class ItemController : RocketseatAuctionBaseController
{
    [HttpGet] /*Tipo de Endpoint: Recuperar as informações*/
    [ProducesResponseType(typeof(Item), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetCurrentItem([FromServices] GetCurrentItemUseCase useCase)
    {
        var result = useCase.Execute();

        if (result is null)
            return NoContent();

        return Ok(result);
    }

    [HttpPost]
    public IActionResult CreateItems([FromBody] RequestCreateItemsJson request)
    {
        return Created(string.Empty,string.Empty);

    }
}
