using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerListing : MonoBehaviour
{
    public Text PlayerText;
    public Player PhotonPlayer { get; private set; }
    public bool Ready = false;
    public void SetPlayerInfo(Player playerInfo)
    {
        PhotonPlayer = playerInfo;
        PlayerText.text = playerInfo.NickName;
        
    }
}
