using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewInventory", menuName = "Inventory", order = 54)]
public class GlobalItemIventory : ScriptableObject
{
    public List<GlobalItem> itemList;
}
