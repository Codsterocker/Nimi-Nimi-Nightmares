using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject zone;         // the player controlled zone used to collect nightmares
    public GameObject pipe;         // the player-alligned pipe that will follow the player's zone
    // public GameObject character;    // the player-selected character that emotes and stuff

    private int score = 0;          // the player's total collected amount of nightmares

    public void DisableAll()
    {
        zone.SetActive(false);
        pipe.SetActive(false);
        // character.SetActive(false);
    }

    public void AddScore()
    {
        score++;
    }

    public int GetScore()
    {
        return score;
    }

    public void ResetScore()
    {
        score = 0;
    }
}
