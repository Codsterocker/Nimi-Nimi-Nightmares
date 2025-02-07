using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    public GameObject pauseMenuPanel;   // Pause menu UI

    private bool isPaused = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        pauseMenuPanel.SetActive(false);
    }

    void Update()
    {
        // Check for pause input
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    // Toggle pause menu visibility
    public void TogglePauseMenu()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            // Pause the game
            Time.timeScale = 0;
            pauseMenuPanel.SetActive(true);
            AudioManager.instance.PauseAudio();
            // timerScript.PauseTimer();
        }
        else
        {
            // Resume the game
            Time.timeScale = 1;
            pauseMenuPanel.SetActive(false);
            AudioManager.instance.PauseAudio();
            // timerScript.ResumeTimer();
        }
    }

    // Called when the Continue button is clicked
    public void Continue()
    {
        TogglePauseMenu();
    }

    // Called when the Settings button is clicked
    public void Settings()
    {
        // Show settings menu
        Debug.Log("Settings clicked");
    }

    // Called when the Main Menu button is clicked
    public void MainMenu()
    {
        // Load the main menu scene
        Time.timeScale = 1; // Resume time before changing scenes
        SceneManager.LoadScene("Main Menu");
    }
}
