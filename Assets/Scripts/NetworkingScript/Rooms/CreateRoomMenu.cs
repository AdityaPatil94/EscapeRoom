using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class CreateRoomMenu : MonoBehaviourPunCallbacks
{

    
    public Text RoomName;
    public byte MaxPlayer;

    private RoomCanvases roomCanvases;

    public void FirstInitialize(RoomCanvases canvases)
    {
        roomCanvases = canvases;
    }
    public void OnClickCreateRoom()
    {
        if (!PhotonNetwork.IsConnected)
            return;
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = MaxPlayer;
        PhotonNetwork.JoinOrCreateRoom(RoomName.text,options,TypedLobby.Default);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Room created successfully");
        roomCanvases.CurrentRoom.Show();
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.LogError("Room creation failed"+message);
    }
}

