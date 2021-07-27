using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorld : MonoBehaviour {

    [SerializeField]
    private Item item;
    private SpriteRenderer customSpriteRenderer;  

    //private void Awake()
    //{
    //    SetItem(new Item { itemType = Item.ItemType.healthPotion, itemAmount = 3 });
    //}
	public void SetItem(Item item)
    {
        this.item = item;
        customSpriteRenderer = GetComponent<SpriteRenderer>();
    }
    public Item GetItem()
    {
        return item;
    }

    internal void DestroySelf()
    {
        Destroy(gameObject);    
    }
}
