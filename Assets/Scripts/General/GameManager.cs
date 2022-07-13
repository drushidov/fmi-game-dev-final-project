using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public SceneAsset arenaScene;
    public SceneAsset mainMenuScene;
    public GameObject pauseMenuPanel;

    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        playerInputActions.Enable();
        playerInputActions.Player.PauseMenuTrigger.performed += OnPauseMenuTrigger;
    }

    private void OnDisable()
    {
        playerInputActions.Player.PauseMenuTrigger.performed -= OnPauseMenuTrigger;
        playerInputActions.Disable();
    }

    private void OnPauseMenuTrigger(InputAction.CallbackContext context)
    {
        pauseMenuPanel.SetActive(!pauseMenuPanel.activeSelf);
    }

    public void HidePauseMenu()
    {
        pauseMenuPanel.SetActive(false);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(arenaScene.name);
    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene(mainMenuScene.name);
    }
}
