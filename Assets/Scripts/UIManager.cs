using UnityEngine;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    public MatchData matchData;             // obtain data of match, will be used for seconds on timer

    public TextMeshProUGUI timerText;       // text UI to modify
    public TextMeshProUGUI timesUpText;     // text UI to display when timer hits 0

    public GameObject player;               // A player who's score will be obtained
    public TextMeshProUGUI playerScoreText; // text UI to display player's score
    
    private float remainingSeconds;         // seconds left on the timer

    void Start()
    {
        remainingSeconds = matchData.roundDuration;
        matchData.ResetScore();
    }

    // Update is called once per frame
    void Update()
    {
        HandleTimer();
        HandlePlayerScore();
    }

    private void HandleTimer()
    {
        if (remainingSeconds > 0)
        {
            // subtract time from timer if time still remaining
            remainingSeconds -= Time.deltaTime;
        }
        else
        {
            // ensure timer remains displaying 0, proceed to end round
            remainingSeconds = 0;
            TimesUp();
        }

        int minutes = Mathf.FloorToInt(remainingSeconds / 60);
        int seconds = Mathf.FloorToInt(remainingSeconds % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void HandlePlayerScore()
    {
        playerScoreText.text = string.Format("P1 Score: {0:0}", matchData.GetScore());
    }


    // End round once the timer hits 0
    void TimesUp()
    {
        timesUpText.gameObject.SetActive(true);
        // TODO: Send global announce for Time's Up
    }
}
