using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;       // text UI to modify
    public TextMeshProUGUI timesUpText;     // text UI to display when timer hits 0

    public TextMeshProUGUI playerScoreText; // text UI to display player's score

    public GameObject[] players = new GameObject[4];
    public GameObject[] playersUI = new GameObject[4];
    public int[] playersScore = new int[4];
    public TextMeshProUGUI[] playersScoreText = new TextMeshProUGUI[4];

    private float remainingSeconds;         // seconds left on the timer

    void Start()
    {
        remainingSeconds = MatchData.instance.GetRoundDuration();
        MatchData.instance.ResetScore();
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
        playerScoreText.text = string.Format("P1 Score: {0:0}", MatchData.instance.GetScore());
    }


    // End round once the timer hits 0
    void TimesUp()
    {
        timesUpText.gameObject.SetActive(true);
        // TODO: Send global announce for Time's Up
    }
}
