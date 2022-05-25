using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    //Waits for X amount of time before triggering
    float waitForSeconds;
    //Audio Source reference
    [SerializeField] AudioSource GameOver;
    [SerializeField] AudioSource StopTrack;
    // Update is called once per frame

    private void OnTriggerStay(Collider playerCol)
    {
        if(playerCol.tag == "Player")
        {
            StopTrack.enabled = false;
            GameOver.enabled = true;
            waitForSeconds += Time.deltaTime;
            if (waitForSeconds > 12)
            {
                waitForSeconds = 0;
                Debug.Log("Application has shut down");
                Application.Quit();
            }
        }
    }
}
