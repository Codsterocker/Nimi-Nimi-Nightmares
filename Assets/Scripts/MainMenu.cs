using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject pressToPlayPanel;
    public GameObject mainMenuPanel;

    public GameObject pressToPlayFirstSelected;
    public GameObject mainMenuFirstSelected;

    private GameObject firstSelectedGameObject;

    private void Start()
    {
        ShowPressToPlayPanel();
    }

    void Update()
    {
        // Ensure that the controller is being used
        if (Input.GetJoystickNames().Length > 0 || Input.GetKey(KeyCode.JoystickButton0))
        {
            // Force EventSystem to focus on the controller-selected object
            if (EventSystem.current.currentSelectedGameObject == null)
            {
                EventSystem.current.SetSelectedGameObject(firstSelectedGameObject);
            }
        }
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

    public void ShowSettingsPanel()
    {
        Debug.Log("Show Settings Hit");
    }

    public void ShowPressToPlayPanel()
    {
        // Set the active panel
        pressToPlayPanel.SetActive(true);
        mainMenuPanel.SetActive(false);

        // Set the first menu option to be selected
        firstSelectedGameObject = pressToPlayFirstSelected;
        EventSystem.current.SetSelectedGameObject(firstSelectedGameObject);
    }

    public void ShowMainMenu()
    {
        // Set the active panel
        pressToPlayPanel.SetActive(false);
        mainMenuPanel.SetActive(true);

        // Set the first menu option to be selected
        firstSelectedGameObject = mainMenuFirstSelected;
        EventSystem.current.SetSelectedGameObject(firstSelectedGameObject);
    }
}
