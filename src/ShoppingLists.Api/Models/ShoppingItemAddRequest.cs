namespace ShoppingLists.Api.Models;

public class ShoppingItemAddRequest
{
    public int CategoryId { get; set; }
    
    public string Name { get; set; }
    
    public decimal? Cost {get; set; }
}