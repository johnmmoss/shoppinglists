using Microsoft.AspNetCore.Mvc;
using ShoppingLists.Core;

namespace ShoppingLists.Api.Controllers;

[ApiController]
[Route("api/ShoppingList/{shoppingListId}/Categories")]
public class ShoppingListCategoryControllers(IShoppingListService _shoppingListService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetCategories([FromRoute] Guid shoppingListId)
    {
        var shoppingList = await _shoppingListService.GetByID(shoppingListId);
        return Ok(shoppingList.Categories);
    }
    
    [HttpGet("{shoppingListCategoryId}")]
    public IActionResult GetShoppingListCategoryItems([FromRoute] Guid shoppingListId, int shoppingListCategoryId)
    {
        var shoppingListCategoryItems = _shoppingListService.GetByCategory(shoppingListId, shoppingListCategoryId);
        return Ok(shoppingListCategoryItems);
    }
}