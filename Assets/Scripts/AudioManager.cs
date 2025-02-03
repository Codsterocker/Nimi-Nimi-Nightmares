using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource audioSource;     // yup
    public AudioClip gameplayBGM;       // BGM that will play during gameplay
    public AudioClip pauseBGM;          // BGM that will play in the Pause menu

    private float clipTimePosition;     // Stores the position in the BGM to start from after unpausing

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        // Initially play the normal BGM
        audioSource.clip = gameplayBGM;
        audioSource.Play();
    }

    public void PauseAudio()
    {
        // If paused, change to the pause BGM
        if (audioSource.clip != pauseBGM)
        {
            clipTimePosition = audioSource.time; // save the position of the gameplay BGM
            audioSource.clip = pauseBGM;
            audioSource.Play();
        }
        else
        {
            // If not paused, return to the gameplay BGM
            if (audioSource.clip != gameplayBGM)
            {
                audioSource.clip = gameplayBGM;
                audioSource.time = clipTimePosition; // save the position of the gameplay BGM
                audioSource.Play();
            }
        }
    }
}
