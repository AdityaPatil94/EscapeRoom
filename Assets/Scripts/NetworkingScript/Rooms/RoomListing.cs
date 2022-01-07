using Photon.Realtime;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomListing : MonoBehaviour
{
    public Text RoomText;
    public RoomInfo RoomInfo { get; private set; }
    public void SetRoomInfo(RoomInfo roomInfo)
    {
        RoomText.text = roomInfo.MaxPlayers + ". " + roomInfo.Name;
        RoomInfo = roomInfo;
    }

    public void OnClickBitton()
    {
        Debug.Log(RoomInfo.Name);
        PhotonNetwork.JoinRoom(RoomInfo.Name);
    }
}
