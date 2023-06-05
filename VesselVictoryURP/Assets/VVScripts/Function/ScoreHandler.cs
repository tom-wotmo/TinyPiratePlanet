using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
    public static ScoreHandler Instance { get; private set; }
    [SerializeField] private Text scoreUItext;

    private const int DEFAULT_START_PLAYER_SCORE = 0;
    private int playerScore;
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
    }
    private void Update()
    {
        scoreUItext.text = playerScore.ToString();
        scoreAchievement();
    }
    public void SaveScore()
    {
        PlayerPrefs.SetFloat("Score", playerScore);
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
