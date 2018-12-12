using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI currentTimerText, leadTimerText, finalCurrentTime, finalLeadTimerText;
    float gameTimer = 0f, leadGameTimer = 0f;

    // Use this for initialization
    void Start()
    {
        //currentTimerText.text = "Current Time :: ";
        //leadTimerText.text = "Best Time :: ";
        //PlayerPrefs.DeleteAll();

        if (!PlayerPrefs.HasKey("LeadGameTimerValue"))
        {
            PlayerPrefs.SetFloat("LeadGameTimerValue", 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.instance.gameStarted == true && PlayerController.instance.gameOver == false)
        {
            gameTimer += Time.deltaTime;
        }

        calculateTimerCountdown(gameTimer, currentTimerText);

        if (gameTimer > PlayerPrefs.GetFloat("LeadGameTimerValue"))
        {
            PlayerPrefs.SetFloat("LeadGameTimerValue", gameTimer);
        }
        leadGameTimer = PlayerPrefs.GetFloat("LeadGameTimerValue");
        calculateTimerCountdown(leadGameTimer, leadTimerText);

        if (PlayerController.instance.gameStarted && PlayerController.instance.gameOver == true)
        {
            calculateTimerCountdown(gameTimer, finalCurrentTime);
            calculateTimerCountdown(leadGameTimer, finalLeadTimerText);
        }
    }

    void calculateTimerCountdown(float GetTimer, TextMeshProUGUI printText)
    {
        int seconds = (int)(GetTimer % 60);
        int minutes = (int)(GetTimer / 60) % 60;
        int hours = (int)(GetTimer / 3600);

        string calculateTimer = string.Format("{00:00} : {01:00} : {02:00}", hours, minutes, seconds);
        printText.text = calculateTimer;
    }

    //void FinalScore()
    //{
    //    int seconds = (int)(GetTimer % 60);
    //    int minutes = (int)(GetTimer / 60) % 60;
    //    int hours = (int)(GetTimer / 3600);
    //}
}
