using UnityEngine;

[CreateAssetMenu(fileName = "MatchData", menuName = "Scriptable Objects/MatchData")]
public class MatchData : ScriptableObject
{
    public float roundDuration = 60f;     // seconds per round
}
