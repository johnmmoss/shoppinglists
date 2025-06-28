namespace ShoppingLists.Core;

public class ShoppingListService(IShoppingListRepository shoppingListRepository) : IShoppingListService
{
    // TODO Introduce an in memory _shoppingListRepository and use it here...
    
    private List<ShoppingList> _shoppingLists = new();

    public async Task<ShoppingList> GetByID(Guid id)
    {
        //return await shoppingListRepository.GetShoppingList(id);
        return _shoppingLists.FirstOrDefault(x => x.Id == id);
    }

    public async Task<ShoppingList> Create(DateTime date, string[] categories)
    {
        var shoppingCategories = new List<ShoppingCategory>();
        
        for (int i = 1; i <= categories.Length; i++)
        {
            shoppingCategories.Add(new ShoppingCategory(i, categories[i - 1]));
        }

        if (!shoppingCategories.Any())
        {
            shoppingCategories.Add(new ShoppingCategory(1, "default"));
        }
        
        var newShoppingList = new ShoppingList(Guid.NewGuid(), date, shoppingCategories);
        
        await shoppingListRepository.Save(newShoppingList);
        _shoppingLists.Add(newShoppingList);
        
        return newShoppingList;
    }

    public IEnumerable<ShoppingList> GetAll()
    {
        return _shoppingLists.ToList();
    }

    public async Task<ShoppingList> AddItem(ShoppingItem item)
    {
        var shoppingList = await GetByID(item.ShoppingListId);
        shoppingList.AddItem(item);
        return shoppingList;
    }

    public IEnumerable<ShoppingItem> GetByCategory(Guid shoppingListId, int categoryId)
    {
        return _shoppingLists.First(x => x.Id == shoppingListId).Items
            .Where(x => x.CategoryId == categoryId)
            .ToList();
    }

    public void Delete(Guid id)
    {
        _shoppingLists.RemoveAll(x => x.Id == id);
    }
}