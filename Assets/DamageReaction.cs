using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EscapeRoom;
public class DamageReaction : DelayedReaction
{
    private PlayerHealthHandler[] healthHandlerList;
    private PlayerHealthHandler handler;
    public float DamageAmount;
    protected override void SpecificInit()
    {
        SetPLayerHealth();
    }

    protected override void ImmediateReaction()
    {
        handler.TakeDamage(DamageAmount);
    }
    public void SetPLayerHealth()
    {
        healthHandlerList = FindObjectsOfType<PlayerHealthHandler>();

        foreach (PlayerHealthHandler pHandler in healthHandlerList)
        {
            if (pHandler.IsLocalPlayerHealth)
            {
                handler = pHandler;
                return;
            }
        }
    }

}
