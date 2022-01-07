using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.FinalIK;
using EscapeRoom;
public class InteractionReaction : DelayedReaction
{

	[Tooltip("The object to interact to")]
	public InteractionObject interactionObject;
	[Tooltip("The effectors to interact with")]
	public FullBodyBipedEffector[] effectors;
	//public GameObject tempPlayerManager;
	public PlayerManager[] playerManagers;
	public PlayerManager manager;
	private InteractionSystem interactionSystem;


	protected override void SpecificInit()
	{
		playerManagers = FindObjectsOfType<PlayerManager>();
	}


	protected override void ImmediateReaction()
	{
        manager = IsLocalPlayer();
        interactionSystem = manager.LocalPlayer.GetComponentInChildren<InteractionSystem>();

        if (interactionSystem == null) return;
	
		if (effectors.Length == 0) Debug.Log("Please select the effectors to interact with.");

		foreach (FullBodyBipedEffector e in effectors)
		{
			interactionSystem.StartInteraction(e, interactionObject, true);
		}
	}

	private PlayerManager IsLocalPlayer()
    {
		Debug.Log("Searching Local player");
		foreach (PlayerManager manager in playerManagers)
		{
			if (manager.IsLocalPlayerManager)
				return manager;
		}
		return null;
	}

}
