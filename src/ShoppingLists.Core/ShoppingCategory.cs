namespace ShoppingLists.Core;

public class ShoppingCategory(int id, string name)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
}