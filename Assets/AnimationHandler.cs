using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
   private PhotonView pv;
 
  public bool PlayAnimation()
    {
        if(pv.IsMine)
        {
            return true;
        }
        return false;
    }
}
