using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NetworkedPrefab 
{
    public GameObject Prefab;
    public string Path;

    public NetworkedPrefab(GameObject obj,string path)
    {
        Prefab = obj;
        Path = ReturnModifiedPrefabPath(path);
    }

    private string ReturnModifiedPrefabPath(string path)
    {
        int extensionLength = System.IO.Path.GetExtension(path).Length;
        int additionLength = 10;
        int startIndex = path.ToLower().IndexOf("resources");
        if(startIndex == -1)
        {
            return string.Empty;
        }
        else
            return path.Substring(startIndex+additionLength,path.Length -(additionLength + startIndex + extensionLength));
    }
}
