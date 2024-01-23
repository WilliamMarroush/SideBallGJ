using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    [SerializeField] public float timeLeft;
    public bool timerOn = false;

    [SerializeField] public Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        timerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerOn)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                UpdateTimerText(timeLeft);
            }

            else
            {
                Debug.Log("Time's up");
                timeLeft = 0;
                timerOn = false;
                FindObjectOfType<LevelLoader>().LoadHighScoreScene();
            }
        }
    }


    void UpdateTimerText(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = minutes.ToString() + ":" + seconds.ToString(); //string.Format("{0:00} : {1:00}", minutes, seconds);
    }


}
