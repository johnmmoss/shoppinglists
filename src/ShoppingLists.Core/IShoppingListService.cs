namespace ShoppingLists.Core;

public interface IShoppingListService
{
    Task<ShoppingList> GetByID(Guid id);
    Task<ShoppingList> Create(DateTime date, string[] categories);
    IEnumerable<ShoppingList> GetAll();
    Task<ShoppingList> AddItem(ShoppingItem item);
    IEnumerable<ShoppingItem> GetByCategory(Guid shoppingListId, int categoryId);
    void Delete(Guid id);
}