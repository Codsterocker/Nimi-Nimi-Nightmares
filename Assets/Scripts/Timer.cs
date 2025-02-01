using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;   // text UI to modify
    public TextMeshProUGUI timesUpText; // text UI to display when timer hits 0
    public MatchData matchData;         // obtain data of match, will be used for seconds on timer

    private float remainingSeconds;     // seconds left on the timer

    void Start()
    {
        remainingSeconds = matchData.roundDuration;
    }

    // Update is called once per frame
    void Update()
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

    // End round once the timer hits 0
    void TimesUp()
    {
        timesUpText.gameObject.SetActive(true);
    }
}
