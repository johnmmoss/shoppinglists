namespace ShoppingLists.Core;

public interface IShoppingListRepository
{
    Task<ShoppingList> GetShoppingList(Guid id);

    Task Save(ShoppingList shoppingList);
}