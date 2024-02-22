using Microsoft.AspNetCore.Mvc;
using RocketseatAuction.API.Comumunication.Request;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.UseCases.Items.CreateItems;
using RocketseatAuction.API.UseCases.Items.GetCurrent;
using RocketseatAuction.API.UseCases.Offers.CreateOffer;

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
    public IActionResult CreateItems(
        [FromBody] RequestCreateItemsJson request,
        [FromServices] CreateItemsUseCase useCase)
    {
        var item = useCase.Execute(request);

        return Created(string.Empty, item);

    }
}
