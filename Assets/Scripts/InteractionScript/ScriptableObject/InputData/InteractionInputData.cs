using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewInteractionInputData", menuName = "InteractionSystem/InputData", order =51)]
public class InteractionInputData : ScriptableObject
{
    private bool interactedClicked;
    private bool interactedReleased;

    public bool InteractedClicked
    {

        get=> interactedClicked;
        set => interactedClicked =  value;
    }

    public bool InteractedReleased
    {

        get=> interactedReleased;
        set=> interactedReleased = value ;
    }

    public void ResetInput()
    {
        interactedClicked = false;
        interactedReleased = false;
    }
}
