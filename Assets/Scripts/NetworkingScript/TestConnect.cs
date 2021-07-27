using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class TestConnect : MonoBehaviourPunCallbacks
{
    public MasterManager MasterManager;
   
    void Start()
    {
        Debug.Log("Connecting to server");
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion;
        PhotonNetwork.NickName = MasterManager.GameSettings.NickName;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to server");
        //PhotonNetwork.AutomaticallySyncScene = true;
        if(!PhotonNetwork.InLobby)
        PhotonNetwork.JoinLobby();
        
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Disconnected from server for " + cause.ToString());
    }
}
