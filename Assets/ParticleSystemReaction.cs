using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemReaction : DelayedReaction
{
    public ParticleSystem[] ParticleList;
    protected override void SpecificInit()
    {
        
    }


    protected override void ImmediateReaction()
    {
        foreach (var s in ParticleList)
        {
            s.Play();
        }
    }
}
