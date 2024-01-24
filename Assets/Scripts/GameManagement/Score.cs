using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{

    public Text playerScoreText;
    public Text redEnemyScoreText;
    public Text blueEnemyScoreText;
    GameSession gameSession;
    // Start is called before the first frame update
    void Start()
    {
        //playerScoreText = GetComponent<Text>();
        //redEnemyScoreText = GetComponent<Text>();
        //blueEnemyScoreText = GetComponent<Text>();
        gameSession = FindObjectOfType<GameSession>();
        if (SceneManager.GetActiveScene().name=="End_Game"){
            getScores();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Game_Scene"){
            getScores();
        }
    }

    void getScores(){
        playerScoreText.text = gameSession.GetPlayerScore().ToString();
        redEnemyScoreText.text = gameSession.GetRedEnemyScore().ToString();
        blueEnemyScoreText.text = gameSession.GetBlueEnemyScore().ToString();
    }
}
