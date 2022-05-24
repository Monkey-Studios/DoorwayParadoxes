using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSwitcher : MonoBehaviour
{
    //References to other scripts
    //public MangeticFunctionality mf;
    public KeyController kc;
    //public PotionController pc;
    public GameObject Torch;
    public GameObject Key;
    public GameObject Magnet;
    //Used to check which player item is being used
    int item;
    //Checks what case is true and enables correct script accordingly
    private void Update()
    {
            if (Torch.activeInHierarchy)
            {
                item = 0;
            }
            else if (Key.activeInHierarchy)
            {
                item = 1;
            }
            else if (Magnet.activeInHierarchy)
            {
                item = 2;
            }
            else
            {
                return;
            }
  
    }
    //This function will check what item the player wants to use
    public void CheckItem()
    {
        switch (item)
        { 
            case 0:
                kc.OpenDoor();
                break;

        }

    }
}
