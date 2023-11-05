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

    //admin objects
    public TMP_InputField enterPassword;


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
        //some sort of password check here
        /* if passord = storedpassword then 
        SettingsMenu.SetActive(false);
        AdminMenu.SetActive(true);

        else error message.setactive(true)
        */
    }

    public void changeToPassword()
    {
        SettingsMenu.SetActive(false);
        AdminPassword.SetActive(true);
    }

}
