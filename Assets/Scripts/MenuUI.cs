using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public TMP_InputField userNameInput;

    public TextMeshProUGUI bestScoreDisplay;



    public void ClickStartButton()
    {
        
        SceneManager.LoadScene(1);
    }

    public void ClickQuitButton()
    {
        DataPersistence.Instance.SaveBestScore();
        EditorApplication.ExitPlaymode();
    }

    private void Start()
    {

        bestScoreDisplay.text = $"Best Score: {DataPersistence.Instance.bestScore} Name: {DataPersistence.Instance.bestScoreName}";
    }

    private void Update()
    {

        DataPersistence.Instance.currentScoreName = userNameInput.text;
    }


    public void ClearHistory()
    {
        DataPersistence.Instance.ClearBestScore();
        DataPersistence.Instance.LoadBestScore();
        print(DataPersistence.Instance.bestScore);
    }
}
