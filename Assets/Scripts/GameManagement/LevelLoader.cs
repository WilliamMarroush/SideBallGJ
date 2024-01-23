using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{

    int currentSceneIndex;
    public AudioSource gamestart;
    public AudioSource gameend;

    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        gamestart = GetComponent<AudioSource>();
        gameend = GetComponent<AudioSource>();

    }



    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }


    public void LoadGameCurrent()
    {
        FindObjectOfType<GameSession>().ResetGame();
        SceneManager.LoadScene("Game_Scene"); 
    }


    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    public void LoadHighScoreScene()
    {
        SceneManager.LoadScene("High_Score_Scene");

    }




    public void QuitGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
