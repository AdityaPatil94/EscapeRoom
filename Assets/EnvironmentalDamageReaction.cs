using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EscapeRoom;
public class EnvironmentalDamageReaction : Reaction
{
    private EnvironmentalDamager environmentalDamager;
    private TimerHandler timeHandler;

    protected override void SpecificInit()
    {
        environmentalDamager = FindObjectOfType<EnvironmentalDamager>();
        timeHandler = FindObjectOfType<TimerHandler>();
    }

    protected override void ImmediateReaction()
    {
        environmentalDamager.ShouldStartDamage = true;
        timeHandler.StartTimer = true;
    }
}
