using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    public List<Item> itemList;
    public static Action OnItemAddedToList { get; internal set; }
    public Inventory()
    {
        itemList = new List<Item>();
    }

    public void AddItems(Item item)
    {
        if(item.isStackable)
        {
            bool itemAlreadyInInventory = false;
            foreach (Item inventoryItem in itemList)
            {
               
                if(inventoryItem.m_ItemType == item.m_ItemType)
                {
                    Debug.LogWarning("this is culprit");
                    inventoryItem.m_ItemAmount += item.m_ItemAmount;
                    itemAlreadyInInventory = true;
                }
               
            }
            if (!itemAlreadyInInventory)
            {
                itemList.Add(item);
            }
        }
        else
        {
            Debug.Log("Add item else");
            itemList.Add(item);
        }

        Debug.Log(" Item added and ivoking refresh list");
        OnItemAddedToList?.Invoke();
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }
}