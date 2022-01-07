using UnityEngine;
using EscapeRoom;
using StarterAssets;
public class GameObjectReaction : DelayedReaction
{
    public GameObject HideItem;       // The gameobject to be turned on or off.
    public bool activeState;            // The state that the gameobject will be in after the Reaction.
    private PlayerManager[] playerManagers;
    private PlayerManager manager;
    public bool hideFuse;
    protected override void SpecificInit()
    {
        playerManagers = FindObjectsOfType<PlayerManager>();
    }
    

    protected override void ImmediateReaction()
    {
        Debug.Log("Its Here");
        if(hideFuse)
        {
            manager = IsLocalPlayer();
            HideItem = manager.LocalPlayer.GetComponentInChildren<ThirdPersonController>().FuseObject;
        }

        HideItem.SetActive (activeState);
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