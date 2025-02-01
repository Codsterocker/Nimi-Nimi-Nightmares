using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject PressToPlayPanel;
    public GameObject MainMenuPanel;

    private void Start()
    {
        ShowPressToPlayPanel();
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Game");
    }

    public void QuitGame()
    {
        Application.Quit();

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void ShowPressToPlayPanel()
    {
        PressToPlayPanel.SetActive(true);
        MainMenuPanel.SetActive(false);
    }

    public void ShowMainMenu()
    {
        PressToPlayPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }
}
