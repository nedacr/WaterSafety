using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SummaryPage : MonoBehaviour
{
    //Panels
    public GameObject SummaryPanel;
    public GameObject ReviewPanel;
    public GameObject LeaderboardPanel;
    public GameObject ScenarioPanel;
    public GameObject QuestionPanel;

    //test
    public GameObject SelectionObject;
    public GameObject ReviewObject;
    public GameObject IncorrectList;
    public GameObject CorrectList;

    //review Object stuff
    public Text ReviewQuestions;
    public Text ReviewAnswers;

    //leaderboard object stuff
    public TMP_InputField enterName;
    public GameObject NamePanel;
    public GameObject Leaderboard;
    public GameObject KeyboardCanvas;


    //list of all scenario locations (is there a faster way?)
    public List<GameObject> scenarioCorrectObjects;
    public List<GameObject> scenarioIncorrectObjects;

    private List<List<string>> listOfCorrectLists = new List<List<string>>();
    private List<List<string>> listOfIncorrectLists = new List<List<string>>();

    public TextMeshProUGUI[] scoreTexts;  // TextMeshPro components for displaying scores
    public TextMeshProUGUI[] nameTexts;

    public string mainMenuSceneName = "MainMenu"; 

    

    // Start is called before the first frame update
    void Start()
    {
        SummaryPanel.SetActive(true);
        ReviewPanel.SetActive(false);
        LeaderboardPanel.SetActive(false);
        ScenarioPanel.SetActive(false);

        if (PlayerPrefs.GetInt("ResetLeaderboard", 0) == 1)
        {
            ResetLeaderboard();
            PlayerPrefs.SetInt("ResetLeaderboard", 0); // Reset the flag
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {

    }

    //no idea what these are for yet so ignore
    private void ActivateLeaderBoard()
    {
        SummaryPanel.SetActive(false);
        LeaderboardPanel.SetActive(true);
        //NamePanel.SetActive(true);
    }

    private void ActivateReviewPanel()
    {
        SummaryPanel.SetActive(false);
        ReviewPanel.SetActive(true);
        ScenarioPanel.SetActive(false);
    }
    //----------------------------------------------------
    void ResetLeaderboard()
    {
        for (int i = 0; i < scoreTexts.Length; i++)
        {
            PlayerPrefs.DeleteKey("Score" + i);
            PlayerPrefs.DeleteKey("Name" + i);
        }

        // You can also reset any other leaderboard-related PlayerPrefs keys here if needed.

        // Call this to update the UI after resetting the leaderboard.
        UpdateLeaderboardUI();
    }

    public void showScores()
    {
        NamePanel.SetActive(false);
        Leaderboard.SetActive(true);
        KeyboardCanvas.SetActive(false);
        SaveScore();
        UpdateLeaderboardUI();
    }

    public void SaveScore()
    {
        QuestionPanel questionPanel = QuestionPanel.GetComponent<QuestionPanel>();
        string playerName = enterName.text;
        int score = questionPanel.getTotalPoints();

        for (int i = 0; i < scoreTexts.Length; i++)
        {
            // Check if the current score is higher than the saved scores
            int savedScore = PlayerPrefs.GetInt("Score" + i, 0);
            if (score > savedScore)
            {
                // Shift existing scores down
                for (int j = scoreTexts.Length - 1; j > i; j--)
                {
                    int previousScore = PlayerPrefs.GetInt("Score" + (j - 1), 0);
                    string previousName = PlayerPrefs.GetString("Name" + (j - 1), "");
                    PlayerPrefs.SetInt("Score" + j, previousScore);
                    PlayerPrefs.SetString("Name" + j, previousName);
                }

                // Save the new score and name
                PlayerPrefs.SetInt("Score" + i, score);
                PlayerPrefs.SetString("Name" + i, playerName);
                break;
            }
        }
    }

    // Call this function to update the leaderboard UI
    public void UpdateLeaderboardUI()
    {
        for (int i = 0; i < scoreTexts.Length; i++)
        {
            int score = PlayerPrefs.GetInt("Score" + i, 0);
            string playerName = PlayerPrefs.GetString("Name" + i, "");
            scoreTexts[i].text = score.ToString();
            nameTexts[i].text = playerName;
        }
    }
    public void closeNamePanel()
    {
        NamePanel.SetActive(false);
        Leaderboard.SetActive(true);
        KeyboardCanvas.SetActive(false);

    }
    //----------------------------------------------------

   

    public void changeToLeaderboardPanel()
    {
        gameObject.SetActive(false);
        LeaderboardPanel.SetActive(true);
        Leaderboard.SetActive(true);
    }

    public void changeToReviewPanel()
    {
        gameObject.SetActive(false);
        ReviewPanel.SetActive(true);
        SelectionObject.SetActive(true);
    }
    public void returnToSummaryPanel()
    {
        gameObject.SetActive(true);
        ReviewPanel.SetActive(false);
        LeaderboardPanel.SetActive(false);
    }

    public void returnToMenu()
    {
        //in this section i need to learn how to reload a game without taking too long. (maybe use a loading screen?)
        SceneManager.LoadScene(mainMenuSceneName);
    }

    public void changeBeachReview()
    {

        listOfCorrectLists.Clear();
        listOfIncorrectLists.Clear();

        for(int q = 0; q < 10; q++)
        {
            GameObject scenarioCorrectObject = scenarioCorrectObjects[q];
            scenarioCorrectObject.SetActive(true);
            GameObject scenarioIncorrectObject = scenarioIncorrectObjects[q];
            scenarioIncorrectObject.SetActive(true);
        }


        QuestionPanel questionPanel = QuestionPanel.GetComponent<QuestionPanel>();

        SelectionObject.SetActive(false);
        CorrectList.SetActive(true);
        IncorrectList.SetActive(true);
        List<NPC> correct = questionPanel.GetCorrectTwoNPC();
        List<NPC> incorrect = questionPanel.GetFalseTwoNPC();

        int i = 0;
        foreach (NPC npc in correct)
        {
            if (i < scenarioCorrectObjects.Count) // Check if there are enough scenario objects
            {
                GameObject scenarioObject = scenarioCorrectObjects[i];

                Text scenarioText = scenarioObject.GetComponent<Text>();


                scenarioText.text = npc.GetAnswer();

                string answer = npc.getReviewQuestion();
                string points = npc.getReviewAnswer();

                List<string> innerList = new List<string>();
                innerList.Add(answer);
                innerList.Add(points);

                listOfCorrectLists.Add(innerList);


                i++;
            }
            else
            {
                Debug.LogWarning("Not enough scenario objects for correct answers.");
                break;
            }
        }

        int j = 0;
        foreach (NPC npc in incorrect)
        {
            if (j < scenarioIncorrectObjects.Count) // Check if there are enough scenario objects
            {
                GameObject scenarioObject = scenarioIncorrectObjects[j];
                Text scenarioText = scenarioObject.GetComponent<Text>();

                scenarioText.text = npc.GetAnswer();

                string answer = npc.getReviewQuestion();
                string points = npc.getReviewAnswer(); //points means answer (idk i dont want to change it 25 times)

                List<string> innerList = new List<string>();
                innerList.Add(answer);
                innerList.Add(points);

                listOfIncorrectLists.Add(innerList);


                j++;
            }
            else
            {
                Debug.LogWarning("Not enough scenario objects for correct answers.");
                break;
            }
        }

        for (int k = i; k < 10; k++)
        {
            GameObject scenarioObject = scenarioCorrectObjects[k];
            scenarioObject.SetActive(false);
        }
        for (int l = j; l < 10; l++)
        {
            GameObject scenarioObject = scenarioIncorrectObjects[l];
            scenarioObject.SetActive(false);
        }

    }

    public void changeLakeReview()
    {

        listOfCorrectLists.Clear();
        listOfIncorrectLists.Clear();

        for (int q = 0; q < 10; q++)
        {
            GameObject scenarioCorrectObject = scenarioCorrectObjects[q];
            scenarioCorrectObject.SetActive(true);
            GameObject scenarioIncorrectObject = scenarioIncorrectObjects[q];
            scenarioIncorrectObject.SetActive(true);
        }

        QuestionPanel questionPanel = QuestionPanel.GetComponent<QuestionPanel>();

        SelectionObject.SetActive(false);
        CorrectList.SetActive(true);
        IncorrectList.SetActive(true);
        List<NPC> correct = questionPanel.GetCorrectThreeNPC();
        List<NPC> incorrect = questionPanel.GetFalseThreeNPC();

        int i = 0;
        foreach (NPC npc in correct)
        {
            if (i < scenarioCorrectObjects.Count) // Check if there are enough scenario objects
            {
                GameObject scenarioObject = scenarioCorrectObjects[i];

                Text scenarioText = scenarioObject.GetComponent<Text>();


                scenarioText.text = npc.GetAnswer();

                string answer = npc.getReviewQuestion();
                string points = npc.getReviewAnswer();

                List<string> innerList = new List<string>();
                innerList.Add(answer);
                innerList.Add(points);

                listOfCorrectLists.Add(innerList);


                i++;
            }
            else
            {
                Debug.LogWarning("Not enough scenario objects for correct answers.");
                break;
            }
        }

        int j = 0;
        foreach (NPC npc in incorrect)
        {
            if (j < scenarioIncorrectObjects.Count) // Check if there are enough scenario objects
            {
                GameObject scenarioObject = scenarioIncorrectObjects[j];
                Text scenarioText = scenarioObject.GetComponent<Text>();

                scenarioText.text = npc.GetAnswer();

                string answer = npc.getReviewQuestion();
                string points = npc.getReviewAnswer(); //points means answer (idk i dont want to change it 25 times)

                List<string> innerList = new List<string>();
                innerList.Add(answer);
                innerList.Add(points);

                listOfIncorrectLists.Add(innerList);


                j++;
            }
            else
            {
                Debug.LogWarning("Not enough scenario objects for correct answers.");
                break;
            }
        }

        for (int k = i; k < 10; k++)
        {
            GameObject scenarioObject = scenarioCorrectObjects[k];
            scenarioObject.SetActive(false);
        }
        for (int l = j; l < 10; l++)
        {
            GameObject scenarioObject = scenarioIncorrectObjects[l];
            scenarioObject.SetActive(false);
        }

    }

    public void changeDocksReview()
    {

        listOfCorrectLists.Clear();
        listOfIncorrectLists.Clear();

        for (int q = 0; q < 10; q++)
        {
            GameObject scenarioCorrectObject = scenarioCorrectObjects[q];
            scenarioCorrectObject.SetActive(true);
            GameObject scenarioIncorrectObject = scenarioIncorrectObjects[q];
            scenarioIncorrectObject.SetActive(true);
        }

        QuestionPanel questionPanel = QuestionPanel.GetComponent<QuestionPanel>();

        SelectionObject.SetActive(false);
        CorrectList.SetActive(true);
        IncorrectList.SetActive(true);
        List<NPC> correct = questionPanel.GetCorrectOneNPC();
        List<NPC> incorrect = questionPanel.GetFalseOneNPC();

        int i = 0;
        foreach (NPC npc in correct)
        {
            if (i < scenarioCorrectObjects.Count) // Check if there are enough scenario objects
            {
                GameObject scenarioObject = scenarioCorrectObjects[i];

                Text scenarioText = scenarioObject.GetComponent<Text>();


                scenarioText.text = npc.GetAnswer();

                string answer = npc.getReviewQuestion();
                string points = npc.getReviewAnswer();

                List<string> innerList = new List<string>();
                innerList.Add(answer);
                innerList.Add(points);

                listOfCorrectLists.Add(innerList);


                i++;
            }
            else
            {
                Debug.LogWarning("Not enough scenario objects for correct answers.");
                break;
            }
        }

        int j = 0;
        foreach (NPC npc in incorrect)
        {
            if (j < scenarioIncorrectObjects.Count) // Check if there are enough scenario objects
            {
                GameObject scenarioObject = scenarioIncorrectObjects[j];
                Text scenarioText = scenarioObject.GetComponent<Text>();

                scenarioText.text = npc.GetAnswer();

                string answer = npc.getReviewQuestion();
                string points = npc.getReviewAnswer(); //points means answer (idk i dont want to change it 25 times)

                List<string> innerList = new List<string>();
                innerList.Add(answer);
                innerList.Add(points);

                listOfIncorrectLists.Add(innerList);


                j++;
            }
            else
            {
                Debug.LogWarning("Not enough scenario objects for correct answers.");
                break;
            }
        }

        for (int k = i; k < 10; k++)
        {
            GameObject scenarioObject = scenarioCorrectObjects[k];
            scenarioObject.SetActive(false);
        }
        for (int l = j; l < 10; l++)
        {
            GameObject scenarioObject = scenarioIncorrectObjects[l];
            scenarioObject.SetActive(false);
        }

    }

    public void reviewCorrect1()
    {

        List<string> firstInnerList = listOfCorrectLists[0];

        if (firstInnerList != null)
        {
            // Now you can access elements in the first inner list
            string answer = firstInnerList[0];  // "Answer1"
            string points = firstInnerList[1];  // "1"

            ChangeReview(answer, points);

        }
    }
    public void reviewCorrect2()
    {

        List<string> firstInnerList = listOfCorrectLists[1];

        if (firstInnerList != null)
        {
            // Now you can access elements in the first inner list
            string answer = firstInnerList[0];  // "Answer1"
            string points = firstInnerList[1];  // "1"

            ChangeReview(answer, points);

        }
    }
    public void reviewCorrect3()
    {

        List<string> firstInnerList = listOfCorrectLists[2];

        if (firstInnerList != null)
        {
            // Now you can access elements in the first inner list
            string answer = firstInnerList[0];  // "Answer1"
            string points = firstInnerList[1];  // "1"

            ChangeReview(answer, points);

        }
    }
    public void reviewCorrect4()
    {

        List<string> firstInnerList = listOfCorrectLists[3];

        if (firstInnerList != null)
        {
            // Now you can access elements in the first inner list
            string answer = firstInnerList[0];  // "Answer1"
            string points = firstInnerList[1];  // "1"

            ChangeReview(answer, points);

        }
    }
    public void reviewCorrect5()
    {

        List<string> firstInnerList = listOfCorrectLists[4];

        if (firstInnerList != null)
        {
            // Now you can access elements in the first inner list
            string answer = firstInnerList[0];  // "Answer1"
            string points = firstInnerList[1];  // "1"

            ChangeReview(answer, points);

        }
    }
    public void reviewCorrect6()
    {

        List<string> firstInnerList = listOfCorrectLists[5];

        if (firstInnerList != null)
        {
            // Now you can access elements in the first inner list
            string answer = firstInnerList[0];  // "Answer1"
            string points = firstInnerList[1];  // "1"

            ChangeReview(answer, points);

        }
    }
    public void reviewCorrect7()
    {

        List<string> firstInnerList = listOfCorrectLists[6];

        if (firstInnerList != null)
        {
            // Now you can access elements in the first inner list
            string answer = firstInnerList[0];  // "Answer1"
            string points = firstInnerList[1];  // "1"

            ChangeReview(answer, points);

        }
    }
    public void reviewCorrect8()
    {

        List<string> firstInnerList = listOfCorrectLists[7];

        if (firstInnerList != null)
        {
            // Now you can access elements in the first inner list
            string answer = firstInnerList[0];  // "Answer1"
            string points = firstInnerList[1];  // "1"

            ChangeReview(answer, points);

        }
    }
    public void reviewCorrect9()
    {

        List<string> firstInnerList = listOfCorrectLists[8];

        if (firstInnerList != null)
        {
            // Now you can access elements in the first inner list
            string answer = firstInnerList[0];  // "Answer1"
            string points = firstInnerList[1];  // "1"

            ChangeReview(answer, points);

        }
    }
    public void reviewCorrect10()
    {

        List<string> firstInnerList = listOfCorrectLists[9];

        if (firstInnerList != null)
        {
            // Now you can access elements in the first inner list
            string answer = firstInnerList[0];  // "Answer1"
            string points = firstInnerList[1];  // "1"

            ChangeReview(answer, points);

        }
    }
    public void reviewInorrect1()
    {

        List<string> firstInnerList = listOfIncorrectLists[0];

        if (firstInnerList != null)
        {
            // Now you can access elements in the first inner list
            string answer = firstInnerList[0];  // "Answer1"
            string points = firstInnerList[1];  // "1"

            ChangeReview(answer, points);

        }
    }
    public void reviewInorrect2()
    {

        List<string> firstInnerList = listOfIncorrectLists[1];

        if (firstInnerList != null)
        {
            // Now you can access elements in the first inner list
            string answer = firstInnerList[0];  // "Answer1"
            string points = firstInnerList[1];  // "1"

            ChangeReview(answer, points);

        }
    }
    public void reviewInorrect3()
    {

        List<string> firstInnerList = listOfIncorrectLists[2];

        if (firstInnerList != null)
        {
            // Now you can access elements in the first inner list
            string answer = firstInnerList[0];  // "Answer1"
            string points = firstInnerList[1];  // "1"

            ChangeReview(answer, points);

        }
    }
    public void reviewInorrect4()
    {

        List<string> firstInnerList = listOfIncorrectLists[3];

        if (firstInnerList != null)
        {
            // Now you can access elements in the first inner list
            string answer = firstInnerList[0];  // "Answer1"
            string points = firstInnerList[1];  // "1"

            ChangeReview(answer, points);

        }
    }
    public void reviewInorrect5()
    {

        List<string> firstInnerList = listOfIncorrectLists[4];

        if (firstInnerList != null)
        {
            // Now you can access elements in the first inner list
            string answer = firstInnerList[0];  // "Answer1"
            string points = firstInnerList[1];  // "1"

            ChangeReview(answer, points);

        }
    }
    public void reviewInorrect6()
    {

        List<string> firstInnerList = listOfIncorrectLists[5];

        if (firstInnerList != null)
        {
            // Now you can access elements in the first inner list
            string answer = firstInnerList[0];  // "Answer1"
            string points = firstInnerList[1];  // "1"

            ChangeReview(answer, points);

        }
    }
    public void reviewInorrect7()
    {

        List<string> firstInnerList = listOfIncorrectLists[6];

        if (firstInnerList != null)
        {
            // Now you can access elements in the first inner list
            string answer = firstInnerList[0];  // "Answer1"
            string points = firstInnerList[1];  // "1"

            ChangeReview(answer, points);

        }
    }
    public void reviewInorrect8()
    {

        List<string> firstInnerList = listOfIncorrectLists[7];

        if (firstInnerList != null)
        {
            // Now you can access elements in the first inner list
            string answer = firstInnerList[0];  // "Answer1"
            string points = firstInnerList[1];  // "1"

            ChangeReview(answer, points);

        }
    }
    public void reviewInorrect9()
    {

        List<string> firstInnerList = listOfIncorrectLists[8];

        if (firstInnerList != null)
        {
            // Now you can access elements in the first inner list
            string answer = firstInnerList[0];  // "Answer1"
            string points = firstInnerList[1];  // "1"

            ChangeReview(answer, points);

        }
    }
    public void reviewInorrect10()
    {

        List<string> firstInnerList = listOfIncorrectLists[9];

        if (firstInnerList != null)
        {
            // Now you can access elements in the first inner list
            string answer = firstInnerList[0];  // "Answer1"
            string points = firstInnerList[1];  // "1"

            ChangeReview(answer, points);

        }
    }


    public void ChangeReview(string question, string answer)
    {
        ReviewObject.SetActive(true);
        CorrectList.SetActive(false);
        IncorrectList.SetActive(false);

        ReviewQuestions.text = question;
        ReviewAnswers.text = answer;

    }

    public void returnReview()
    {
        ReviewObject.SetActive(false);
        CorrectList.SetActive(true);
        IncorrectList.SetActive(true);


    }
    public void returnSummary()
    {
        ReviewObject.SetActive(false);
        CorrectList.SetActive(false);
        IncorrectList.SetActive(false);
        SelectionObject.SetActive(false);
        ReviewPanel.SetActive(false);
        SummaryPanel.SetActive(true);
        KeyboardCanvas.SetActive(false);
        LeaderboardPanel.SetActive(false);
        Leaderboard.SetActive(false);
        NamePanel.SetActive(false);
        KeyboardCanvas.SetActive(false);
    }



}



