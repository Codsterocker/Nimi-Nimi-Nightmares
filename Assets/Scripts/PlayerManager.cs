using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    public Player[] players = new Player[4];

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        PlayerSetup(MatchData.instance.GetNumPlayers());
    }

    public void PlayerSetup(int numPlayers)
    {
        for (int i = 0; i < players.Length; i++)
        {
            if (i < numPlayers)
            {
                ;
            }
            else
            {
                players[i].DisableAll();
            }
        }
    }

    public void AddScoreToPlayer(int player)
    {
        players[player].AddScore();
    }

    // Reset all player's scores back to 0
    public void ResetAllScores()
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i].ResetScore();
        }
    }
}
