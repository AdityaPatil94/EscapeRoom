using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace EscapeRoom
{
    public class PlayerManager : MonoBehaviourPunCallbacks
    {
        PhotonView pv;
        public GameObject PlayerPrefab;
        public CustomGameObject CustomGameObject;
        //[SerializeField]
        //private UIInventory uIInventory;
        //[SerializeField]
        //private Inventory inventory;

        private void Awake()
        {
            Vector3 RandomPosition = new Vector3(Random.Range(-4,-1), 0, Random.Range(-1, 2));
            pv = GetComponent<PhotonView>();
            CustomGameObject.Object = PlayerPrefab;
            CustomGameObject.Position =  Vector3.zero + RandomPosition;
            CustomGameObject.Rotation = Quaternion.identity;
        }
        // Start is called before the first frame update
        void Start()
        {
            if(pv.IsMine)
            {
                CreateController();
            }
            //inventory = new Inventory();
            //uIInventory = FindObjectOfType<UIInventory>();
            //uIInventory.SetInventory(inventory);
        }

        private void CreateController()
        {
            MasterManager.NetworkInstantiate(CustomGameObject);
        }
    }
}
