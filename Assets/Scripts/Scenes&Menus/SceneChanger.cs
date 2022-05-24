using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void CloseGame()
    {
        Debug.Log("Game has closed");
        Application.Quit();
    }
    public void StartGame()
    {
        SaveGame.Overwrite();
        SceneManager.LoadScene("Main_Game");
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("Main_Game");
    }
}
