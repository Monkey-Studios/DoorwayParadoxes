using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoad : MonoBehaviour
{
    //Save player data
    public void Save()
    {
        SaveGame.SavePlayer(this);
        Debug.Log("I am saving");
    }
    //Load player data
    public void Load()
    {
        Debug.Log("I am loading");
        PlayerData data = SaveGame.LoadPlayer();

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        GameObject.FindGameObjectWithTag("Player").transform.position = position;
    }

}
