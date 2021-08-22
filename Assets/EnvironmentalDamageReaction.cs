using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EscapeRoom;
public class EnvironmentalDamageReaction : Reaction
{
    private EnvironmentalDamager environmentalDamager;

    protected override void SpecificInit()
    {
        environmentalDamager = FindObjectOfType<EnvironmentalDamager>();
    }

    protected override void ImmediateReaction()
    {
        environmentalDamager.ShouldStartDamage = true;
    }
}
