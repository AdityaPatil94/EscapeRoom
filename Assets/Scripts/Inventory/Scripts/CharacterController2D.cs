using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class CharacterController2D : MonoBehaviour {

	[SerializeField]
	private float MoveSpeed = 2f;
	[SerializeField]
	private bool playerGrounded;
	[SerializeField]
	private LayerMask groundLayerMask;
	[SerializeField]
	private float JumpForce = 40;

	private Rigidbody2D dinoRigidody;
	private Transform playerTransform;
	private float groundedRadius =0.5f;

	public static Action<bool> OnLandEvent;

	void Start()
    {
		dinoRigidody = transform.GetComponent<Rigidbody2D>();
		playerTransform = this.transform;
		InputController.movementInputPressed += MovePlayer;
		InputController.jumpInputPressed += PlyerJump;

	}
	
	
	private void MovePlayer(Vector3 moveDir)
    {
		if(moveDir.x<0)
        {
			transform.GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
		else if (moveDir.x > 0)
		{
			transform.GetComponentInChildren<SpriteRenderer>().flipX = false;
        }
		//transform.position += moveDir*Time.deltaTime*MoveSpeed;
		dinoRigidody.velocity = moveDir * MoveSpeed;
	}
	

	private void FixedUpdate()
	{
		bool wasGrounded = playerGrounded;
		playerGrounded = false;

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(playerTransform.position, groundedRadius, groundLayerMask);
		
		for (int i = 0; i < colliders.Length; i++)
		{
			
			if (colliders[i].gameObject != gameObject)
			{
				playerGrounded = true;
                if (!wasGrounded)
                    OnLandEvent(false);
            }
		}
	}

	private void PlyerJump (bool jump)
	{
		if (playerGrounded && jump)
        {
			// Add a vertical force to the player. 
			
			playerGrounded = false;
            dinoRigidody.AddForce(new Vector2(0f, JumpForce));
        }
    }

}
