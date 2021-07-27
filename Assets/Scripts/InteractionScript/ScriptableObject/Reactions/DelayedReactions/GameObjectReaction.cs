using UnityEngine;

public class GameObjectReaction : DelayedReaction
{
    public GameObject HideItem;       // The gameobject to be turned on or off.
    public bool activeState;            // The state that the gameobject will be in after the Reaction.


    protected override void ImmediateReaction()
    {
        Debug.Log("Its Here");
        HideItem.SetActive (activeState);
    }
}