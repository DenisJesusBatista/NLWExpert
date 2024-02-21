namespace RocketseatAuction.API.Comumunication.Request;

public class RequestCreateItemsJson
{
    public string Name { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public int Condition { get; set; }
    public decimal BasePrice { get; set; }
}
