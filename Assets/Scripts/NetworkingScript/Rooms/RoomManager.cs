using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using System;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public static RoomManager Instance;
    public GameObject playerManager;
    public GameObject VoiceCallCanvas;
    public GameObject HealthBarCanvas;
    public GameObject HealthBarParent;
    public List<GameObject> HealthBarList;
    private CustomGameObject customPlayerGameObject = new CustomGameObject();
    private CustomGameObject customVoiceCallGameObject = new CustomGameObject();
    private CustomGameObject customHealthGameObject = new CustomGameObject();
    private PhotonView pv;
    private void Awake()
    {
        if(Instance)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
        Instance = this;

        pv = GetComponent<PhotonView>();

        customPlayerGameObject.Object = playerManager;
        customPlayerGameObject.Position = transform.position;
        customPlayerGameObject.Rotation = Quaternion.identity;
        customPlayerGameObject.PV = pv;

        customVoiceCallGameObject.Object = VoiceCallCanvas;
        customVoiceCallGameObject.Position = transform.position;
        customVoiceCallGameObject.Rotation = Quaternion.identity;
        customVoiceCallGameObject.PV = pv;

        //customHealthGameObject.Object = HealthBarCanvas;
        //customHealthGameObject.Position = transform.position;
        //customHealthGameObject.Rotation = Quaternion.identity;
        //customHealthGameObject.PV = pv;


    }

    public override void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if(scene.buildIndex == 1)
        {
            MasterManager.NetworkInstantiate(customPlayerGameObject);
            MasterManager.NetworkInstantiate(customVoiceCallGameObject);
            //MasterManager.NetworkInstantiate(customHealthGameObject);
        }
    }

    public override void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
