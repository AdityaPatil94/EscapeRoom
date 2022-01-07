using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomListingMenu : MonoBehaviourPunCallbacks
{
    public RoomListing RoomListing;
    public Transform Content;

    private List<RoomListing> listings = new List<RoomListing>();
    private RoomCanvases roomCanvases;

    public void FirstInitialize(RoomCanvases canvases)
    {
        roomCanvases = canvases;
    }

    public override void OnJoinedRoom()
    {
        roomCanvases.CurrentRoom.Show();
        Content.DestroyChildern();
        listings.Clear();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach(RoomInfo info in roomList)
        {
            //Removed from rooms List
            if(info.RemovedFromList)
            {
                int index = listings.FindIndex(x => x.RoomInfo.Name == info.Name);
                if(index != 1)
                {
                    Destroy(listings[index].gameObject);
                    listings.RemoveAt(index);
                }
            }
            else
            {
                int index = listings.FindIndex(x => x.RoomInfo.Name == info.Name);
                if(index == -1)
                {
                    //Added to rooms list.
                    RoomListing listing = Instantiate(RoomListing, Content);
                    if (listing != null)
                    {
                        listing.SetRoomInfo(info);
                        listings.Add(listing);
                    }
                }
                else
                {

                }
            }
            
        }
    }
}
