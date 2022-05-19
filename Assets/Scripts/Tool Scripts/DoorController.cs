using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animator doorAnimator;
    private bool isDoorOpen;
    float doorTimer;
    // Start is called before the first frame update
    void Start()
    {
        doorAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDoorOpen)
        {
            doorTimer += Time.deltaTime;
            if (doorTimer > 2)
            {
                doorTimer = 0;
                doorAnimator.SetTrigger("DoorClosed");
                isDoorOpen = false;
            }
        }
    }
    public void OpenDoor()
    {
        if(!isDoorOpen)
        {
            isDoorOpen = true;
            doorAnimator.SetTrigger("DoorOpen");
        }
    }
}
