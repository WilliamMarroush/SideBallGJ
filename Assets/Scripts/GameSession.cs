using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{

    public static int playerScore = 0;
    public static int blueEnemyScore = 0;
    public static int redEnemyScore = 0;

    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {

            Debug.Log("GameSession has been destroyed");
            Destroy(gameObject);
        }

        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public int GetPlayerScore()
    {
        return playerScore;
    }

    public int GetRedEnemyScore()
    {
        return redEnemyScore;
    }

    public int GetBlueEnemyScore()
    {
        return blueEnemyScore;
    }



    public static void AddToScore(int scoreValue, int teamID)
    {
        if (teamID == 0)
        {
            playerScore += scoreValue;
            Debug.Log(playerScore);

        }

        else if (teamID == 1)
        {
            redEnemyScore += scoreValue;
            Debug.Log(redEnemyScore);
        }

        else if (teamID == 2)
        {
            blueEnemyScore += scoreValue;
            Debug.Log(blueEnemyScore);
        }
    }

    public void ResetGame()
    {
        playerScore = 0;
        redEnemyScore = 0;
        blueEnemyScore = 0;
        Destroy(this.gameObject);
    }
}
