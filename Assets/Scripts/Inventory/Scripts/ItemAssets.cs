using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour 
{
	public static ItemAssets instance { get; private set; }
	public ItemSprite[] SpriteList;
	private void Awake()
    {
		instance = this;
    }

	public Sprite Key;
	public Sprite Note;
	public Sprite Hint;
	public Sprite Coin;
	public Sprite Object;

	public GameObject ItemWorldPrefab;
	

	public Sprite GetSprite(ItemType m_ItemType)
    {
		foreach (ItemSprite sprite in SpriteList)
		{
			if (sprite.m_ItemType == m_ItemType)
			{
				return sprite.image;
			}
			
		}
		return null;
	}
}

[System.Serializable]
public class ItemSprite
{
	public Sprite image;
	public ItemType m_ItemType;
}
