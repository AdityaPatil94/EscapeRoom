using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

[CreateAssetMenu(menuName ="Custom Scriptable Asset/Singleton/Master Manager", fileName = "New Master Manager" ,order =51)]
public class MasterManager : SingeltonScriptableObject<MasterManager>
{
    [SerializeField]
    private GameSettings gameSettings;
    public GameSettings GameSettings { get { return gameSettings; } }
    [SerializeField]
    private List<NetworkedPrefab> networkedPrefabs = new List<NetworkedPrefab>();
    public static GameObject NetworkInstantiate(CustomGameObject customGameObject)
    {
        foreach(NetworkedPrefab prefab in Instance.networkedPrefabs)
        {
            if(prefab.Prefab == customGameObject.Object)
            {
                if(prefab.Path != string.Empty)
                {
                    GameObject result = PhotonNetwork.Instantiate(prefab.Path, customGameObject.Position, customGameObject.Rotation);
                    return result;
                }
                else
                {
                    Debug.Log("Path is empty for "+prefab.Prefab );
                    return null;   
                }
            }
        }
        return null;
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void PopulateNetworkedPrefab()
    {
#if UNITY_EDITOR
        Instance.networkedPrefabs.Clear();

        GameObject[] results = Resources.LoadAll<GameObject>("");
        for (int i = 0;i<results.Length;i++)
        {
            if(results[i].GetComponent<PhotonView>() !=null)
            {
                string path = AssetDatabase.GetAssetPath(results[i]);
                Instance.networkedPrefabs.Add(new NetworkedPrefab(results[i],path));
            }
        }

        for (int i = 0; i < Instance.networkedPrefabs.Count; i++)
        {
            UnityEngine.Debug.Log(Instance.networkedPrefabs[i].Prefab.name + ", " +Instance.networkedPrefabs[i].Path);
        }

#endif
    }
}

[Serializable]
public class CustomGameObject
{
    public GameObject Object;
    public Vector3 Position;
    public Quaternion Rotation;
}