using Microsoft.AspNetCore.Mvc;
using ShoppingLists.Api.Models;
using ShoppingLists.Core;

namespace ShoppingLists.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShoppingListController(IShoppingListService _shoppingListService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateList([FromBody]ShoppingListCreateRequest request)
    {
        var shoppingList = await _shoppingListService.Create(request.Date, request.Categories);

        var resourceUrl = Url.Link("GetById", new { id = shoppingList.Id });
        
        return Created(resourceUrl, shoppingList);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var shoppingLists = _shoppingListService.GetAll();

        return Ok(shoppingLists);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var shoppingList = await _shoppingListService.GetByID(id);

        if (shoppingList == null)
            return NotFound();
    
        return Ok(shoppingList);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        _shoppingListService.Delete(id);

        return Ok();
    }
}