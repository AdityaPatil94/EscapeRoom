using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

namespace EscapeRoom
{
    public class PlayerManager : MonoBehaviourPunCallbacks
    {
        PhotonView pv;
        public GameObject PlayerPrefab;
        //public GameObject interactionControllerPrefab;
        public CustomGameObject PlayerController;
        //public CustomGameObject InteractionController;
        public GameObject LocalPlayer;
        private void Awake()
        {
            Vector3 RandomPosition = new Vector3(Random.Range(-4,-1), 0, Random.Range(-1, 2));
            pv = GetComponent<PhotonView>();
            PlayerController.Object = PlayerPrefab;
            PlayerController.Position =  Vector3.zero + RandomPosition;
            PlayerController.Rotation = Quaternion.identity;
            PlayerController.PV = pv;

            //InteractionController.Object = interactionControllerPrefab;
            //InteractionController.Position = Vector3.zero + RandomPosition;
            //InteractionController.Rotation = Quaternion.identity;
            //InteractionController.PV = pv;
        }
        // Start is called before the first frame update
        void Start()
        {
            if(pv.IsMine)
            {
                CreateController();
            }
        }

        private void CreateController()
        {
            if(pv.IsMine)
            {
                ////LocalPlayer = PhotonNetwork.Instantiate(prefab.Path, customGameObject.Position, customGameObject.Rotation, customGameObject.GroupOfPrefab, new object[] { customGameObject.PV.ViewID });
                //LocalPlayer = PhotonNetwork.Instantiate(Path.Combine());
                LocalPlayer = MasterManager.NetworkInstantiate(PlayerController);
                //MasterManager.NetworkInstantiate(InteractionController);
            }
            
        }

        public void PlayAnimation(int triggerHash)
        {
            if(pv.IsMine)
            LocalPlayer.GetComponentInChildren<Animator>().SetTrigger(triggerHash);
        }
    }
}
