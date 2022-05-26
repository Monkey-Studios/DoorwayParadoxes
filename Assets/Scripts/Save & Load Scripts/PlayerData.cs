using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData 
{
    /* Vector 3 is not seralizable because of this I need to contain player location in an array.
     This stores the X, Y and Z positions*/
    public float[] position;
    //Stores information of as to which item is in which slot
    public bool[] itemSlot;
    //Storing the information for each coordinate
    public PlayerData(SaveAndLoad playerInfo)
    {
        //
        position = new float[3];
        position[0] = GameObject.FindGameObjectWithTag("Player").transform.position.x;
        position[1] = GameObject.FindGameObjectWithTag("Player").transform.position.y;
        position[2] = GameObject.FindGameObjectWithTag("Player").transform.position.z;
        //Loops through inventory list and set the bool that an item was active within it
        itemSlot = GameObject.FindGameObjectWithTag("Player").GetComponent<ItemList>().returnCurrentInventory();
    }

    
}
