using Microsoft.AspNetCore.Mvc;
using ShoppingLists.Api.Models;
using ShoppingLists.Core;

namespace ShoppingLists.Api.Controllers;

[ApiController]
[Route("api/ShoppingList/{shoppingListId}/Items")]
public class ShoppingListItemController(IShoppingListService _shoppingListService) : ControllerBase
{
    [HttpPost()]
    public IActionResult AddItem([FromRoute] Guid shoppingListId, [FromBody] ShoppingItemAddRequest request)
    {
        var item = new ShoppingItem(shoppingListId, request.CategoryId, request.Name, request.Cost);
        var created = _shoppingListService.AddItem(item);
        var resourceUrl = string.Empty;
        return Created(resourceUrl, created);
    }
}