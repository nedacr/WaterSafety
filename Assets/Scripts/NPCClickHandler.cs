using UnityEngine;

public class NPC : MonoBehaviour
{
    public QuestionPanel questionPanel;

    public string question1 = "How are you?";
    public string question2 = "Are you okay?";
    public string question3 = "Are your parents around?";

    public string response1 = "I am not doing to hot";
    public string response2 = "No I am not okay";
    public string response3 = "No they left about an hour ago";

    public string GetQuestion1()
    {
        return question1;
    }

    public string GetQuestion2()
    {
        return question2;
    }

    public string GetQuestion3()
    {
        return question3;
    }

    public string GetResponse1()
    {
        return response1;
    }
    public string GetResponse2()
    {
        return response2;
    }
    public string GetResponse3()
    {
        return response3;
    }

    private void OnMouseDown()
    {
        if (questionPanel != null)
        {
            Debug.Log("Clicked!");
            questionPanel.ShowQuestionsForNPC(this);
        }
        else
        {
            Debug.LogError("QuestionPanel is not assigned to the NPC.");
        }
    }

}

