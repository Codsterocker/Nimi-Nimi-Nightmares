using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Scriptable Objects/MatchData", menuName = "Scriptable Objects/MatchData")]
public class MatchData : ScriptableSingleton<MatchData>
{
    private float roundDuration = 60f;  // seconds per round
    private int numPlayers = 4;         // number of players to spawn / draw UI

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
}
