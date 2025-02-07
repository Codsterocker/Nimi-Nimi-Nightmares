using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public TextMeshProUGUI timerText;       // text UI to modify
    public TextMeshProUGUI timesUpText;     // text UI to display when timer hits 0
    private float remainingSeconds;         // seconds left on the timer

    public GameObject[] playersUI = new GameObject[4];
    public TextMeshProUGUI[] playersScoreText = new TextMeshProUGUI[4];

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        remainingSeconds = MatchData.instance.GetRoundDuration();
        PlayerManager.instance.ResetAllScores();
    }

    // Update is called once per frame
    void Update()
    {
        HandleTimer();
        HandlePlayerScores();
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

    private void HandlePlayerScores()
    {
        for (int i = 0; i < MatchData.instance.GetNumPlayers(); i++)
        {
            playersScoreText[i].text = string.Format("{0:0}", PlayerManager.instance.players[i].GetScore());
        }
    }


    // End round once the timer hits 0
    void TimesUp()
    {
        timesUpText.gameObject.SetActive(true);
        // TODO: Send global announce for Time's Up
    }
}
