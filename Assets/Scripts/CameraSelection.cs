using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSelection : MonoBehaviour
{
    public GameObject ControlsPanelDock;
    public GameObject ControlsPanelBeach;
    public static List<GameObject> cameras;
    //defualt index of cameras
    private int selectionIndex = 0;

    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("Cameras have been poitioned");
        cameras = new List<GameObject>();
        foreach (Transform t in transform)
        {
            cameras.Add(t.gameObject);
            t.gameObject.SetActive(false);
        }
        cameras[3].SetActive(true);
    }

    //Current camera list 
    // 0 = dock close camera
    // 1 = question panel camera
    // 2 = beach camera
    // 3 = Dock Far Camera

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

    public void DockZoomin()
    {
        cameras[3].SetActive(false);
        ControlsPanelBeach.SetActive(false);
        ControlsPanelDock.SetActive(true);
        cameras[0].SetActive(true);

        // Calculate the new z position for cameras[0] based on cameras[3]'s rotational position
        float rotationY = cameras[3].transform.rotation.eulerAngles.y;
        float newZPositionForCameras0 = Mathf.Lerp(110f, 50f, (rotationY - 68f) / (117f - 68f));  // Inverted Lerp

        // Update the z position of cameras[0]
        Vector3 newPositionForCameras0 = new Vector3(cameras[0].transform.position.x, cameras[0].transform.position.y, newZPositionForCameras0);
        cameras[0].transform.position = newPositionForCameras0;
    }

    public void ZoomOut()
    {
        cameras[0].SetActive(false);

        ControlsPanelDock.SetActive(false);
        ControlsPanelBeach.SetActive(true);

        cameras[3].SetActive(true);

        // Calculate the direction from cameras[3] to cameras[0]
        Vector3 directionToCameras0 = cameras[0].transform.position - cameras[3].transform.position;

        // Set the rotation of cameras[3] to look at cameras[0]
        cameras[3].transform.rotation = Quaternion.LookRotation(directionToCameras0);
    }
}
