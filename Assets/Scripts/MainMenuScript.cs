using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    //Opens game when the start button is pressed
    public void OpenLevel()
    {
        SceneManager.LoadScene("Game");
    }

    //Quit the game when the Quit button is pressed
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
