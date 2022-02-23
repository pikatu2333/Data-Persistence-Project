using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DataPersistence : MonoBehaviour
{
    public int currentScore;
    public int bestScore;

    public string currentScoreName;
    public string bestScoreName;

    public static DataPersistence Instance;

    public MenuUI MenuUI;

  

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        DataPersistence.Instance.LoadBestScore();


    }



    [System.Serializable]
    class SaveData
    {
        public int bestScore;
        public string bestScoreName;

    }

    public void SaveBestScore()
    {
        SaveData data = new SaveData();
        data.bestScore = bestScore;
        data.bestScoreName = bestScoreName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path)) 
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScore = data.bestScore;

            bestScoreName = data.bestScoreName;
        }
    }

    public void ClearBestScore()
    {
        SaveData data = new SaveData();
        data.bestScore = 0;
        data.bestScoreName = "none";

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

}
