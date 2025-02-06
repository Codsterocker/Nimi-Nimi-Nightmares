using UnityEngine;

[CreateAssetMenu(fileName = "MatchData", menuName = "Scriptable Objects/MatchData")]
public class MatchData : ScriptableObject
{
    public float roundDuration = 60f;     // seconds per round

    private int playerScore = 0; // player's score

    public void AddScore()
    {
        playerScore++;
    }

    public int GetScore()
    {
        return playerScore;
    }

    public void ResetScore()
    {
        playerScore = 0;
    }
}
