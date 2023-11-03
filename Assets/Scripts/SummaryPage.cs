using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    //list of all scenario locations (is there a faster way?)
    public List<GameObject> scenarioCorrectObjects;
    public List<GameObject> scenarioIncorrectObjects;

    private List<List<string>> listOfCorrectLists = new List<List<string>>();
    private List<List<string>> listOfIncorrectLists = new List<List<string>>();


    // Start is called before the first frame update
    void Start()
    {
        SummaryPanel.SetActive(true);
        ReviewPanel.SetActive(false);
        LeaderboardPanel.SetActive(false);
        ScenarioPanel.SetActive(false);
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
    public void changeToLeaderboardPanel()
    {
        gameObject.SetActive(false);
        LeaderboardPanel.SetActive(true);
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
    }

    public void changeBeachReview()
    {
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

                string answer = npc.GetAnswer();
                int points = npc.getPoints();

                List<string> innerList = new List<string>();
                innerList.Add(answer);
                innerList.Add(points.ToString());

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

                string answer = npc.GetAnswer();
                int points = npc.getPoints();

                List<string> innerList = new List<string>();
                innerList.Add(answer);
                innerList.Add(points.ToString());

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
    }



}



