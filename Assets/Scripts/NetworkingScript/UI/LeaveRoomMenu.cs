using UnityEngine;
using Photon.Pun;
public class LeaveRoomMenu : MonoBehaviour
{

    private RoomCanvases leaveRoomCanvases;
    public void FirstInitialize(RoomCanvases canvases)
    {
        leaveRoomCanvases = canvases;
    }
    public void OnClickLeaveRoom()
    {
        PhotonNetwork.LeaveRoom(true);
        leaveRoomCanvases.CurrentRoom.Hide();
    }

}