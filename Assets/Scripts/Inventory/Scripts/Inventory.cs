using System;
using System.Collections.Generic;

public class Inventory
{
    private List<Item> itemList;

    public Inventory()
    {
        itemList = new List<Item>();
    }

    public static Action OnItemAddedToList { get; internal set; }

    public void AddItems(Item item)
    {
        itemList.Add(item);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }
}