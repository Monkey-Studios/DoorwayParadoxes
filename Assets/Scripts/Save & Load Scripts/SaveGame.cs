using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveGame
{
    public static void SavePlayer(SaveAndLoad playerInfo)
    {
        //Creation of binary formatter used to encrypt player infromation when they save
        BinaryFormatter formatter = new BinaryFormatter();
        //File creation and poinitng to the correct file pathway
        string path = Application.persistentDataPath + "/player.txt";
        //When making a new file a file stream must be created. Its a file that contains a stream of game information
        FileStream stream = new FileStream(path, FileMode.Create);

        //This function will write to the newly created file
        PlayerData data = new PlayerData(playerInfo);
        //Writing to the file and encrypting
        formatter.Serialize(stream, data);
        //The stream must always be closed when saviing and or loading data
        stream.Close();

    }
    //Loading player data
    public static PlayerData LoadPlayer()
    {
        //Look in this pathway for an existing save file
        string path = Application.persistentDataPath + "/player.txt";
        //If it exists open the file up
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            //This will read from the file and dencrypt
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            //The stream must always be closed when saviing and or loading data
            stream.Close();

            return data;
        }
        //If the file wasn't found return this error
        else
        {
            
            Debug.LogError("This save file has not been found in the following" + path);
            return null;
        }
    }

    
}
