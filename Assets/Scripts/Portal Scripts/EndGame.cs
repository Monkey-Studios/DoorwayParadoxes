using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    float waitForSeconds;
    bool playerTriggerd;
    // Update is called once per frame

    private void OnTriggerStay(Collider playerCol)
    {
        if(playerCol.tag == "Player")
        {
            waitForSeconds += Time.deltaTime;
            if (waitForSeconds > 45)
            {
                waitForSeconds = 0;
                Debug.Log("Application has shut down");
                Application.Quit();
            }
        }
    }
}
