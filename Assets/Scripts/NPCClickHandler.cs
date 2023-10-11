using UnityEngine;

public class NPC : MonoBehaviour
{

    public Light spotlightLight;

    public QuestionPanel questionPanel;


    // docks 1, beach 2, Lake 3
    public int SceneNumber = 0;

    public string question1 = "How are you?";
    public string question2 = "Are you okay?";
    public string question3 = "Are your parents around?";

    public string response1 = "I am not doing to hot";
    public string response2 = "No I am not okay";
    public string response3 = "No they left about an hour ago";
    public string answer = "No I am not okay";
    bool correct = false;

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
    public string GetAnswer()
    {
        return answer;
    }

    private void OnMouseDown()
    {
        if (questionPanel != null && (CameraSelection.cameras[0].activeSelf || CameraSelection.cameras[5].activeSelf || CameraSelection.cameras[4].activeSelf))  // Check if camera[0] is active)
        {
            Debug.Log("Clicked!");
            questionPanel.ShowQuestionsForNPC(this);
        }
        else
        {
            
        }
    }

    public void changeSpotLight()
    {
        spotlightLight.color = Color.green;
    }
    public void ChangeCorrect()
    {
        correct = true;
    }
    public bool GetCorrect()
    {
        return correct;
    }

    public int GetSceneNumber()
    {
        return SceneNumber;
    }

    private void Awake()
    {
        // Add this NPC to the QuestionPanel's list of NPCs
        if (questionPanel != null)
            questionPanel.AddNPC(this);
        else
            Debug.LogError("QuestionPanel is not assigned to the NPC.");
    }

}

