using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public bool isGameStart = false;
    public bool isGameOver = false;
    public bool startCountDown = false;
    public float countDownTime = 5f;
    public float timeRemaining = 60f;
    public Text scoreText;
    public Text timerText;
    public Text highScoreText;
    public Text countDownTimer;
    
    //public GameObject restartButton;
    public AudioClip hitSound;
    private AudioSource audioSource;
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        countDownTimer.enabled = true;
        startCountDown = true;
        // uncomment to reset high score.
        //PlayerPrefs.SetInt("highScore", score);
        //PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("Score", score);
        highScoreText.text = "HighScore: " + PlayerPrefs.GetInt("highScore");
        timerText.text = "Time: " + timeRemaining.ToString("0");
        scoreText.text = "Score: " + score.ToString();
        

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (startCountDown)
        {
            countDownTime -= Time.deltaTime;
            countDownTimer.text = $"Get ready "+ countDownTime.ToString("0");
            if (countDownTime <= 0)
            {
                countDownTimer.enabled = false;
                startCountDown = false;
                isGameStart = true;
            }
        }
        
        // if game is not started, then do nothing
        if (isGameStart || isGameOver)
        {
            // if game is not over, then update the timer
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimer();
                

            }
            else
            {
                // if time is up, then game is over
                isGameOver = true;
                SceneManager.LoadScene("GameOverScreen");
                

            }
        }
    }

    void UpdateTimer()
    {
        timerText.text = "Time: " + timeRemaining.ToString("0");
    }
    public void AddScore(int s)
    {
        audioSource.PlayOneShot(hitSound);
        score += s;
        // Add score to the player
        scoreText.text = "Score: " + score.ToString();
        if (score > PlayerPrefs.GetInt("highScore"))
        {
            PlayerPrefs.SetInt("highScore", score);
        }
        highScoreText.text = "HighScore: " + PlayerPrefs.GetInt("highScore");
    }

    

    
}
