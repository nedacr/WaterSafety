using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    Color deepOrange = new Color(1.0f, .325f, 0.0f, 1.0f);
    Color orange = new Color(1.0f, .639f, 0.0f, 1.0f);
    Color brightOrange = new Color(1.0f, .775f, .11f, 1.0f);
    float AFKpop = 60;
    [SerializeField] float MainTimer;
    [SerializeField] float AFKTimer;
    public Text Timer;
    public Text TimerShade;
    public Text AFKTimerText;
    public Text AFKTimerText2;

    public GameObject TimerPanel;
    public GameObject MainMenu;
    public GameObject Game;
    public GameObject DocksZoom;
    public GameObject BeachZoom;
    public GameObject LakeZoom;
    public GameObject QuestionPanel;
    public GameObject ResponsePanel;
    public GameObject DocksFinished;
    public GameObject BeachFinished;
    public GameObject LakeFinished;
    public GameObject SummaryScene;
    public GameObject AFKWarning;

    // Start is called before the first frame update
    void Start()
    {
        MainTimer = 6000;
        AFKTimer = 6000;
        AFKTimerText2.color = Color.black;
        if (AFKTimer > 60)
        {
            AFKTimerText.color = Color.white;
            AFKWarning.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        MainTimer -= Time.deltaTime;
        AFKTimer -= Time.deltaTime;
        DisplayMainTimer(MainTimer);
        DisplayAFKTimer(AFKTimer);
        if (AFKTimer <= AFKpop)
        {
            AFKWarning.SetActive(true);
            ChangeAFK(AFKpop);
        }
        else
        {
            AFKWarning.SetActive(false);
        }

        if (MainTimer <= 0)
        {
            TimeUp();
        }
        if (AFKTimer <= 0)
        {
            //sends game to Main Menu
            SceneManager.LoadScene(0);
        }
        if (MainTimer <= (MainTimer * 2) / 3)
        {
            ChangeMainColor();
        }
    }

    private void ChangeMainColor()
    {
        if (MainTimer <= 60)
        {
            Timer.color = Color.red;
        }
        else if (MainTimer <= MainTimer / 3)
        {
            Timer.color = orange;
        }
        else if (MainTimer <= (MainTimer * 2) / 3)
        {
            Timer.color = Color.yellow;
        }
    }

    public void TimeUp()
    {
        Game.SetActive(false);
        DocksZoom.SetActive(false);
        BeachZoom.SetActive(false);
        LakeZoom.SetActive(false);
        QuestionPanel.SetActive(false);
        ResponsePanel.SetActive(false);
        DocksFinished.SetActive(false);
        BeachFinished.SetActive(false);
        LakeFinished.SetActive(false);
        TimerPanel.SetActive(false);
        SummaryScene.SetActive(true);
    }

    private void ChangeAFK(float afkPop)
    {
        if (AFKpop < 10)
        {
            AFKTimerText.color = Color.red;
        }
        else if (AFKpop <= AFKpop / 3)
        {
            AFKTimerText.color = orange;
        }
        else if (AFKpop <= (AFKpop * 2) / 3)
        {
            AFKTimerText.color = Color.yellow;
        }
    }

    void DisplayMainTimer(float TimeDisplayed)
    {
        if (TimeDisplayed <= 0)
        {
            TimeDisplayed = 0;
        }
        else if (TimeDisplayed > 0)
        {
            TimeDisplayed += 1;
        }

        float minutes = Mathf.FloorToInt(TimeDisplayed / 60);
        float seconds = Mathf.FloorToInt(TimeDisplayed % 60);

        Timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        TimerShade.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void DisplayAFKTimer(float TimeDisplayed)
    {
        if (TimeDisplayed <= 0)
        {
            TimeDisplayed = 0;
        }
        else if (TimeDisplayed > 0)
        {
            TimeDisplayed += 1;
        }

        float minutes = Mathf.FloorToInt(TimeDisplayed / 60);
        float seconds = Mathf.FloorToInt(TimeDisplayed % 60);

        AFKTimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        AFKTimerText2.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void ResetAFKTimer()
    {
        AFKTimer = 180;
    }

    public float getTimer()
    {
        return MainTimer;
    }

    
}
