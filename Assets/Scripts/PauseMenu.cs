using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class PauseMenu : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject gameManager;
    public GameObject pauseMenu;
    
    public GameObject ResumeButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Pause") && gameManager.GetComponent<GameManager>().isGameStart == true && gameManager.GetComponent<GameManager>().isGameOver == false){
            
            if(isPaused){
                Resume();
            }
            else{
                Pause();
            }

        }
    }

    public void Resume(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(ResumeButton);
    }
    public void Quit(){
        Application.Quit();
    }
}
