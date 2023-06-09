using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreHandler : MonoBehaviour
{
    public static ScoreHandler Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI scoreUITMP;
    [SerializeField] private TextMeshProUGUI highScoreUITMP;

    private const int DEFAULT_START_PLAYER_SCORE = 0;
    private int playerScore;
    private int highScore;

    private void Awake()
    {
        if (Instance == null)
        { Instance = this; }
        else
        { Destroy(gameObject); }
    }
    private void Start()
    {
        playerScore = DEFAULT_START_PLAYER_SCORE;
        highScore = PlayerPrefs.GetInt("PLAYER_HIGH_SCORE", 0);
        
    }
    private void Update()
    {
        scoreUITMP.text = playerScore.ToString();
        highScoreUITMP.text = highScore.ToString();
        scoreAchievement();
    }

    public void UpdateHighScore()
    {
        if(playerScore > highScore)
        {
            SaveScore();
        }
    }
    private void SaveScore()
    {
        PlayerPrefs.SetInt("PLAYER_HIGH_SCORE", playerScore);
        PlayerPrefs.Save();
    }
    private void scoreAchievement() 
    {
        switch (playerScore)
        {
            case 5:
                Debug.Log("Achieved 50 high score");
                break;
            case 10:
                Debug.Log("Achieved 100 high score");
                break;
            case 25:
                Debug.Log("Achieve  250 high score");
                break;
            case 50:
                Debug.Log("Achieved 500 high score");
                break;
            case 100:
                Debug.Log("Achieved 1000 high score");
                break;
        }
    } //expand, debug logs are there for clean sake at the moment
    public void setPlayerScore(int i) { playerScore = i; }
    public int getPlayerScore() { return playerScore; }


}
