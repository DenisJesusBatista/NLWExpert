namespace RocketseatAuction.API.Entities;

public class Auction
{
    public int Id { get; set; } /* Propriedade 
                                 * Operacoes 
                                 * get = Recuperar valor 
                                 * set = Altera o valor do id*/
    public string Name { get; set; } = string.Empty;
    public DateTime Starts { get; set; }
    public DateTime Ends { get; set; }  
    public List<Item> Items { get; set; } = new List<Item>();   

}
