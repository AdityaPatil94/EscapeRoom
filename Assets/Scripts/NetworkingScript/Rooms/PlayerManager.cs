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
        public CustomGameObject PlayerController;
        public GameObject LocalPlayer;
        public bool IsLocalPlayerManager;
        private void Awake()
        {
            Vector3 RandomPosition = new Vector3(Random.Range(-4,-1), 0, Random.Range(-1, 2));
            pv = GetComponent<PhotonView>();
            PlayerController.Object = PlayerPrefab;
            PlayerController.Position =  Vector3.zero + RandomPosition;
            PlayerController.Rotation = Quaternion.identity;
            PlayerController.PV = pv;
        }
        // Start is called before the first frame update
        void Start()
        {
            if(pv.IsMine)
            {
                CreateController();
                Debug.Log("Local Player Set");
                IsLocalPlayerManager = true;
            }
            
        }

        private void CreateController()
        {
            LocalPlayer = MasterManager.NetworkInstantiate(PlayerController);
        }
//public void PlayAnimation(int triggerHash)
        //{
        //    if(pv.IsMine)
        //    LocalPlayer.GetComponentInChildren<Animator>().SetTrigger(triggerHash);
        //}

    }
}
