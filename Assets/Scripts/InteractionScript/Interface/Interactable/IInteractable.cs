using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GeneBombardment
{
    public interface IInteractable
    {
        float holdDuration { get; }
        bool holdInteract { get; }
        bool multipleUse { get; }
        bool isInteractable { get; }


        public void OnMouseHover();
        public void OnInteract(bool conditionSatisfied);
        public void OnMouseHoverExit();

    }
}
