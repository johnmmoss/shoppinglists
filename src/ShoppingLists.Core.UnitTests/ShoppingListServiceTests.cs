using Moq;
using ShoppingLists.Core;

namespace ShoppingList.Core.UnitTests;

public class ShoppingListServiceTests
{
    private Mock<IShoppingListRepository> _mockShoppingListRepository = new();
    
    [Fact]
    public async Task Create_creates_a_new_shopping_list()
    {
        var date = new DateTime(2025, 1, 1);
        var categories = new[] { "Fruit & Veg", "Meat", "Bread" };
        var shoppingListService = new ShoppingListService(_mockShoppingListRepository.Object);

        var result = await shoppingListService.Create(date, categories);

        Assert.NotNull(result);
        Assert.Equal(date, result.Date);
    }

    [Fact]
    public async Task Create_saves_a_created_shopping_list_to_storage()
    {
        var date = new DateTime(2025, 1, 1);
        var categories = new[] { "Fruit & Veg", "Meat", "Bread" };
        var shoppingListService = new ShoppingListService(_mockShoppingListRepository.Object);

        var created = await shoppingListService.Create(date, categories);

        Assert.NotNull(created);
        Assert.Equal(date, created.Date); 
        _mockShoppingListRepository.Verify(x => x.Save(created));
    }
    
    [Fact]
    public async Task Create_creates_categories_for_the_shopping_list()
    {
        var date = new DateTime(2025, 1, 1);
        var categories = new[] { "Fruit & Veg", "Meat", "Bread" };
        var shoppingListService = new ShoppingListService(_mockShoppingListRepository.Object);

        var created = await shoppingListService.Create(date, categories);
        
        Assert.Equal(3, created.Categories.Count());
        Assert.NotNull(created.Categories.FirstOrDefault(x => x.Id == 1));
        Assert.NotNull(created.Categories.FirstOrDefault(x => x.Id == 2));
        Assert.NotNull(created.Categories.FirstOrDefault(x => x.Id == 3));
    }

    [Fact]
    public async Task Create_creates_a_default_category_when_no_categories_provided()
    {
        var date = new DateTime(2025, 1, 1);
        var categories = new string[] {} ;
        var shoppingListService = new ShoppingListService(_mockShoppingListRepository.Object);

        var created = await shoppingListService.Create(date, categories);
        
        Assert.NotNull(created);
        Assert.Equal(date, created.Date);
        Assert.Equal(1, created.Categories.Count());
        Assert.Equal(1, created.Categories.First().Id);
    }

    /***
    [Fact]
    public void GetAll_gets_all_shopping_lists()
    {
        var date = new DateTime(2025, 1, 1);
        var categories = new[] { "Fruit & Veg", "Meat", "Bread" };
        var shoppingListService = new ShoppingListService(_mockShoppingListRepository.Object);

        shoppingListService.Create(date, categories);
        shoppingListService.Create(date, categories);
        shoppingListService.Create(date, categories);
        var results = shoppingListService.GetAll();
        
        Assert.Equal(3, results.Count());
    }

    [Fact]
    public async Task GetById_gets_shopping_lists_specified_by_id()
    {
        var date = new DateTime(2025, 1, 1);
        var categories = new[] { "Fruit & Veg", "Meat", "Bread" };
        var shoppingListService = new ShoppingListService(_mockShoppingListRepository.Object);

        var created = await shoppingListService.Create(date, categories);
        var retrieved = await shoppingListService.GetByID(created.Id);
        
        Assert.Equal(date, retrieved.Date);
    }
    
    // AddItem when single "default"
    
    [Fact]
    public async Task AddItem_adds_an_item_to_a_shoppingList()
    {
        var date = new DateTime(2025, 1, 1);
        var categories = new[] { "Fruit & Veg", "Meat", "Bread" };
        var shoppingListService = new ShoppingListService(_mockShoppingListRepository.Object);
        var created = await shoppingListService.Create(date, categories);
        var newItem = new ShoppingItem(created.Id, 1, "Steak", 0);
        
        var updated =  await shoppingListService.AddItem(newItem);
        
        Assert.Equal(1, updated.Items.Count());
    }
    
    [Fact]
    public async Task Get_shopping_items_by_category()
    {
        var date = new DateTime(2025, 1, 1);
        var categories = new[] { "Meat", "Fruit & Veg", "Bread" };
        var shoppingListService = new ShoppingListService(_mockShoppingListRepository.Object);
        var created = await shoppingListService.Create(date, categories);
        shoppingListService.AddItem(new ShoppingItem(created.Id, 1, "Steak", 0));
        shoppingListService.AddItem(new ShoppingItem(created.Id, 2, "Pineapple", 0));
        shoppingListService.AddItem(new ShoppingItem(created.Id, 2, "Cuecumber", 0));

        var shoppingListCategoryItems = shoppingListService.GetByCategory(created.Id, 2);
        
        Assert.Equal(2, shoppingListCategoryItems.Count());
    }
    
    [Fact]
    public async Task Delete_deletes_a_shopping_list()
    {
        var date = new DateTime(2025, 1, 1);
        var categories = new[] { "Meat" };
        var shoppingListService = new ShoppingListService(_mockShoppingListRepository.Object);
        var shoppingList = await shoppingListService.Create(date, categories);
        shoppingListService.AddItem(new ShoppingItem(shoppingList.Id, 1, "Steak", 0));
        
        shoppingListService.Delete(shoppingList.Id);
        
        Assert.Empty(shoppingListService.GetAll());
    }
    **/
}