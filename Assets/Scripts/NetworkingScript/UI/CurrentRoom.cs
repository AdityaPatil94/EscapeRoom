using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentRoom : MonoBehaviour
{
    [SerializeField]
    private PlayerListingMenu playerListingMenu;
    [SerializeField]
    private LeaveRoomMenu _leaveRoomMenu;
    private RoomCanvases roomCanvases;
    
    public LeaveRoomMenu LeaveRoomMenu { get { return _leaveRoomMenu; } }
    public void FirstInitialize(RoomCanvases canvases)
    {
        roomCanvases = canvases;
        playerListingMenu.FirstInitialize(canvases);
        _leaveRoomMenu.FirstInitialize(canvases);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);

    }
}
