using UnityEngine;

public class NPC : MonoBehaviour
{

    public Light spotlightLight;

    public QuestionPanel questionPanel;

    public AudioSource ca, wa;

    public string npcName = "placeHolder"; // should be set to a number
    private const string CorrectKeyPrefix = "CorrectCount_";
    private const string WrongKeyPrefix = "WrongCount_";
    private const string QuestionPrefix = "Question_";
    private const string LocationPrefix = "Location_";

    // docks 1, beach 2, Lake 3
    public int SceneNumber = 0;

    public string uniqueQuestion = "What is this NPC doing Wrong?";

    public string question1 = "How are you?";
    public string question2 = "Are you okay?";
    public string question3 = "Are your parents around?";

    public string response1 = "I am not doing to hot";
    public string response2 = "No I am not okay";
    public string response3 = "No they left about an hour ago";
    public string answer = "No I am not okay";
    public string reviewQuestion = "this is the question placeholder";
    public string reviewAnswer = "this is the answer placeholder";
    bool correct = false;
    bool neverWrong = true;

    private int points = 25;

    public void IncreaseCorrectCount()
    {
        ca.Play();
        int currentCorrectCount = PlayerPrefs.GetInt(CorrectKeyPrefix + npcName, 0);
        currentCorrectCount++;
        PlayerPrefs.SetInt(CorrectKeyPrefix + npcName, currentCorrectCount);
    }

    // Use this method to increase the wrong count for the NPC
    public void IncreaseWrongCount()
    {
        wa.Play();
        int currentWrongCount = PlayerPrefs.GetInt(WrongKeyPrefix + npcName, 0);
        currentWrongCount++;
        PlayerPrefs.SetInt(WrongKeyPrefix + npcName, currentWrongCount);
    }

    // Use this method to get the correct count for the NPC
    public int GetCorrectCount()
    {
        return PlayerPrefs.GetInt(CorrectKeyPrefix + npcName, 0);
    }

    // Use this method to get the wrong count for the NPC
    public int GetWrongCount()
    {
        return PlayerPrefs.GetInt(WrongKeyPrefix + npcName, 0);
    }

    public string GetStoredQuestion()
    {
        return PlayerPrefs.GetString(QuestionPrefix + npcName, "");
    }

    public string getReviewQuestion()
    {
        return reviewQuestion;
    }

    public string getReviewAnswer()
    {
        return reviewAnswer;
    }

    public string getUniqueQuestion()
    {
        return uniqueQuestion;
    }

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
    public void lowerPoints()
    {
        if (points != 0)
        {
            points = points / 2;
        }
    }
    public int getPoints()
    {
        return points;
    }

    public void changeSpotLight()
    {
        spotlightLight.color = Color.green;
    }
    public void ChangeCorrect()
    {
        correct = true;
    }

    public void changeNeverWrong()
    {
        neverWrong = false;
    }

    public bool getNeverWrong()
    {
        
        return neverWrong;
    }

    public bool GetCorrect()
    {
        return correct;
    }

    public void updatePrefs()
    {
        if (neverWrong == true)
        {
            IncreaseCorrectCount();
        }
        else
        {
            IncreaseWrongCount();
        }

        PlayerPrefs.SetString(QuestionPrefix + npcName, uniqueQuestion);
        PlayerPrefs.SetInt(LocationPrefix + npcName, GetSceneNumber());
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

