namespace ShoppingLists.Api.Models;

public class ShoppingListCreateRequest
{
    public string[] Categories { get; set; }
    public DateTime Date { get; set; }
}