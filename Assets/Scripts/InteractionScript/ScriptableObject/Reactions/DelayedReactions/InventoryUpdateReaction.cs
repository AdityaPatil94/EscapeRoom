using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUpdateReaction : Reaction
{
    public Item Item;
    public PlayerManager manager;
    private Inventory inventory;


    protected override void SpecificInit()
    {
        inventory = manager.inventory;
    }
    protected override void ImmediateReaction()
    {
        //inventory.AddItems(Item);
        manager.inventory.AddItems(Item);
    }
}
