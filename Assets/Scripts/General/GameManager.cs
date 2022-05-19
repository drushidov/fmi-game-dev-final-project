using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public SceneAsset arenaScene;
    public SceneAsset mainMenuScene;

    public void ResetGame()
    {
        SceneManager.LoadScene(arenaScene.name);
    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene(mainMenuScene.name);
    }
}
