using System.Collections;

namespace DataTypes;

public class ShoppingCart
{
    public List<Item>? items;
}

public class Item
{
    public Item(string description, float price)
    {
        ItemNr = Guid.NewGuid();
        Description = description;
        Price = price;
    }

    public Item? Next { get; set; }

    public Guid ItemNr { get; init; }

    public string Description { get; set; }

    public float Price { get; init; }
}