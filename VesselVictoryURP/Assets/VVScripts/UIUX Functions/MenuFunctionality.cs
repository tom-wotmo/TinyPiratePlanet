using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuFunctionality : MonoBehaviour
{
    public static MenuFunctionality Instance { get; private set; }

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject settingsMenuCanvas;
    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private GameObject leaderboardCanvas;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject activeGameUI;

    [SerializeField] private AudioClip clickSound;

    bool isAlive = true;
    bool isPaused = false;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    private void Update()
    {
        PressEscapeToPause();
    }
    public void RestartGame()
    { 
        isAlive = true;
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
    public void EndGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex - 1);
        ScoreHandler.Instance.UpdateHighScore();
        Time.timeScale = 1f;
    }
    public void StartGame()
    {
        isAlive = true;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        Time.timeScale = 1f;
    }
    public void LoadSettingsMenuCanvas()
    {
        settingsMenuCanvas.SetActive(true);
        mainMenuCanvas.SetActive(false);
    }
    public void LoadMainMenuCanvas()
    {
        settingsMenuCanvas.SetActive(false);
        leaderboardCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);
    }
    public void LoadLeaderboardCanvas()
    {
        leaderboardCanvas.SetActive(true);
        mainMenuCanvas.SetActive(false);
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
    public void PressEscapeToPause()
    {
       
        if (isAlive)
        {
            if (!isPaused && Input.GetKeyDown(KeyCode.Escape))
            {
                AudioManager.Instance.PlayOneShotSound(clickSound, 1f);
                PauseGame();
            }
            else if (isPaused && Input.GetKeyDown(KeyCode.Escape))
            {
                AudioManager.Instance.PlayOneShotSound(clickSound, 1f);
                ResumeGame();
            }
        } 
       
    }
    public void OpenPauseMenu()
    {
        PauseGame();
        pauseMenu.SetActive(true);
    }
    public void GameOverScreen() 
    {
        isAlive = false;
        Time.timeScale = 0f;
        gameOverScreen.SetActive(true);
       
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

