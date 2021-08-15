using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReference : MonoBehaviour
{
    public static PlayerReference Instance;
    public GameObject LocalPlayer;
    private void Start()
    {
        Instance = this;
    }
}
