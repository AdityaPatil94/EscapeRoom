using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GeneBombardment
{
    //this class inherit InteractableBase and override OnInteract()
    //Setting object inactive on interacting and adding it to Inventory.
    public class PickableIteminteractable : InteractableBase
    {
        
      
        public override void OnInteract(bool conditionSatisfied)
        {
            if(!conditionSatisfied)
            {
                //play reaction
                Debug.Log("OnInteract");
                defaultReactionCollection.React();
            }
        }
    }

}
