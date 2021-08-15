using UnityEngine;
using EscapeRoom;
public class AnimationReaction : DelayedReaction
{
    public Animator animator;   // The Animator that will have its trigger parameter set.
    public string trigger;      // The name of the trigger parameter to be set.
    private PlayerManager[] playerManagers;
    private PlayerManager playerManager;
    private int triggerHash;    // The hash representing the trigger parameter to be set.


    protected override void SpecificInit ()
    {
        //Debug.Log("hey");
        playerManagers = FindObjectsOfType<PlayerManager>();
        triggerHash = Animator.StringToHash(trigger);
        playerManager = FindObjectOfType<PlayerManager>();
        //textManager = FindObjectOfType<TextManager>();
    }


    protected override void ImmediateReaction ()
    {
        foreach(PlayerManager manager in playerManagers)
        {
            manager.PlayAnimation(triggerHash);
        }
       
    }
}
