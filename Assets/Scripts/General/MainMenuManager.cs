using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public SceneAsset arenaScene;

    public void LoadArenaScene()
    {
        SceneManager.LoadScene(arenaScene.name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
