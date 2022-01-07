using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class CharactersBounds : MonoBehaviour {

	private Vector3 screenBounds;
	private Vector3 playerBound;
	private float playerXBound, playerYBound;
	
	void Start () 
	{
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
		playerXBound = transform.GetComponentInChildren<SpriteRenderer>().bounds.size.x / 2;
		playerYBound = transform.GetComponentInChildren<SpriteRenderer>().bounds.size.y / 2;
		playerBound = new Vector3(playerXBound, playerYBound);
		
	}
	
	
	void LateUpdate () 
	{
        Vector3 playerPosition = transform.position;
        playerPosition.x = Mathf.Clamp(playerPosition.x, -screenBounds.x + playerBound.x, screenBounds.x - playerBound.x);
        playerPosition.y = Mathf.Clamp(playerPosition.y, -screenBounds.y + playerBound.y, screenBounds.y - playerBound.y);
        transform.position = playerPosition;

    }

	
}
