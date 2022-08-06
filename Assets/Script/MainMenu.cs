using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Canvas instructionsCanvas;
    public Canvas menuCanvas;
    void Start()
    {
        instructionsCanvas.enabled = false;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Match");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void showInstructions()
    {
        menuCanvas.enabled = false;
        instructionsCanvas.enabled = true;
    }
    public void hideInstructions()
    {
        menuCanvas.enabled = true;
        instructionsCanvas.enabled = false;
    }
    public void showMenu()
    {
        menuCanvas.enabled = true;
        //gameState = GameStates.menu;
        hideInstructions();
    }
}
