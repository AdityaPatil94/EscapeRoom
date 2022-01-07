using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom Scriptable Asset/Manager/Game Settings", fileName = "New Game Settings", order = 52)]
public class GameSettings : ScriptableObject
{
    [SerializeField]
    private string gameVersion = "0.0.1";
    public string GameVersion { get { return gameVersion; } }
    [SerializeField]
    private string nickName = "PunFish";
    public string NickName 
    { 
        get 
        {
            int value = Random.Range(0,9999);
            return nickName + value.ToString(); 
        }
    }

}
