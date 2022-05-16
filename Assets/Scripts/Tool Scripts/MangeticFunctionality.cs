using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MangeticFunctionality : MonoBehaviour
{
    //Declaring a public float for the pull of the magnet which can be changed and edited within the inspector to suit gameplay needs
    public float MagneticPull = 200f;
    //Creating a list of the different magnetic objects
    List<Rigidbody> rgbMagneticObj = new List<Rigidbody>();
    //Creating reference to the magnetPullPoint
    Transform MagnetPullPoint;
    // Start is used to get the magnet point
    void Start()
    {
        MagnetPullPoint = GetComponent<Transform>();
    }
    //Fixed update is used to calculate the magnatism of an object when its being pulled in
    private void FixedUpdate()
    {
        foreach (Rigidbody Magobj in rgbMagneticObj)
        {
            Magobj.AddForce((MagnetPullPoint.position - Magobj.position) * MagneticPull * Time.fixedDeltaTime);
        }
    }
    //This function is used for when a magnetic object enters the radius of the players magnet
    private void OnTriggerEnter(Collider Magobj)
    {
        if(Magobj.CompareTag("Magnetic"))
        {
            rgbMagneticObj.Add(Magobj.GetComponent<Rigidbody>());
        }
    }
    //When the object leaves the magnet radius its no longer attracted
    private void OnTriggerExit(Collider Magobj)
    {
        if(Magobj.CompareTag("Magnetic"))
        {
            rgbMagneticObj.Remove(Magobj.GetComponent<Rigidbody>());
        }
    }
}
