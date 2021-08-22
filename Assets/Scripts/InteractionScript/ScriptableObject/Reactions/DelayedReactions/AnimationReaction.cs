using UnityEngine;
using EscapeRoom;
public class AnimationReaction : DelayedReaction
{
    public string trigger;      // The name of the trigger parameter to be set.
    private PlayerManager[] playerManagers;
    private int triggerHash;    // The hash representing the trigger parameter to be set.


    protected override void SpecificInit ()
    {
        playerManagers = FindObjectsOfType<PlayerManager>();
        triggerHash = Animator.StringToHash(trigger);
    }


    protected override void ImmediateReaction ()
    {
        foreach(PlayerManager manager in playerManagers)
        {
            if(manager.IsLocalPlayerManager)
            manager.LocalPlayer.GetComponentInChildren<Animator>().SetTrigger(triggerHash);
        }
       
    }
}
