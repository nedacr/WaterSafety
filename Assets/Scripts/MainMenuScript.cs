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
    public GameObject StatsPanel;
    public GameObject ChooseStatsPanel;

    //admin objects
    public TMP_InputField enterPassword;

    //admin password
    public Text errorMessageText;

    //stats objects
    public TMP_Text Title;
    private const string CorrectKeyPrefix = "CorrectCount_";
    private const string WrongKeyPrefix = "WrongCount_";
    private const string QuestionPrefix = "Question_";
    private const string LocationPrefix = "Location_";

    //list of correct and wrong
    
    public Text[] sscenarioCorrectNumber;
    public Text[] sscenarioIncorrectNumber;
    public Text[] sscenarioQuestion;

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

    public void closeToStatsChoose()
    {
        StatsPanel.SetActive(false);
        ChooseStatsPanel.SetActive(true);
    }
    public void closeToAdmin()
    {
        AdminMenu.SetActive(true);
        ChooseStatsPanel.SetActive(false);
    }
    
    public void changeToChooseStats()
    {
        ChooseStatsPanel.SetActive(true);
        AdminMenu.SetActive(false);
    }

    public void LakeStats()
    {
        Title.text = "Lake";

        ChooseStatsPanel.SetActive(false);
        StatsPanel.SetActive(true);

        int targetLocation = 3; // The location you want to search for
        int counter = 0;

        for (int i = 1; i <= 20; i++) // Assuming you have 20 possible NPCs
        {
            string npcName = i.ToString(); // Convert the NPC number to a string
            string locationKey = LocationPrefix + npcName;

            if (PlayerPrefs.HasKey(locationKey) && PlayerPrefs.GetInt(locationKey) == targetLocation)
            {
                // Find and store other PlayerPrefs values with the same npcName
                string uniqueQuestion = PlayerPrefs.GetString(QuestionPrefix + npcName);
                int currentCorrectCount = PlayerPrefs.GetInt(CorrectKeyPrefix + npcName);
                int currentWrongCount = PlayerPrefs.GetInt(WrongKeyPrefix + npcName);

                if (counter <= 10)
                {
                    sscenarioQuestion[counter].text = uniqueQuestion;
                    sscenarioCorrectNumber[counter].text = currentCorrectCount.ToString();
                    sscenarioIncorrectNumber[counter].text = currentWrongCount.ToString();
                    counter++;
                }

            }
        }
        for(int k = counter; k <= 8; k++)
        {
            sscenarioQuestion[k].text = "";
            sscenarioCorrectNumber[k].text = "";
            sscenarioIncorrectNumber[k].text = "";
        }

    }

    public void BeachStats()
    {
        Title.text = "Beach";

        ChooseStatsPanel.SetActive(false);
        StatsPanel.SetActive(true);

        int targetLocation = 2; // The location you want to search for
        int counter = 0;

        for (int i = 1; i <= 20; i++) // Assuming you have 20 possible NPCs
        {
            string npcName = i.ToString(); // Convert the NPC number to a string
            string locationKey = LocationPrefix + npcName;

            if (PlayerPrefs.HasKey(locationKey) && PlayerPrefs.GetInt(locationKey) == targetLocation)
            {
                // Find and store other PlayerPrefs values with the same npcName
                string uniqueQuestion = PlayerPrefs.GetString(QuestionPrefix + npcName);
                int currentCorrectCount = PlayerPrefs.GetInt(CorrectKeyPrefix + npcName);
                int currentWrongCount = PlayerPrefs.GetInt(WrongKeyPrefix + npcName);

                if (counter <= 10)
                {
                    sscenarioQuestion[counter].text = uniqueQuestion;
                    sscenarioCorrectNumber[counter].text = currentCorrectCount.ToString();
                    sscenarioIncorrectNumber[counter].text = currentWrongCount.ToString();
                    counter++;
                }

            }
        }
        for (int k = counter; k <= 8; k++)
        {
            sscenarioQuestion[k].text = "";
            sscenarioCorrectNumber[k].text = "";
            sscenarioIncorrectNumber[k].text = "";
        }
    }

    public void DocksStats()
    {
        Title.text = "Docks";

        ChooseStatsPanel.SetActive(false);
        StatsPanel.SetActive(true);

        int targetLocation = 1; // The location you want to search for
        int counter = 0;

        for (int i = 1; i <= 20; i++) // Assuming you have 20 possible NPCs
        {
            string npcName = i.ToString(); // Convert the NPC number to a string
            string locationKey = LocationPrefix + npcName;

            if (PlayerPrefs.HasKey(locationKey) && PlayerPrefs.GetInt(locationKey) == targetLocation)
            {
                // Find and store other PlayerPrefs values with the same npcName
                string uniqueQuestion = PlayerPrefs.GetString(QuestionPrefix + npcName);
                int currentCorrectCount = PlayerPrefs.GetInt(CorrectKeyPrefix + npcName);
                int currentWrongCount = PlayerPrefs.GetInt(WrongKeyPrefix + npcName);

                if (counter <= 10)
                {
                    sscenarioQuestion[counter].text = uniqueQuestion;
                    sscenarioCorrectNumber[counter].text = currentCorrectCount.ToString();
                    sscenarioIncorrectNumber[counter].text = currentWrongCount.ToString();
                    counter++;
                }

            }
        }
        
        for (int k = counter; k <= 8; k++)
        {
            
            sscenarioQuestion[k].text = "";
            sscenarioCorrectNumber[k].text = "";
            sscenarioIncorrectNumber[k].text = "";
        }
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
