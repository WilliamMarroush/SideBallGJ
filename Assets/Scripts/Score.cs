using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    }

    // Update is called once per frame
    void Update()
    {
        playerScoreText.text = gameSession.GetPlayerScore().ToString();
        redEnemyScoreText.text = gameSession.GetRedEnemyScore().ToString();
        blueEnemyScoreText.text = gameSession.GetBlueEnemyScore().ToString();
    }
}
