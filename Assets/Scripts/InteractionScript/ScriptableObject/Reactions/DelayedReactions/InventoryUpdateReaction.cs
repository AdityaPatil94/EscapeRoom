using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EscapeRoom;
public class InventoryUpdateReaction : Reaction
{
    public Item Item;
    public InventoryManager manager;
    private Inventory inventory;


    protected override void SpecificInit()
    {
        //inventory = manager.inventory;
        manager = FindObjectOfType<InventoryManager>();
    }
    protected override void ImmediateReaction()
    {
        //inventory.AddItems(Item);
        Debug.Log("inventory update immediate reaction");
        manager.inventory.AddItems(Item);
    }
}
