using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameScript : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
        //troubleshooting start button
        Debug.Log("Game has begun.");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Play has Quit The Game");
    }

}
