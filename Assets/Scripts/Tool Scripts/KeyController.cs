using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public float range = 100f;
    public GameObject key;
    //
    private void FixedUpdate()
    {
       if(Input.GetKeyDown(KeyCode.Q))
        {
            OpenDoor();
        }
    }
    public void OpenDoor()
    {
        RaycastHit unlock;
        if(Physics.Raycast(key.transform.position, key.transform.forward, out unlock, range))
        {
            Debug.Log(unlock.transform.name);
            Debug.DrawLine(key.transform.position, unlock.point, Color.white);
        }
        if (unlock.collider.tag == "Locked")
        {
            unlock.transform.GetComponent<DoorController>().OpenDoor();
        }
    }
}
