using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Scriptable Objects/MatchData", menuName = "Scriptable Objects/MatchData")]
public class MatchData : ScriptableSingleton<MatchData>
{
    private float roundDuration = 60f;  // seconds per round
    private int numPlayers = 1;         // number of players to spawn / draw UI
    private int playerScore = 0;        // player's score

    public void SetRoundDuration(float roundDuration)
    {
        this.roundDuration = roundDuration;
    }

    public float GetRoundDuration()
    {
        return roundDuration;
    }

    public void SetNumPlayers(int numPlayers)
    {
        this.numPlayers = numPlayers;
    }

    public int GetNumPlayers()
    {
        return numPlayers;
    }

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
