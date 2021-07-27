using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GeneBombardment
{
    public class InteractionController : MonoBehaviour
    {
        public InteractionData InteractionDataScriptableObject;
        public InteractionInputData InteractionInputDataScriptableObject;

        public float RayDistance;
        public float RaySphearRadious;
        public LayerMask InteractableLayer;

        private Camera Cam;
        private bool isInteracting;
        private float holdTimer =0f;

        private void Awake()
        {
            Cam = FindObjectOfType<Camera>();
            AllConditions.Instance.Reset();
        }

        private void Update()
        {
            CheckForInteractable();
            CheckForInteractableInput();
        }

        private void CheckForInteractable()
        {
            
            //Ray rayTest = Cam.ScreenPointToRay(Input.mousePosition);
            Ray ray = new Ray(Cam.transform.position, Cam.transform.forward);
            RaycastHit _hitInfo;
            bool _hitSomething = Physics.SphereCast(ray, RaySphearRadious, out _hitInfo, RayDistance, InteractableLayer);

            if (_hitSomething)
            {
                InteractableBase interactableBase = _hitInfo.transform.GetComponent<InteractableBase>();
                if (interactableBase != null)
                {
                   
                    if (InteractionDataScriptableObject.IsEmpty())
                    {
                       
                        InteractionDataScriptableObject.InteractableBase = interactableBase;
                    }
                    else
                    {
                        if (InteractionDataScriptableObject.IsSameInteractable(interactableBase))
                        {
                            return;
                        }
                        else
                        {
                            InteractionDataScriptableObject.InteractableBase = interactableBase;
                        }
                    }
                }
            }
            else
            {
                InteractionDataScriptableObject.ResetData();
            }

            //Debug.DrawLine(Cam.transform.position, _hitInfo.transform.position);
        }

        private void CheckForInteractableInput()
        {
            if (InteractionDataScriptableObject.IsEmpty())
                return;
            
            if (InteractionInputDataScriptableObject.InteractedClicked)
            {
                isInteracting = true;
                holdTimer = 0;
            }
            if(InteractionInputDataScriptableObject.InteractedReleased)
            {
                
                isInteracting = false;
                holdTimer = 0;
            }

            if (isInteracting)
            {
                //if (!InteractionDataScriptableObject.InteractableBase.IsInteractable) return;
                if(InteractionDataScriptableObject.InteractableBase.holdInteract)
                {
                    holdTimer += Time.deltaTime;

                    if(holdTimer >=InteractionDataScriptableObject.InteractableBase.HoldDuration)
                    {
                            InteractionDataScriptableObject.Interact(ConditionSatisfied());
                            isInteracting = false;
                    }
                }
                else
                {
                        InteractionDataScriptableObject.Interact(ConditionSatisfied());
                }
            }
        }

       private bool ConditionSatisfied()
        {

            for (int i = 0; i < InteractionDataScriptableObject.InteractableBase.conditionCollections.Length; i++)
            {
                // ... then check and potentially react to each.  If the reaction happens, exit the function.
                if (InteractionDataScriptableObject.InteractableBase.conditionCollections[i].CheckAndReact())
                    return true;
            }
            return false;
        }
    }

}
