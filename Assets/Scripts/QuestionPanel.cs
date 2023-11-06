using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class QuestionPanel : MonoBehaviour
{
    public CameraSelection cameraSelection;

    private bool DockFinished = false;
    private bool LakeFinished = false;
    private bool BeachFinished = false;

    private NPC currentNPC;
    public GameObject ResponsePanel;
    public GameObject ControlsPanelDock;
    public GameObject ControlsPanelBeach;
    public GameObject ControlsPanelLake;
    public GameObject FinishedDockPanel;
    public GameObject FinishedLakePanel;
    public GameObject FinishedBeachPanel;
    public GameObject SummaryPanel;
    public GameObject ControlsPanelFar;

    public Text overheadQuestion;

    public Text question1Text;
    public Text question2Text;
    public Text question3Text;

    public Text responseText;

    public Text scoreCard;

    private List<NPC> allNPCs = new List<NPC>();

    public int totalPoints = 0;
    

    public void AddNPC(NPC npc)
    {
        allNPCs.Add(npc);
    }

    private int ScenesFinished = 0;

    void Start()
    {
        Debug.Log("This Happend!!");

        //gameObject.SetActive(false);
        //ResponsePanel.SetActive(false);
    }

    public List<NPC> GetCorrectOneNPC()
    {
        List<NPC> unsortedNPCs = new List<NPC>(allNPCs);

        List<NPC> correctOne = new List<NPC>();

        foreach (NPC npc in unsortedNPCs)
        {
            if (npc.GetSceneNumber() == 1)
            {
                if (npc.getNeverWrong())
                {
                    correctOne.Add(npc);
                }

            }
            
        }

        return correctOne;
    }

    public List<NPC> GetFalseOneNPC()
    {
        List<NPC> unsortedNPCs = new List<NPC>(allNPCs);

        List<NPC> falseOne = new List<NPC>();

        foreach (NPC npc in unsortedNPCs)
        {
            if (npc.GetSceneNumber() == 1)
            {
                if (!npc.getNeverWrong())
                {
                    falseOne.Add(npc);
                }

            }

        }

        return falseOne;
    }

    public List<NPC> GetCorrectTwoNPC()
    {
        List<NPC> unsortedNPCs = new List<NPC>(allNPCs);

        List<NPC> correctTwo = new List<NPC>();

        foreach (NPC npc in unsortedNPCs)
        {
            if (npc.GetSceneNumber() == 2)
            {
                if (npc.getNeverWrong())
                {
                    correctTwo.Add(npc);
                }

            }

        }

        return correctTwo;
    }

    public List<NPC> GetFalseTwoNPC()
    {
        List<NPC> unsortedNPCs = new List<NPC>(allNPCs);

        List<NPC> falseTwo = new List<NPC>();

        foreach (NPC npc in unsortedNPCs)
        {
            if (npc.GetSceneNumber() == 2)
            {
                if (!npc.getNeverWrong())
                {
                    falseTwo.Add(npc);
                }

            }

        }

        return falseTwo;
    }

    public List<NPC> GetCorrectThreeNPC()
    {
        List<NPC> unsortedNPCs = new List<NPC>(allNPCs);

        List<NPC> correctThree = new List<NPC>();

        foreach (NPC npc in unsortedNPCs)
        {
            if (npc.GetSceneNumber() == 3)
            {
                if (npc.getNeverWrong())
                {
                    correctThree.Add(npc);
                }

            }

        }

        return correctThree;
    }

    public List<NPC> GetFalseThreeNPC()
    {
        List<NPC> unsortedNPCs = new List<NPC>(allNPCs);

        List<NPC> falseThree = new List<NPC>();

        foreach (NPC npc in unsortedNPCs)
        {
            if (npc.GetSceneNumber() == 3)
            {
                if (!npc.getNeverWrong())
                {
                    falseThree.Add(npc);
                }

            }

        }

        return falseThree;
    }

    public void ShowQuestionsForNPC(NPC npc)
    {
        currentNPC = npc;
        // Set the unique questions for the specific NPC
        // You can have a system to determine NPC-specific questions here
        string question1 = npc.GetQuestion1();
        string question2 = npc.GetQuestion2();
        string question3 = npc.GetQuestion3();

        string npcQuestion = npc.getUniqueQuestion();

        // Set the questions in the UI text elements
        question1Text.text = question1;
        question2Text.text = question2;
        question3Text.text = question3;

        // Display the question panel
        if (currentNPC.GetCorrect() == false)
        {
            gameObject.SetActive(true);
            ControlsPanelDock.SetActive(false);
            ControlsPanelBeach.SetActive(false);
            ControlsPanelLake.SetActive(false);
        }
    }

    public void showResponse1()
    {
        Debug.Log("Response activated");
        gameObject.SetActive(false);

        string response1 = currentNPC.GetResponse1();
        //set reponse to UI text elements
        responseText.text = response1;
        //display the response panel
        gameObject.SetActive(false);

        //unhide next panel
        ResponsePanel.SetActive(true);

        if (currentNPC.GetAnswer() == response1)
        {
            currentNPC.ChangeCorrect();
            currentNPC.changeSpotLight();
            totalPoints = totalPoints + currentNPC.getPoints();
            updateScore();
            finishedCheck();
        }
        else
        {
            currentNPC.lowerPoints();
            currentNPC.changeNeverWrong();
        }
        Debug.Log(currentNPC.GetSceneNumber());
        switch (currentNPC.GetSceneNumber())
        {
            case 1: // Docks
                cameraSelection.MainToQuestion();
                break;
            case 2: // Beach
                cameraSelection.MainToBeach();
                break;
            case 3: // Lake
                cameraSelection.MainToLake();
                break;
            default:
                Debug.LogWarning("idk my guy we just should never get here");
                break;
        }
    }
    public void showResponse2()
    {
        Debug.Log("Response activated");
        gameObject.SetActive(false);

        string response1 = currentNPC.GetResponse2();
        //set reponse to UI text elements
        responseText.text = response1;
        //display the response panel
        gameObject.SetActive(false);

        //unhide next panel
        ResponsePanel.SetActive(true);

        if (currentNPC.GetAnswer() == response1)
        {
            currentNPC.ChangeCorrect();
            currentNPC.changeSpotLight();
            totalPoints = totalPoints + currentNPC.getPoints();
            updateScore();
            finishedCheck();
        }
        else
        {
            currentNPC.lowerPoints();
            currentNPC.changeNeverWrong();
        }

        switch (currentNPC.GetSceneNumber())
        {
            case 1: // Docks
                cameraSelection.MainToQuestion();
                break;
            case 2: // Beach
                cameraSelection.MainToBeach();
                break;
            case 3: // Lake
                cameraSelection.MainToLake();
                break;
            default:
                Debug.LogWarning("idk my guy we just should never get here");
                break;
        }
    }
    public void showResponse3()
    {
        Debug.Log("Response activated");
        gameObject.SetActive(false);

        string response1 = currentNPC.GetResponse3();
        //set reponse to UI text elements
        responseText.text = response1;
        //display the response panel
        gameObject.SetActive(false);

        //unhide next panel
        ResponsePanel.SetActive(true);

        if (currentNPC.GetAnswer() == response1)
        {
            currentNPC.ChangeCorrect();
            currentNPC.changeSpotLight();
            totalPoints = totalPoints + currentNPC.getPoints();
            updateScore();
            finishedCheck();
        }
        else
        {
            currentNPC.lowerPoints();
            currentNPC.changeNeverWrong();
        }

        switch (currentNPC.GetSceneNumber())
        {
            case 1: // Docks
                cameraSelection.MainToQuestion();
                break;
            case 2: // Beach
                cameraSelection.MainToBeach();
                break;
            case 3: // Lake
                cameraSelection.MainToLake();
                break;
            default:
                Debug.LogWarning("idk my guy we just should never get here");
                break;
        }
    }

    public void updateScore()
    {
        string strNumber = totalPoints.ToString();
        scoreCard.text = strNumber;
    }

    public int getTotalPoints()
    {
        return totalPoints;
    }

    public void HidePanel()
    {
        Debug.Log("Pressed Button");

        // Determine which ControlsPanel to activate based on NPC's SceneNumber
        switch (currentNPC.GetSceneNumber())
        {
            case 1: // Docks
                ControlsPanelDock.SetActive(true);
                ControlsPanelBeach.SetActive(false);
                ControlsPanelLake.SetActive(false);
                break;
            case 2: // Beach
                ControlsPanelDock.SetActive(false);
                ControlsPanelBeach.SetActive(true);
                ControlsPanelLake.SetActive(false);
                break;
            case 3: // Lake
                ControlsPanelDock.SetActive(false);
                ControlsPanelBeach.SetActive(false);
                ControlsPanelLake.SetActive(true);
                break;
            default:
                Debug.LogWarning("Unknown SceneNumber for NPC.");
                break;
        }

        gameObject.SetActive(false);
    }

    public void Return()
    {
        Debug.Log("Returned");

        // Determine which ControlsPanel to activate based on NPC's SceneNumber
        switch (currentNPC.GetSceneNumber())
        {
            case 1: // Docks
                ControlsPanelDock.SetActive(true);
                ControlsPanelBeach.SetActive(false);
                ControlsPanelLake.SetActive(false);
                cameraSelection.QuestionToMain();
                break;
            case 2: // Beach
                ControlsPanelDock.SetActive(false);
                ControlsPanelBeach.SetActive(true);
                ControlsPanelLake.SetActive(false);
                cameraSelection.QuestionToBeach();
                break;
            case 3: // Lake
                ControlsPanelDock.SetActive(false);
                ControlsPanelBeach.SetActive(false);
                ControlsPanelLake.SetActive(true);
                cameraSelection.QuestionToLake();
                break;
            default:
                Debug.LogWarning("Unknown SceneNumber for NPC.");
                break;
        }

        ResponsePanel.SetActive(false);

    }

    private void finishedCheck()
    {
        /*if (LakeFinished && BeachFinished && DockFinished)
        {
            allSceneFinished();
            Debug.Log("EVERY SCENE IS FINISHED");
            return;
        }*/
        if (AllDockNPCsCorrect() && !DockFinished)
        {
            finishedDocks();
            Debug.Log("All Dock NPCs have provided the correct response!");
            DockFinished = true;

        }
        if (AllBeachNPCsCorrect() && !BeachFinished)
        {
            finishedBeach();
            Debug.Log("All Beach NPCs have provided the correct response!");
            BeachFinished = true;

        }
        if (AllLakeNPCsCorrect() && !LakeFinished)
        {
            finishedLake();
            Debug.Log("All Lake NPCs have provided the correct response!");
            LakeFinished = true;

        }

    }

    // Method to check if all NPCs have provided correct response
    private bool AllDockNPCsCorrect()
    {
        foreach (var npc in allNPCs)
        {
            // Only check NPCs with the targetSceneNumber
            if (npc.GetSceneNumber() == 1 && !npc.GetCorrect())
                return false; // At least one NPC hasn't provided correct response
        }
        return true;
    }

    private bool AllBeachNPCsCorrect()
    {
        foreach (var npc in allNPCs)
        {
            // Only check NPCs with the targetSceneNumber
            if (npc.GetSceneNumber() == 2 && !npc.GetCorrect())
                return false; // At least one NPC hasn't provided correct response
        }
        return true;
    }

    private bool AllLakeNPCsCorrect()
    {
        foreach (var npc in allNPCs)
        {
            // Only check NPCs with the targetSceneNumber
            if (npc.GetSceneNumber() == 3 && !npc.GetCorrect())
                return false; // At least one NPC hasn't provided correct response
        }
        return true;
    }

    public void returnSceneFinished()
    {


        switch (currentNPC.GetSceneNumber())
        {
            case 1: // Docks
                ControlsPanelDock.SetActive(true);
                FinishedDockPanel.SetActive(false);
                cameraSelection.QuestionToMain();
                break;
            case 2: // Beach
                ControlsPanelBeach.SetActive(true);
                FinishedBeachPanel.SetActive(false);
                cameraSelection.QuestionToBeach();
                break;
            case 3: // Lake
                ControlsPanelLake.SetActive(true);
                FinishedLakePanel.SetActive(false);

                cameraSelection.QuestionToLake();
                break;
            default:
                Debug.LogWarning("Unknown SceneNumber for NPC.");
                break;
        }
    }

    public void continueSceneFinished()
    {


        switch (currentNPC.GetSceneNumber())
        {
            case 1: // Docks
                FinishedDockPanel.SetActive(false);
                cameraSelection.MainToQuestion();
                break;
            case 2: // Beach
                FinishedBeachPanel.SetActive(false);
                cameraSelection.MainToBeach();
                break;
            case 3: // Lake
                FinishedLakePanel.SetActive(false);
                cameraSelection.MainToLake();
                break;
            default:
                Debug.LogWarning("Unknown SceneNumber for NPC.");
                break;
        }


        SummaryPanel.SetActive(true);
        gameObject.SetActive(false);

    }

    public void finishedDocks()
    {
        ResponsePanel.SetActive(false);
        FinishedDockPanel.SetActive(true);

        if (ControlsPanelFar != null)
        {
            Button docksButton = ControlsPanelFar.transform.Find("DocksButton").GetComponent<Button>();
            if (docksButton != null)
            {
                docksButton.gameObject.SetActive(false);
                Debug.Log("Docks button has been removed");
                ScenesFinished++;
                Debug.Log(ScenesFinished);
                if (ScenesFinished >= 3)
                {
                    allSceneFinished();
                }
            }
        }

    }

    public void finishedLake()
    {
        ResponsePanel.SetActive(false);
        FinishedLakePanel.SetActive(true);
        if (ControlsPanelFar != null)
        {
            Button LakeButton = ControlsPanelFar.transform.Find("LakeButton").GetComponent<Button>();
            if (LakeButton != null)
            {
                LakeButton.gameObject.SetActive(false);
                Debug.Log("Lake button has been removed");

                ScenesFinished++;

                Debug.Log(ScenesFinished);
                if (ScenesFinished >= 3)
                {
                    allSceneFinished();
                }
            }
        }

    }

    public void finishedBeach()
    {
        ResponsePanel.SetActive(false);
        FinishedBeachPanel.SetActive(true);
        Debug.Log("we got here");
        if (ControlsPanelFar != null)
        {
            Button BeachButton = ControlsPanelFar.transform.Find("BeachButton").GetComponent<Button>();
            if (BeachButton != null)
            {
                BeachButton.gameObject.SetActive(false);
                Debug.Log("Beach button has been removed");
                ScenesFinished++;
                Debug.Log(ScenesFinished);
                if (ScenesFinished >= 3)
                {
                    allSceneFinished();
                }
            }
        }

    }

    private void allSceneFinished()
    {

        Debug.Log("All scenes have been finished");
        switch (currentNPC.GetSceneNumber())
        {
            case 1: // Docks


                Button docksContinueButton = FinishedDockPanel.transform.Find("ContinueButton").GetComponent<Button>();
                if (docksContinueButton != null)
                    docksContinueButton.gameObject.SetActive(true);

                break;
            case 2: // Beach


                Button beachContinueButton = FinishedBeachPanel.transform.Find("ContinueButton").GetComponent<Button>();
                if (beachContinueButton != null)
                    beachContinueButton.gameObject.SetActive(true);

                break;
            case 3: // Lake


                Button lakeContinueButton = FinishedLakePanel.transform.Find("ContinueButton").GetComponent<Button>();
                if (lakeContinueButton != null)
                    lakeContinueButton.gameObject.SetActive(true);

                break;
            default:
                Debug.LogWarning("Unknown SceneNumber for NPC.");
                break;
        }

    }


}



