using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPortal : MonoBehaviour
{
    // I want the camera to follow the player cam so that the portal is displayed correctly
    public Transform PlayerCam;
    //Reference to both portals is needed
    public Transform portal;
    public Transform secondaryPortal;

    // Update is called once per frame
    void Update()
    {
        //The both position of the player and portal in relevance to one another is important to get the most accurate display from the portal
        Vector3 playerOffset = PlayerCam.position - secondaryPortal.position;
        transform.position = portal.position + playerOffset;
        /*In order to have the illusion remain while the camera is rotated. 
        Aka player looking left and right the camera for the portal also needs to be offset*/
        float PortalAngularRotationDifference = Quaternion.Angle(portal.rotation, secondaryPortal.rotation);
        //Rotate the difference on an angle axis
        Quaternion PortalRotationDifference = Quaternion.AngleAxis(PortalAngularRotationDifference, Vector3.up);
        //This new Vector3 will get the camera angular calcuations just made and times it be the forward player cam
        Vector3 CameraDirection = PortalRotationDifference * PlayerCam.forward;
        transform.rotation = Quaternion.LookRotation(CameraDirection, Vector3.up);
    }
}
