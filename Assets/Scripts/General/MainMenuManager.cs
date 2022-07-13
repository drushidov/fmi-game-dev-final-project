using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public SceneAsset arenaScene;
    public GameObject mainMenu;
    public GameObject optionsMenu;

    public void OpenOptionsMenu()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void CloseOptionsMenu()
    {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void DeleteSavedGameData()
    {
        SaveSystem.ClearPlayerData();
    }

    public void LoadArenaScene()
    {
        SceneManager.LoadScene(arenaScene.name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
