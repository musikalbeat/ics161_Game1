using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public GameObject titleMenu;
    public GameObject stageMenu;

    private void Start()
    {
        titleMenu.SetActive(true);
        stageMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex+1) % SceneManager.sceneCountInBuildSettings);
    }

    public void openLevelMenu()
    {
        titleMenu.SetActive(false);
        stageMenu.SetActive(true);
    }

    public void closeLevelMenu() {
        titleMenu.SetActive(true);
        stageMenu.SetActive(false);
    }

    public void LevelSelect(int Level)
    {
        Debug.Log("Level Selected: " + Level);
        SceneManager.LoadScene( (SceneManager.GetActiveScene().buildIndex + Level) );
    }
}
