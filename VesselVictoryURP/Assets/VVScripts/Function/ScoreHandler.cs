using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    private const float DEFAULT_START_PLAYER_SCORE = 0;
    private float playerScore;

    private void Start()
    {
        playerScore = DEFAULT_START_PLAYER_SCORE;
    }
    private void Update()
    {
        scoreAchievement();
    }
    private void scoreAchievement() 
    {
        switch (playerScore)
        {
            case 50:
                Debug.Log("Achieved 50 high score");
                break;
            case 100:
                Debug.Log("Achieved 100 high score");
                break;
            case 250:
                Debug.Log("Achieve  250 high score");
                break;
            case 500:
                Debug.Log("Achieved 500 high score");
                break;
            case 1000:
                Debug.Log("Achieved 1000 high score");
                break;
        }
    } //expand, debug logs are there for clean sake at the moment
    public void setPlayerScore(float i) { playerScore = i; }
    public float getPlayerScore() { return playerScore; }


}
