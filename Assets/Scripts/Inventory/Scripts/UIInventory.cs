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
	void Awake () 
	{
		itemSlotContainer = transform.Find("ItemSlotContainer");
		itemSlotTemplete = itemSlotContainer.Find("ItemTemplete");
		
		Debug.Log(itemSlotTemplete + "," + itemSlotContainer);
	}

	private void Start()
    {
        Inventory.OnItemAddedToList += ItemAddedToList;
    }

	public void SetInventory(Inventory inventory)
	{
		 
		this.inventory = inventory;
		 
		RefreshInventory();
	}

	private void ItemAddedToList()
    {
		if(inventory != null)
		RefreshInventory();
    }

	private void RefreshInventory()
    {
		
		foreach(Transform child in itemSlotContainer)
        {
			Debug.Log(itemSlotTemplete + "," + child);
			if (child == itemSlotTemplete)
				continue;
			Destroy(child.gameObject);
        }
		 
		foreach(Item item in inventory.GetItemList())
        {
			 
			itemSlotRectTransform = Instantiate(itemSlotTemplete,itemSlotContainer).GetComponent<RectTransform>();
			itemSlotRectTransform.gameObject.SetActive(true);
			Image image = itemSlotRectTransform.Find("OuterImageBorder/ImageBackground/SpriteImage").GetComponent<Image>();
			image.sprite = item.GetSprite();
			TextMeshProUGUI uiText = itemSlotRectTransform.Find("OuterImageBorder/ImageBackground/AmountText").GetComponent<TextMeshProUGUI>();

			uiText.text = item.m_ItemAmount >1 ?  item.m_ItemAmount.ToString(): "" ;
        }
    }
}
