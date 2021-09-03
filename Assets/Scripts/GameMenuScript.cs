using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameMenuScript : MonoBehaviour
{
    //Declares all objects and variables
    public static bool isPaused = false;
    public GameObject pauseMenu;
    public GameObject pauseButtons;
    public GameObject optionButtons;

    public AudioSource BgAudio;

    public Toggle muteToggle;
    public Slider Volume;

    public Image xpBar;
    public Slider healthBar;
    public Slider staminaBar;

    int xp;
    //Variables able to be changed in Unity
    public int health = 10, stamina = 10;


    // Start is called before the first frame update
    void Start()
    {
        //Sets the active states for the pause menu
        pauseMenu.SetActive(false);
        pauseButtons.SetActive(true);
        optionButtons.SetActive(false);

        //sets the value of health and stamina bar to the variables
        healthBar.maxValue = health;
        staminaBar.maxValue = stamina;

    }

    // Update is called once per frame
    void Update()
    {
        //When Escape key is pressed the pause menu will appear and disappear
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        //When Space is presssd the values will change to show the health, stamina and XP bar are working
        if (Input.GetKey(KeyCode.Space))
        {
            xp++;
            health--;
            stamina--;
        }
        //Changes the values for unity to show all bars are working
        xpBar.fillAmount = (xp / 100.0f);
        healthBar.value = health;
        staminaBar.value = stamina;

        //check if toggle is enabled or disabled to mute audio
        if (muteToggle.isOn)
        {
            BgAudio.mute = true;
        }
        else
        {
            BgAudio.mute = false;
        }
    }

    //Will display pause menu and pause the game
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    //Pause menu will disappear and game will continue
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    //Game will return to main menu when the Quit button is pressed
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartScreen");
    }

    //Show the option buttons in the pause menu
    public void showOptions()
    {
        pauseButtons.SetActive(false);
        optionButtons.SetActive(true);
    }
    
    //will show the pause buttons in the pause menu
    public void showPause()
    {
        pauseButtons.SetActive(true);
        optionButtons.SetActive(false);
    }

    //changes the volume of the music, value is taken from the slider
    public void volumeSlider(float volume)
    {
        BgAudio.volume = volume;
    }
}
