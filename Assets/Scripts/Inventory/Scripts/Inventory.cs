using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewInventory", menuName = "Inventory", order = 54)]
public class Inventory: ScriptableObject
{
    public List<Item> itemList;

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