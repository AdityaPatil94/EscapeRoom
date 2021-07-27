using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using System;
using TMPro;
using Photon.Chat;

public class PlayerListingMenu : MonoBehaviourPunCallbacks
{
    public PlayerListing PlayerListing;
    public Transform Content;
     
    private List<PlayerListing> playerListings = new List<PlayerListing>();
    private RoomCanvases playerListingCanvases;
    [SerializeField]
    private TextMeshProUGUI readyUpText;
    private bool ready = false;

    public override void OnEnable()
    {
        SetReadyUp(false);
        GetCurrentRoomPlayer();
    }

    public override void OnDisable()
    {
        for(int i =0;i<playerListings.Count;i++)
        {
            Destroy(playerListings[i].gameObject);
        }
        playerListings.Clear();
    }

    public void FirstInitialize(RoomCanvases canvases)
    {
        playerListingCanvases = canvases;
    }

    private void GetCurrentRoomPlayer()
    {
        if (!PhotonNetwork.IsConnected)
            return;
        if (PhotonNetwork.CurrentRoom == null || PhotonNetwork.CurrentRoom.PlayerCount == 0)
            return;
        foreach (KeyValuePair<int,Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            AddPlayerListing(playerInfo.Value);
        }
    }

    private void AddPlayerListing(Player player)
    {
        int index = playerListings.FindIndex(x => x.PhotonPlayer == player);
        Debug.Log("joined room player"+ playerListings.Count);
        if(index != -1)
        {
            playerListings[index].SetPlayerInfo(player);
        }
        else
        {
            PlayerListing playerListing = Instantiate(PlayerListing, Content);
            if (playerListing != null)
            {
                playerListing.SetPlayerInfo(player);
                playerListings.Add(playerListing);
                Debug.Log(playerListings.Count);
            }
        }
        
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        playerListingCanvases.CurrentRoom.LeaveRoomMenu.OnClickLeaveRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("player Entered Room");   
        AddPlayerListing(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        int index = playerListings.FindIndex(x => x.PhotonPlayer == otherPlayer);
        Debug.Log("Index-"+index);
        Debug.Log("player listing count -"+playerListings.Count);
        if (index != -1)
        {
            Destroy(playerListings[index].gameObject);
            playerListings.RemoveAt(index);
        }
    }

    private void SetReadyUp(bool state)
    {
        ready = state;
        readyUpText.text = ready==true?"R":"N";
    }

    public void OnClickReadyUp()
    {
        if(! PhotonNetwork.IsMasterClient)
        {
            SetReadyUp(!ready);
            base.photonView.RPC("RPC_ChangeReadyState",RpcTarget.MasterClient, PhotonNetwork.LocalPlayer, ready );
        }
    }

    [PunRPC]
    private void RPC_ChangeReadyState(Player player, bool ready)
    {
        int index = playerListings.FindIndex(x => x.PhotonPlayer == player);
        if (index != -1)
        {
            playerListings[index].Ready = ready;
        }
    }
    public void OnClickStartGame()
    {
       
        if (PhotonNetwork.IsMasterClient)
        {
            for (int i = 0; i < playerListings.Count; i++)
            {
                if (playerListings[i].PhotonPlayer != PhotonNetwork.LocalPlayer)
                {
                    if (playerListings[i].Ready)
                        return;
                }
            }
            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.CurrentRoom.IsVisible = false;
            
             
            PhotonNetwork.LoadLevel(1);
        }
    }
}
