using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{

    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */

    public static DataManager Instance;

    public string playerName;
    public int highScore;
    public string oldPlayerName;

    private string path; //= Application.persistentDataPath + "/savefile.json";

    private void Awake()
    {
        path = Application.persistentDataPath + "/savefile.json";

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
        public string playerName;
        public int highScore;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(path, json);
    }

    public void LoadScore()
    {
        //string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
            highScore = data.highScore;
            oldPlayerName = playerName;
        }
        
    }
}
