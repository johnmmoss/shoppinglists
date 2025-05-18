using ShoppingLists.Core;

namespace ShoppingLists.Data;

public class AzureBlobShoppingListRepository : IShoppingListRepository
{
    public Task<ShoppingList> GetShoppingList(Guid id)
    {
        //throw new NotImplementedException();
        return Task.FromResult<ShoppingList>(null);
    }

    public Task Save(ShoppingList shoppingList)
    {
        //throw new NotImplementedException();
        return Task.FromResult<object>(null);
    }
}