using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemList : MonoBehaviour
{
    //Creats a list of all the game objects the player is holding
    public List<GameObject> inventoryList;
    public GameObject Torch;
    public GameObject Key;
    public GameObject Magnet;
    //Reference to the inventory hud
    public GameObject[] InventoryHUD;
    //Reference to the inventory images
    public Sprite TorchImg;
    public Sprite KeyImg;
    public Sprite MagnetImg;
    //Cap item limit of the inventory
    public int maxCap = 3;
    //Used within the system to point the correct item
    int pointer;
    // Start is called before the first frame update
    void Start()
    {
        //When the level starts it will make sure to have the audio loaded
        //pickup = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            switchItem();
        }
    }
    private void OnTriggerEnter(Collider collidedObject)
    {
        //This checks to see if the inventory cap has been reached. If it has then it won't proceed with the embedded if.
        if(inventoryList.Count -1 < maxCap)
        {
            //Switch statement to check if an object with this script has collided with the player it will be picked up by the player
            switch (collidedObject.tag)
            {
                case "Torch":
                    collidedObject.gameObject.SetActive(false);
                    inventoryList.Add(collidedObject.transform.gameObject);
                    break;
                case "Key":
                    //kc.IncrementKeys();
                    //pickup.Play();
                    collidedObject.gameObject.SetActive(false);
                    inventoryList.Add(collidedObject.transform.gameObject);
                    break;
                case "Magnet":
                    //hc.PickUpPotion();
                    //pickup.Play();
                    collidedObject.gameObject.SetActive(false);
                    inventoryList.Add(collidedObject.transform.gameObject);
                    break;
            }
            displayIcons();
        }
    }
    //Changes the value of the pointer to scan through inventory
    public void switchItem()
    {
            Debug.Log("E");
            if (pointer == inventoryList.Count - 1)
            {
                pointer = 0;
            }
            else
            {
                pointer++;
            }
        Torch.SetActive(false);
        Magnet.SetActive(false);
        Key.SetActive(false);
        //Checking the tag for an object within the inventory to assign the correct game object accordingly
        switch (inventoryList[pointer].tag)
        {
            case "Torch":
                Torch.SetActive(true);
                break;
            case "Key":
                Key.SetActive(true);
                break;
            case "Magnet":
                Magnet.SetActive(true);
                break;
        }
    }
    public void SelectItem(int i)
    {
        GameObject obj = Instantiate(inventoryList[i], new Vector3(transform.position.x - 2, transform.position.y, transform.position.z - 2) , Quaternion.identity);
        obj.SetActive(true);
        inventoryList.RemoveAt(i);
        displayIcons();
    }
    //This will try to get the value of the inventory list and enabled the buttons, Otherwise it will set it to be false
    public void displayIcons()
    {
        for(int i = 0; i < maxCap; i++)
        {
            try
            {
                if(inventoryList[i] != null)
                {
                    InventoryHUD[i].SetActive(true);
                    switch (inventoryList[i].tag)
                    {
                        case "Torch":
                            InventoryHUD[i].GetComponent<Image>().sprite = TorchImg;
                            break;
                        case "Key":
                            InventoryHUD[i].GetComponent<Image>().sprite = KeyImg;
                            break;
                        case "Magnet":
                            InventoryHUD[i].GetComponent<Image>().sprite = MagnetImg;
                            break;
                    }
                }
            }
            catch
            {
                InventoryHUD[i].SetActive(false);
            }
        }
    }
}
