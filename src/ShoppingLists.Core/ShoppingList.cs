namespace ShoppingLists.Core;

public class ShoppingList(Guid id, DateTime date, IEnumerable<ShoppingCategory> categories)
{
    public Guid Id { get; private set; } = id;

    public List<ShoppingItem> Items { get; private set; } = new();
    
    public IEnumerable<ShoppingCategory> Categories { get; private set; } = categories;
    
    public DateTime Date { get; private set; } = date;

    public void AddItem(ShoppingItem item)
    {
        Items.Add(item);
    }
}