using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun.Demo.PunBasics;
public class RoomClearReaction : DelayedReaction
{
    private GameManager gameManager;            // Reference to the component to display the text.


    protected override void SpecificInit()
    {
        gameManager = FindObjectOfType<GameManager>();
    }


    protected override void ImmediateReaction()
    {
        gameManager.NextRoom();
    }
}
