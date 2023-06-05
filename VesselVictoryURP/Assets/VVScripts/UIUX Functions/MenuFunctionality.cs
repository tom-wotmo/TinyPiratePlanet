using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuFunctionality : MonoBehaviour
{
    public static MenuFunctionality Instance { get; private set; }

    [SerializeField] private GameObject pauseMenu;
    
    bool isPaused = false;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        PressPToPause();
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void EndGame()
    {
        SceneManager.LoadScene(SceneManager.GetSceneAt(1).buildIndex);
        ScoreHandler.Instance.SaveScore();
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
    }
    public void PressPToPause()
    {
        if (!isPaused && Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }
        else if (isPaused && Input.GetKeyDown(KeyCode.P))
        {
            ResumeGame(); 
        }
    }
    public void OpenPauseMenu()
    {
        PauseGame();
        pauseMenu.SetActive(true);
    }
    public void ClosePauseMenu()
    {
        pauseMenu.SetActive(false);
    }
    public void ExitApplication()
    {
        Application.Quit();
    }
}

