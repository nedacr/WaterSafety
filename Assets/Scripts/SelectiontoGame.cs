using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectiontoGame : MonoBehaviour
{
   public void SelectionToGameScene()
    {

        int randomSceneIndex = Random.Range(1, 5);
        Debug.Log(randomSceneIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + randomSceneIndex);
    }
}
