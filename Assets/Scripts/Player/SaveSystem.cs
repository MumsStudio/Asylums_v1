using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem {

    public static void SavePlayer(playercontroller playerDt)
    {
        string path = Application.persistentDataPath + "/saves/player.dt";
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);
        SaveData data = new SaveData(playerDt);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SaveData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/saves/player.dt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            formatter.Deserialize(stream);
            stream.Close();

            SaveData data = formatter.Deserialize(stream) as SaveData;
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
