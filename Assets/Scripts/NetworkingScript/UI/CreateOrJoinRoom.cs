using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOrJoinRoom : MonoBehaviour
{
    [SerializeField]
    private CreateRoomMenu createRoomMenu;
    private RoomCanvases roomCanvases;
    [SerializeField]
    private RoomListingMenu roomListingMenu;

    public void FirstInitialize(RoomCanvases canvases)
    {
        roomCanvases = canvases;
        createRoomMenu.FirstInitialize(canvases);
        roomListingMenu.FirstInitialize(canvases);
    }
}
