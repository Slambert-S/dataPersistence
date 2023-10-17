using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine;

public class PercictenceManager : MonoBehaviour
{

    public static PercictenceManager Instance;
    public int bestScore;
    public string BestScoreName;
    public string playerName;
    public Text BestScoreText;
    public string input;

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
        updateScore();

    }

    private void Start()
    {
        updateScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string BestScoreName;
        public int bestScroe;
    }


    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.bestScroe = bestScore;
        data.BestScoreName = BestScoreName;

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
            BestScoreName = data.BestScoreName;
        }
    }

    public void ReadStringInput(string s)
    {
        PercictenceManager.Instance.playerName = s;
        Debug.Log(playerName);
       // SaveScore();
    }

    private void updateScore()
    {
        if(PercictenceManager.Instance != null)
        {
            GameObject.Find("BestScoreText").GetComponent<Text>().text = "Best Score : " + PercictenceManager.Instance.bestScore + " by " + PercictenceManager.Instance.BestScoreName;
        }
    }
    
}
