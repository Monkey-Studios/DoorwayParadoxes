using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public float range = 100f;
    public GameObject key;
    public Animator doorAnimator;
    float doorTimer;
    bool doorOpen;
    //
    private void FixedUpdate()
    {
       if(Input.GetKeyDown(KeyCode.Q))
        {
            OpenDoor();
        }
       if(doorOpen)
        {
            doorTimer += Time.fixedDeltaTime;
            if(doorTimer > 5)
            {
                doorTimer = 0;
                doorAnimator.SetTrigger("DoorClosed");
                doorOpen = false;
            }
        }
    }
    void OpenDoor()
    {
        RaycastHit unlock;
        if(Physics.Raycast(key.transform.position, key.transform.forward, out unlock, range))
        {
            Debug.Log(unlock.transform.name);
            Debug.DrawLine(key.transform.position, unlock.point, Color.white);
        }
        if (unlock.collider.tag == "Locked")
        {
            doorOpen = true;
            doorAnimator.SetTrigger("DoorOpen");
        }
    }
}
