using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class MainMenuScript : MonoBehaviour
{
    //panels
    public GameObject MainMenuPanel;
    public GameObject HowtoPlay;
    public GameObject SettingsMenu;
    public GameObject AdminMenu;
    public GameObject AdminPassword;
    public GameObject KeyboardCanvas;

    //admin objects
    public TMP_InputField enterPassword;

    //admin password
    public Text errorMessageText;

    private string adminPassword = "carter12";

    // Start is called before the first frame update
    void Start()
    {
        MainMenuPanel.SetActive(true);
        HowtoPlay.SetActive(false);
        SettingsMenu.SetActive(false);
        AdminMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void changeToAdmin()
    {
        string enteredPassword = enterPassword.text;
        KeyboardCanvas.SetActive(false);

        if (enteredPassword == adminPassword)
        {
            MainMenuPanel.SetActive(false);
            AdminPassword.SetActive(false);
            AdminMenu.SetActive(true);
        }
        else
        {
            // Display an error message.
            errorMessageText.text = "Invalid password. Please try again.";
        }
    }

    public void changeToPassword()
    {
        MainMenuPanel.SetActive(false);
        AdminPassword.SetActive(true);
    }

    public void ResetLeaderboard()
    {
        PlayerPrefs.SetInt("ResetLeaderboard", 1);
    }

    public void QuitGame()
    {
        // Call this function to quit the application when a quit button is pressed.
        Application.Quit();
    }
    public void closeToMenu()
    {
        HowtoPlay.SetActive(false);
        SettingsMenu.SetActive(false);
        AdminMenu.SetActive(false);
        KeyboardCanvas.SetActive(false);
        AdminPassword.SetActive(false);

    }


}
