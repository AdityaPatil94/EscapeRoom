using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class InstantiateExample : MonoBehaviour
{
    public GameObject Prefab;
    private CustomGameObject customGameObject;
    PhotonView pv;
    private void Awake()
    {
        Vector3 RandomPosition = new Vector3(Random.Range(0, 5), 0, Random.Range(0, 5));
        customGameObject = new CustomGameObject();
        customGameObject.Object = Prefab;
        customGameObject.Position = (transform.position + RandomPosition);
        customGameObject.Rotation = Quaternion.identity;
        pv = GetComponent<PhotonView>();
        //if(pv.IsMine)
        {
            MasterManager.NetworkInstantiate(customGameObject);
        }
       

    }
}
