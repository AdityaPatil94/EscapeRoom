using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCanvases : MonoBehaviour
{
    [SerializeField]
    private CreateOrJoinRoom createOrJoinRoom;
    public CreateOrJoinRoom CreateOrJoinRoom { get { return createOrJoinRoom; } }

    [SerializeField]
    private CurrentRoom currentRoom;
    public CurrentRoom CurrentRoom { get { return currentRoom; } }

    private void Awake()
    {
        FirstInitialize();
    }

    private void FirstInitialize()
    {
        CreateOrJoinRoom.FirstInitialize(this);
        CurrentRoom.FirstInitialize(this);
    }
}
