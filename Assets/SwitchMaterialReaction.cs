using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMaterialReaction : DelayedReaction
{
    public Material DesiredMaterial;
    public MeshRenderer meshRenderer;
     
    protected override void ImmediateReaction()
    {
        meshRenderer.material = DesiredMaterial;
    }
}
