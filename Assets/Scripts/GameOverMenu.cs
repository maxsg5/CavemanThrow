using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;

public class GameOverMenu : MonoBehaviour
{

    
    public GameObject StartButton;
    public GameObject gameOverMenu;
    public GameObject GameManager;
    public Text scoreText;
    public Text highScoreText;
    private SavedData savedData;
    private string filePath = "Assets/savedData.json";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GetComponent<GameManager>().isGameOver)
        {
            ShowGameOverScreen();

        }


    }

    void ShowGameOverScreen()
    {
        //TODO: This is not properly implemented yet.
        savedData = JsonUtility.FromJson<SavedData>(File.ReadAllText(filePath));
        Debug.Log("HIGH SCORE!!!::::" + savedData.HighScore);
        gameOverMenu.SetActive(true);
        scoreText.text = "Score: " + GameManager.GetComponent<GameManager>().score.ToString();
        highScoreText.text = "High Score: " + savedData.HighScore.ToString();
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(StartButton);
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
