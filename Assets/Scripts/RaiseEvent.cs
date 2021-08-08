using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using ExitGames.Client.Photon;

public class RaiseEvent : MonoBehaviour
{
    public SpriteRenderer RaiseEventSprit;
    private const byte COLOR_CHANGE_EVENT = 0;
    // Start is called before the first frame update
    void Start()
    {
        RaiseEventSprit = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        PhotonNetwork.NetworkingClient.EventReceived += NetworkingClient_EventReceived;
    }

    private void NetworkingClient_EventReceived(EventData obj)
    {
        if(obj.Code == COLOR_CHANGE_EVENT)
        {
            object[] data = (object[])obj.CustomData;
            float r = (float)data[0];
            float g = (float)data[1];
            float b = (float)data[2];
            RaiseEventSprit.color = new Color(r, g, b,1f);
        }
    }

    private void OnDisable()
    {
        PhotonNetwork.NetworkingClient.EventReceived -= NetworkingClient_EventReceived;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ChangeColor();
        }
    }

    public void ChangeColor()
    {
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);

        RaiseEventSprit.color = new Color(r,g,b);

        object data = new object[] {r,g,b};

        PhotonNetwork.RaiseEvent(COLOR_CHANGE_EVENT, data, RaiseEventOptions.Default,SendOptions.SendUnreliable);
    }
         
}
