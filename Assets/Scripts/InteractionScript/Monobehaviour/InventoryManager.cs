using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    private UIInventory uIInventory;
    [SerializeField]
    public Inventory inventory;

    void Start()
    {
        inventory = new Inventory();
        uIInventory = FindObjectOfType<UIInventory>();
        uIInventory.SetInventory(inventory);
    }

}
