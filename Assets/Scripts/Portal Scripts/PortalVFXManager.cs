using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalVFXManager : MonoBehaviour
{
    //References to Camera B and its texure
    public Camera CameraB;
    public Material CameraMaterialB;
    //References to Camera A and its texure
    public Camera CameraA;
    public Material CameraMaterialA;
    //Start is used to correctly assign and display the render texture to fit the screen 
    void Start()
    {
        //Camera A
        if (CameraA.targetTexture != null)
        {
            CameraA.targetTexture.Release();
        }
        CameraA.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        CameraMaterialA.mainTexture = CameraA.targetTexture;
        //Camera B 
        if (CameraB.targetTexture != null)
        {
            CameraB.targetTexture.Release();
        }
        CameraB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        CameraMaterialB.mainTexture = CameraB.targetTexture;
    }

}
