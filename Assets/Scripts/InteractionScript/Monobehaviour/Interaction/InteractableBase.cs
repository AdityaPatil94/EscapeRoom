using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace GeneBombardment
{
    public class InteractableBase : MonoBehaviour, IInteractable
    {
        
        public float holdDuration => HoldDuration;
        public bool holdInteract=> HoldIneract;
        public bool multipleUse=> MultipleUse;
        public bool isInteractable=> IsInteractable;
        

        [Header("Interactable Setting")]
        public float HoldDuration;
        public bool HoldIneract ;
        public bool MultipleUse ;
        public bool IsInteractable;

        public Transform interactionLocation;                   // The position and rotation the player should go to in order to interact with this Interactable.
        public ConditionCollections[] conditionCollections = new ConditionCollections[0];
        // All the different Conditions and relevant Reactions that can happen based on them.
        public ReactionCollection defaultReactionCollection;    // If none of the ConditionCollections are reacted to, this one is used.

        public void OnMouseHover()
        {
            Debug.Log("Mouse Hover"+ gameObject );
        }

        public virtual void OnInteract(bool conditionSatisfied)
        {
            Debug.Log("Player Interacted" + gameObject);
        }


        public void OnMouseHoverExit()
        {
            Debug.Log("Mouse Hover Exit" + gameObject);
        }

        
    }

}
