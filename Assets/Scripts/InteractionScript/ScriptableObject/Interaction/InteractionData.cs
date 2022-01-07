using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GeneBombardment
{
    [CreateAssetMenu(fileName = "InteractionData", menuName = "InteractionSystem/InteractionData", order =52)]
    public class InteractionData : ScriptableObject
    {
        private InteractableBase interactaleBase;

        public InteractableBase InteractableBase { get => interactaleBase;set=> interactaleBase = value; }

        public void Interact(bool conditionSatisfied)
        {
            interactaleBase.OnInteract(conditionSatisfied);
            ResetData();
        }

        public bool IsSameInteractable(InteractableBase newInteractableBase)
        {
            return interactaleBase == newInteractableBase;
        }

        public void ResetData()
        {
            interactaleBase = null;
        }

        public bool IsEmpty()
        {
            return interactaleBase == null;
        }
    }

}
