using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{

	public static Action<bool> jumpInputPressed;
	public static Action<Vector3> movementInputPressed;
	private Vector3 moveDir;
	private float moveX = 0f;
	private float moveY = 0f;
 
	
	void Update () 
	{
		moveY = (Input.GetAxis("Vertical"));
		moveX = (Input.GetAxis("Horizontal"));
		moveDir = new Vector3(moveX, moveY);
		movementInputPressed(moveDir);
		jumpInputPressed(Input.GetKeyDown("space"));
	}
}
