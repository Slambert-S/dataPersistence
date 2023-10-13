using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PercictenceManager : MonoBehaviour
{

    public static PercictenceManager Instance;
    public int bestScore;
    public string name;

    private void Awake()
    {

        if (Instance != null)
        {
           
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();

    }

    [System.Serializable]
    class SaveData
    {
        //public string name;
        public int bestScroe;
    }


    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.bestScroe = bestScore;
        //data.name = name;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);


    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScore = data.bestScroe;
            //data.name = name;
        }
    }
    
}
