using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class customMovement : MonoBehaviour
{
    public float movementSpeed;
    public float RotationSpeed;

    PhotonView pv;
    float vertical ;
    float Horizontal;

    private void Awake()
    {
        pv = GetComponent<PhotonView>();
    }
    private void Start()
    {
       
        if(!pv.IsMine)
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(pv.IsMine)
        checkInput();
    }

    public void checkInput()
    {
       
        vertical = Input.GetAxis("Vertical");
        Horizontal = Input.GetAxis("Horizontal");
        
        transform.position += transform.forward * (vertical * movementSpeed * Time.deltaTime);
        transform.Rotate(new Vector3(0, Horizontal * RotationSpeed * Time.deltaTime, 0));
    }
}
