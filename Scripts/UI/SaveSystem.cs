using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem 
{
    public static void SavePlayer (Player player)
    {
        
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.data";
        FileStream stream = new FileStream(path, FileMode.Create);
        
        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
        
    }
    public static void SaveAge(AgeOverlay ageOverlay)
    {

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Age.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        Age age = new Age(ageOverlay);

        formatter.Serialize(stream, age);
        stream.Close();

    }
    public static Age LoadAge()
    {
        string path = Application.persistentDataPath + "/Age.data";
        
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Age data = formatter.Deserialize(stream) as Age;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Age file not found in" + path);
            return null;
        }
        
    }
    public static PlayerData LoadPlayer ()
    {
        
        string path = Application.persistentDataPath + "/player.data";
        
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
       
    }
        public static void SaveScore(Player player)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/Score.data";
            FileStream stream = new FileStream(path, FileMode.Create);

            TimerScore data = new TimerScore(player);

            formatter.Serialize(stream, data);
            stream.Close();
        }

        public static TimerScore LoadScore()
        {
            string path = Application.persistentDataPath + "/Score.data";
            
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                TimerScore data = formatter.Deserialize(stream) as TimerScore;
                stream.Close();

                return data;
            }
            else
            {
                Debug.LogError("Score file not found in" + path);
                return null;
            }
        }
    public static void delete()
    {
        foreach (var directory in Directory.GetDirectories(Application.persistentDataPath))
        {
            DirectoryInfo data_dir = new DirectoryInfo(directory);
            data_dir.Delete(true);
        }

        foreach (var file in Directory.GetFiles(Application.persistentDataPath))
        {
            FileInfo file_info = new FileInfo(file);
            file_info.Delete();
        }
    }
}
