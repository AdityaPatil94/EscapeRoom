using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour 
{
	public static ItemAssets instance { get; private set; }

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
	
}
