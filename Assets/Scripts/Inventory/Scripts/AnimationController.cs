using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour 
{
	private Animator charaterAnimatorController;

	void Start ()
	{
		charaterAnimatorController = GetComponentInChildren<Animator>();
		InputController.movementInputPressed += SetWalkAnimation;
		InputController.jumpInputPressed += SetJumpAnimation; 
		CharacterController2D.OnLandEvent += SetJumpAnimation;
	}
	
	public void SetWalkAnimation(Vector3 value)
    {
		charaterAnimatorController.SetFloat("DinoWalk",value.sqrMagnitude);
	}

	public void SetJumpAnimation(bool jump)
    {
		charaterAnimatorController.SetBool("Jump",jump);

	}
}
