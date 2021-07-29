using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + PlayerPrefs.GetInt("Score").ToString();
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("highScore").ToString();
    }

     public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void BackToMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
