using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon;
using Photon.Pun;

public class UIHealthHandler : MonoBehaviourPunCallbacks
{
    [PunRPC]
    public Image healthBar;
    public PhotonView pv;
    public bool IsLocalHealthUI;
    private void Awake()
    {
        pv = GetComponent<PhotonView>();
    }
    private void Start()
    {
        if(pv.IsMine)
        {
            IsLocalHealthUI = true;
        }
    }

    [PunRPC]
    public void RPC_RefreshHealthBar(float healthPercentage)
    {
        if (!pv.IsMine)
            return;
        healthBar.fillAmount = healthPercentage;
    } 

    public void RefreshHealthBar(float healthPercentage)
    {
        healthBar.fillAmount = healthPercentage;
        pv.RPC("RPC_RefreshHealthBar", RpcTarget.All,healthPercentage);
    }


    
}
