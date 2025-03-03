﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;


    public AudioSource backgroundAudio;


    void Start()
    {
        pauseMenuUI.SetActive(false);
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
   public  void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        backgroundAudio.Play();
        GameIsPaused = false;

    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        backgroundAudio.Pause();
       GameIsPaused = true;
    }

    public void mainMenu()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        backgroundAudio.Play();
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

}
