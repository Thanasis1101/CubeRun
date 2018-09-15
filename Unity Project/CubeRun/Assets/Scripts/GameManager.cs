using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public bool gameOver = false;
    public float restartLevelDelay = 2f;
    public Color32 gameOverColor = new Color32(249, 92, 64, 1);
    public GameObject fadeOutPanel;
    public GameObject fadeInPanel;
    public GameObject youWonPanel;
    public Text level;
    public Text score;
    public bool paused;
    

    public void Start()
    {
        fadeInPanel.SetActive(true);
        level.text = "Level " + SceneManager.GetActiveScene().buildIndex;
    }

    public void Update()
    {

        // Pause

        if (Input.GetKeyDown("p"))
        {
            if (Time.timeScale != 0)
            {
                paused = true;
                Time.timeScale = 0; // pause game
                GetComponent<AudioSource>().Pause(); // pause music
            }
            else
            {
                paused = false;
                Time.timeScale = 1; // unpause
                GetComponent<AudioSource>().Play(); // unpause music
            }
        }

    }


    public void CompleteLevel()
    {
        if (!gameOver)
        {
            score.text = "500";
            gameOver = true;
            youWonPanel.SetActive(true);
            FindObjectOfType<PlayerMovement>().enabled = false; // stop movement of player
            Invoke("NextLevel", restartLevelDelay);
        }
    }

    public void EndGame()
    {
        if (!gameOver)
        {
            gameOver = true;
            FindObjectOfType<PlayerMovement>().enabled = false; // stop movement of player
            FindObjectOfType<Camera>().backgroundColor = gameOverColor; // turn background to red
            RenderSettings.fogColor = gameOverColor; // turn fog to red
            Invoke("Restart", restartLevelDelay);
        }
        
    }

    public void Restart()
    {
        fadeOutPanel.SetActive(true);
        Invoke("ReloadScreen", 1);
    }

    private void ReloadScreen()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        fadeOutPanel.SetActive(true);
        Invoke("LoadNextScreen", 1);
    }

    private void LoadNextScreen()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
