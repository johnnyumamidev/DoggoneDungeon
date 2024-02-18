using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveProgress(PlayerProgress playerProgress) {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + ".save";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(playerProgress);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadFile() {
        string path = Application.persistentDataPath + ".save";
        if(File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else {
            Debug.LogError("no save data found");
            return null;
        }
    }
}
