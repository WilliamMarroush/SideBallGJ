using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    //adds fields in the inspector so that it knows what text to update.  
    [SerializeField] public static int playerScore = 0;
    [SerializeField] public static int blueEnemyScore = 0;
    [SerializeField] public static int redEnemyScore = 0;

    private void Awake()
    {
        SetUpSingleton();
    }


    //there can only be one game seesion going at a time.  this destroys others that get created.  
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

    //ensures that scores to do nopt carry over to the next game
    public void ResetGame()
    {
        playerScore = 0;
        redEnemyScore = 0;
        blueEnemyScore = 0;
        Destroy(this.gameObject);
    }
}
