using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleportation : MonoBehaviour
{
    //We need reference to the player to send them
    public Transform Player;
    //We need reference to a reciever which will act as a drop off point for the player on the other side
    public Transform Reciever;
    //Setup for a new bool which will essentially check if the player is overlapping with the collider
    private bool PlayerOverlapping = false;
    // Update is called once per frame
    void Update()
    {
        //This checks the angluar pos of the player in relation to the portal
        if (PlayerOverlapping)
        {
            Vector3 PortalToPlayer = Player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, PortalToPlayer);

            //If the following statement is true then the player has collided with the portal
            if (dotProduct < 0f)
            {
                //Roatation difference between the portals
                float rotationDiff = -Quaternion.Angle(transform.rotation, Reciever.rotation);
                //Player is rotated so that they come out the portal correctly
                rotationDiff += 180;
                Player.Rotate(Vector3.up, rotationDiff);
                //Spits the player back out on the otherside and positions them correctly
                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * PortalToPlayer;
                Player.position = Reciever.position + positionOffset;
                //Disable player overlapping check
                PlayerOverlapping = false;
            }
        }
    }
    void OnTriggerEnter(Collider player)
    {
        if(player.tag == "Player")
        {
            PlayerOverlapping = true;
        }
    }
    void OnTriggerExit(Collider player)
    {
       if(player.tag == "Player")
        {
            PlayerOverlapping = false;
        }
    }

}
