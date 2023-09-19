using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSelection : MonoBehaviour
{
    private List<GameObject> cameras;
    //defualt index of cameras
    private int selectionIndex = 0;

    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("Cameras have been poitioned");
        cameras = new List<GameObject>();
        foreach(Transform t in transform)
        {
            cameras.Add(t.gameObject);
            t.gameObject.SetActive(false);
        }
        cameras[selectionIndex].SetActive(true);
    }

    // Update is called once per frame
    public void MainToQuestion()
    {
        if (cameras.Count > 1 && cameras[1] != null && cameras[0] != null)
        {
            cameras[1].SetActive(true);
            cameras[0].SetActive(false);
        }
        else
        {
            Debug.LogError("Camera references are not properly initialized.");
        }
    }

    public void QuestionToMain()
    {
        cameras[1].SetActive(false);
        cameras[0].SetActive(true);
    }
}
