using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    [SerializeField]
    private UIInventory uIInventory;
    [SerializeField]
    private Inventory inventory;

	void Start()
    {
        inventory = new Inventory();
        uIInventory = FindObjectOfType<UIInventory>();
        uIInventory.SetInventory(inventory);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
        if ( itemWorld != null)
        {
            inventory.AddItems(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
    }
}
