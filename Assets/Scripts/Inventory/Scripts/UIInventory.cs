using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIInventory : MonoBehaviour 
{
	
	private Inventory inventory;
	[SerializeField]
	private Transform itemSlotContainer;
	[SerializeField]
	private Transform itemSlotTemplete;

	public RectTransform itemSlotRectTransform;
	public GlobalItemIventory GlobalInventory;
	void Awake () 
	{
		itemSlotContainer = transform.Find("Viewport/itemSlotContainer");
		itemSlotTemplete = itemSlotContainer.Find("itemSlotTemplete");
		
		Debug.Log(itemSlotTemplete + "," + itemSlotContainer);
	}

	private void Start()
    {
        Inventory.OnItemAddedToList += ItemAddedToList;
    }

    public void OnDisable()
    {
        Inventory.OnItemAddedToList -= ItemAddedToList;

	}
	public void SetInventory(Inventory inventory)
	{
		 
		this.inventory = inventory;
		 
		RefreshInventory();
	}

	private void ItemAddedToList()
    {
		Debug.Log("Item added to list");
		if(inventory != null)
		RefreshInventory();
		Debug.Log("Item Added to List");
    }

	private void RefreshInventory()
    {

        foreach (Transform child in itemSlotContainer)
        {
            Debug.Log(itemSlotTemplete + "," + child);
            if (child == itemSlotTemplete)
                continue;
            Destroy(child.gameObject);
        }

        foreach (Item item in inventory.GetItemList())
        {

			Debug.Log("item count - " + inventory.GetItemList().Count);
			itemSlotRectTransform = Instantiate(itemSlotTemplete,itemSlotContainer).GetComponent<RectTransform>();
			itemSlotRectTransform.gameObject.SetActive(true);
			Image image = itemSlotRectTransform.Find("Image - ItemSprite").GetComponent<Image>();
			TextMeshProUGUI uiText = itemSlotRectTransform.Find("Text (TMP) - ItemCount").GetComponent<TextMeshProUGUI>();
			Debug.Log("uiText -" + uiText);

			foreach (GlobalItem globalItem in GlobalInventory.itemList)
			{
				if(globalItem.m_ItemType == item.m_ItemType)
                {
					image.sprite = globalItem.m_ItemSprite;
					Debug.Log(item.m_ItemAmount);
					uiText.text = item.m_ItemAmount > 1 ? item.m_ItemAmount.ToString() : "";
					//return;
				}
			}
			//image.sprite = item.m_ItemSprite;
			
        }
    }
}
