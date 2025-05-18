namespace ShoppingLists.Core;

public class ShoppingItem(Guid shoppingListId, int categoryId, string name, decimal? cost)
{
    public Guid ShoppingListId { get; set; } = shoppingListId;
    public int CategoryId { get; set; } = categoryId;
    public string Name { get; set; } = name;
    public decimal? Cost { get; set; } = cost;
}