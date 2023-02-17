using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class MenuUIHandler : MonoBehaviour
{

    public GameObject playerName;
    public Text highScoreText;


    // Start is called before the first frame update
    void Start()
    {
        DataManager.Instance.LoadScore();
        if( DataManager.Instance.playerName != null && DataManager.Instance.highScore > 0)
        {
            playerName.GetComponent<InputField>().text = DataManager.Instance.playerName;
            highScoreText.GetComponent<Text>().text = $"Best Score: {DataManager.Instance.playerName}: {DataManager.Instance.highScore}";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    

    public void StartNew()
    {
        if(playerName.GetComponent<InputField>().text != null)
        {
            DataManager.Instance.playerName = playerName.GetComponent<InputField>().text;
        }
        
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); //original code to quit Unity
#endif
    }
}
