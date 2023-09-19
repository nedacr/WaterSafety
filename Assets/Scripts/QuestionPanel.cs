using UnityEngine;
using UnityEngine.UI;

public class QuestionPanel : MonoBehaviour
{
    public CameraSelection cameraSelection;
    
    private NPC currentNPC;
    public GameObject ResponsePanel;
    public GameObject ControlsPanel;

    public Text question1Text;
    public Text question2Text;
    public Text question3Text;

    public Text responseText;
    

    void Start()
    {
        Debug.Log("This Happend!!");
        //gameObject.SetActive(false);
        //ResponsePanel.SetActive(false);
    }

    public void ShowQuestionsForNPC(NPC npc)
    {
        currentNPC = npc;
        // Set the unique questions for the specific NPC
        // You can have a system to determine NPC-specific questions here
        string question1 = npc.GetQuestion1();
        string question2 = npc.GetQuestion2();
        string question3 = npc.GetQuestion3();

        // Set the questions in the UI text elements
        question1Text.text = question1;
        question2Text.text = question2;
        question3Text.text = question3;

        // Display the question panel
        if (currentNPC.GetCorrect() == false)
        {
            gameObject.SetActive(true);
            ControlsPanel.SetActive(false);
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
        }

        cameraSelection.MainToQuestion();
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
        }

        cameraSelection.MainToQuestion();
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
        }

        cameraSelection.MainToQuestion();
    }

    public void HidePanel()
    {
        Debug.Log("Pressed Button");
        ControlsPanel.SetActive(true);
        gameObject.SetActive(false);
        
    }

    public void Return()
    {
        Debug.Log("Returned");
        ResponsePanel.SetActive(false);
        ControlsPanel.SetActive(true);
        cameraSelection.QuestionToMain();
    }
    

}



