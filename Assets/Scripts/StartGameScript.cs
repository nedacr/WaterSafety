using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameScript : MonoBehaviour
{
    public void Play()
    {
        string sceneNameToLoad = "SelectCharacter"; // Replace "YourSceneName" with the actual name of your scene

        // Load the scene by name
        SceneManager.LoadScene(sceneNameToLoad);
        Debug.Log("Game has begun.");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Play has Quit The Game");
    }

}
