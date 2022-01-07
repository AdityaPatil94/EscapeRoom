using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using EscapeRoom;
namespace GeneBombardment
{
    public class InteractionController : MonoBehaviour
    {
        public InteractionData InteractionDataScriptableObject;
        public InteractionInputData InteractionInputDataScriptableObject;

        private Vector3 destinationPosition;        // The position that is currently being headed towards, this is the interactionLocation of the currentInteractable if it is not null.
        //public PlayerManager playerManager;
        //public GameObject LocalPlayer;
        //PhotonView pv;

        //private void Awake()
        //{
        //    pv = GetComponent<PhotonView>();
        //}
        //void Start()
        //{
        //    if (!pv.IsMine)
        //    {
        //        Destroy(gameObject);
        //    }
        //    //Debug.Log(pv.InstantiationData);
        //    //playerManager = PhotonView.Find((int)pv.InstantiationData[0]).GetComponent<PlayerManager>();
        //    //LocalPlayer = playerManager.LocalPlayer;
        //}
        public float RayDistance;
        public float RaySphearRadious;
        public LayerMask InteractableLayer;

        [SerializeField]
        private Camera Cam;
        private bool isInteracting;
        private float holdTimer = 0f;

        private void Awake()
        {
            //Cam = FindObjectOfType<Camera>();
            //AllConditions.Instance.Reset();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                CheckForInteractable();
            }
            //CheckForInteractableInput();
        }

        private void CheckForInteractable()
        {

            Ray ray = Cam.ScreenPointToRay (Input.mousePosition);
            //Ray ray = new Ray(Cam.transform.position, Cam.transform.forward);
            RaycastHit _hitInfo;
            //bool _hitSomething = Physics.SphereCast(ray, RaySphearRadious, out _hitInfo, RayDistance, InteractableLayer);
            bool _hitSomething = Physics.Raycast(ray, out _hitInfo, RayDistance, InteractableLayer);
            Debug.Log("Hit Something -" + _hitSomething);
            if (_hitSomething)
            {
                Debug.Log(_hitInfo.distance);
                InteractableBase interactableBase = _hitInfo.transform.GetComponent<InteractableBase>();
                if (interactableBase != null)
                {

                    if (InteractionDataScriptableObject.IsEmpty())
                    {

                        InteractionDataScriptableObject.InteractableBase = interactableBase;
                        InteractionDataScriptableObject.Interact(ConditionSatisfied());
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
                            InteractionDataScriptableObject.Interact(ConditionSatisfied());
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
            if (InteractionInputDataScriptableObject.InteractedReleased)
            {

                isInteracting = false;
                holdTimer = 0;
            }

            if (isInteracting)
            {
                //if (!InteractionDataScriptableObject.InteractableBase.IsInteractable) return;
                if (InteractionDataScriptableObject.InteractableBase.holdInteract)
                {
                    holdTimer += Time.deltaTime;

                    if (holdTimer >= InteractionDataScriptableObject.InteractableBase.HoldDuration)
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

        //public void OnInterctableClicked(PickableIteminteractable interactable)
        //{
        //    float Distance = Vector3.Distance(interactable.transform.position,LocalPlayer.transform.position);
        //    Debug.Log(Distance);
        //    if (Distance > 1.5f)
        //        return;
        //    InteractionDataScriptableObject.InteractableBase = interactable;
        //    destinationPosition = InteractionDataScriptableObject.InteractableBase.interactionLocation.position;
        //    InteractionDataScriptableObject.Interact(ConditionSatisfied());
        //}
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
