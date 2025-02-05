using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject pressToPlayPanel;
    public GameObject mainMenuPanel;

    public GameObject pressToPlayFirstSelected;
    public GameObject mainMenuFirstSelected;

    private GameObject firstSelectedGameObject;
    private GameObject lastSelectedGameObject;

    private void Start()
    {
        ShowPressToPlayPanel();
    }

    private void Update()
    {
        HandleMenuNavigation();
    }

    // if the UI is clicked off, set the game object back to the previous option
    private void HandleMenuNavigation()
    {
        //if (EventSystem.current.currentSelectedGameObject == null)
        if (InputSystem.actions.FindAction("Move").WasPressedThisFrame())
        {
            EventSystem.current.SetSelectedGameObject(lastSelectedGameObject);
        }
        else
        {
            lastSelectedGameObject = EventSystem.current.currentSelectedGameObject;
        }
    }

    private void ShowMouseCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void HideMouseCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }
        
    // Switch the scene to the Game scene
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Game");
    }

    // Close the application
    public void QuitGame()
    {
        Application.Quit();

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    // Show the settings panel within the main menu
    public void ShowSettingsPanel()
    {
        Debug.Log("Show Settings Hit");
    }

    // Show the Press To Play panel before the main menu
    public void ShowPressToPlayPanel()
    {
        // Set the active panel
        pressToPlayPanel.SetActive(true);
        mainMenuPanel.SetActive(false);

        // Set the first menu option to be selected
        firstSelectedGameObject = pressToPlayFirstSelected;
        EventSystem.current.SetSelectedGameObject(firstSelectedGameObject);
    }

    // Show the Main Menu panel
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
