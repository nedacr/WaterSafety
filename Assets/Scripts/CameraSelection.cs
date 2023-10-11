using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSelection : MonoBehaviour
{
    public GameObject ControlsPanelDock;

    //this is not the beach but the far view 
    public GameObject ControlsPanelBeach;
    public float smoothness = 2.0f;
    public GameObject ControlsPanelLake;
    public GameObject RealControlsPanelBeach;
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
    // 2 = beach camera - THIS CAMERA IS NOT OPERATIONAL USE CAMERA 5 FOR BEACH
    // 3 = Dock Far Camera
    // 4 = lake camera
    // 5 = beach camera test temp

    // Update is called once per frame
    //main is dock camera
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

    public void MainToBeach()
    {
        cameras[1].SetActive(true);
        cameras[5].SetActive(false);
    }

    public void MainToLake()
    {
        cameras[1].SetActive(true);
        cameras[4].SetActive(false);
    }

    //main is dock camera
    public void QuestionToMain()
    {
        cameras[1].SetActive(false);
        cameras[0].SetActive(true);
    }

    public void QuestionToBeach()
    {
        cameras[1].SetActive(false);
        cameras[5].SetActive(true);
    }

    public void QuestionToLake()
    {
        cameras[1].SetActive(false);
        cameras[4].SetActive(true);
    }

    public void QuestionToFar()
    {
        cameras[3].SetActive(true);
        cameras[0].SetActive(false);
    }

    public void DockZoomin()
    {
        float rotationY = cameras[3].transform.rotation.eulerAngles.y;

        Debug.Log(rotationY);
        if ((rotationY >= 51 && rotationY <= 155) || (rotationY >= -335 && rotationY <= -225))
        {
            cameras[3].SetActive(false);
            ControlsPanelBeach.SetActive(false);
            ControlsPanelDock.SetActive(true);
            cameras[0].SetActive(true);

            // Calculate the new z position for cameras[0] based on cameras[3]'s rotational position
            float newZPositionForCameras0 = Mathf.Lerp(110f, 50f, (rotationY - 68f) / (117f - 68f));  // Inverted Lerp

            // Update the z position of cameras[0]
            Vector3 newPositionForCameras0 = new Vector3(cameras[0].transform.position.x, cameras[0].transform.position.y, newZPositionForCameras0);
            cameras[0].transform.position = newPositionForCameras0;
            Debug.Log("Current rotation interval: Docks");
        }
        else if (rotationY >= 156 && rotationY <= 313)
        {
            cameras[3].SetActive(false);
            ControlsPanelBeach.SetActive(false);
            RealControlsPanelBeach.SetActive(true);
            cameras[5].SetActive(true);

            // Calculate the new z position for cameras[5] based on cameras[3]'s rotational position
            float newZPositionForCameras5 = Mathf.Lerp(16f, 120f, (rotationY - 220f) / (307f - 220f));  // Inverted Lerp

            // Update the z position of cameras[0]
            Vector3 newPositionForCameras5 = new Vector3(cameras[5].transform.position.x, cameras[5].transform.position.y, newZPositionForCameras5);
            cameras[5].transform.position = newPositionForCameras5;

            Debug.Log("Current rotation interval: Beach");
        }
        else if (rotationY >= 314 || rotationY <= 50)
        {
            float newXPositionForCameras4 = 0;
            cameras[3].SetActive(false);
            ControlsPanelBeach.SetActive(false);
            ControlsPanelLake.SetActive(true);
            cameras[4].SetActive(true);
            if (rotationY >= 0 && rotationY <= 43)
            {
                newXPositionForCameras4 = Mathf.Lerp(-100f, 0f, (rotationY + 43f) / (43f + 43f));  // Inverted Lerp
            }
            else if (rotationY >= 314 && rotationY <= 359.99)
            {
                newXPositionForCameras4 = Mathf.Lerp(-100f, -50f, (rotationY - 316f) / (360f - 314f));
            }
            else
            {

                Debug.Log("ERROR");
            }
            // Calculate the new x position for cameras[0] based on cameras[3]'s rotational position

            Debug.Log(rotationY + "   " + newXPositionForCameras4);
            // Update the x position of cameras[0]
            Vector3 newPositionForCameras4 = new Vector3(newXPositionForCameras4, cameras[4].transform.position.y, cameras[4].transform.position.z);
            cameras[4].transform.position = newPositionForCameras4;
            Debug.Log("Current rotation interval: Lake");
        }
    }

    public void ZoomOut()
    {
        // Calculate the direction from cameras[3] to cameras[0]
        Vector3 directionToCameras0 = cameras[0].transform.position - cameras[3].transform.position;

        // Preserve the current x rotation of cameras[3]
        float originalXRotation = cameras[3].transform.rotation.eulerAngles.x;

        // Set the rotation of cameras[3] to look at cameras[0], keeping the original x rotation
        cameras[3].transform.rotation = Quaternion.Euler(originalXRotation, Quaternion.LookRotation(directionToCameras0).eulerAngles.y, 0f);

        // Deactivate cameras[0] and activate cameras[3]
        cameras[0].SetActive(false);
        ControlsPanelDock.SetActive(false);
        ControlsPanelBeach.SetActive(true);
        cameras[3].SetActive(true);
    }

    public void LakeZoomOut()
    {
        // Calculate the direction from cameras[3] to cameras[0]
        Vector3 directionToCameras4 = cameras[4].transform.position - cameras[3].transform.position;

        // Preserve the current x rotation of cameras[3]
        float originalXRotation = cameras[3].transform.rotation.eulerAngles.x;

        // Set the rotation of cameras[3] to look at cameras[0], keeping the original x rotation
        cameras[3].transform.rotation = Quaternion.Euler(originalXRotation, Quaternion.LookRotation(directionToCameras4).eulerAngles.y, 0f);

        // Deactivate cameras[4] and activate cameras[3]
        cameras[4].SetActive(false);
        ControlsPanelLake.SetActive(false);
        ControlsPanelBeach.SetActive(true);
        cameras[3].SetActive(true);
    }

    public void BeachZoomOut()
    {
        // Calculate the direction from cameras[3] to cameras[0]
        Vector3 directionToCameras5 = cameras[5].transform.position - cameras[3].transform.position;

        // Preserve the current x rotation of cameras[3]
        float originalXRotation = cameras[3].transform.rotation.eulerAngles.x;

        // Set the rotation of cameras[3] to look at cameras[0], keeping the original x rotation
        cameras[3].transform.rotation = Quaternion.Euler(originalXRotation, Quaternion.LookRotation(directionToCameras5).eulerAngles.y, 0f);

        // Deactivate cameras[5] and activate cameras[3]
        cameras[5].SetActive(false);
        RealControlsPanelBeach.SetActive(false);
        ControlsPanelBeach.SetActive(true);
        cameras[3].SetActive(true);
    }


    //Camera Shortcut

    private bool isRotating = false;

    private IEnumerator SmoothRotateCameraToYRotation(float targetYRotation)
    {
        if (cameras.Count > 3 && cameras[3] != null)
        {
            isRotating = true;

            float startRotation = cameras[3].transform.rotation.eulerAngles.y;

            // Calculate the shortest rotational path
            float shortestPath = ((targetYRotation - startRotation + 180) % 360) - 180;

            float t = 0f;

            while (t < 1f)
            {
                t += Time.deltaTime * smoothness;
                float newRotation = Mathf.Lerp(startRotation, startRotation + shortestPath, t);
                cameras[3].transform.rotation = Quaternion.Euler(cameras[3].transform.rotation.eulerAngles.x, newRotation, cameras[3].transform.rotation.eulerAngles.z);
                yield return null;
            }

            isRotating = false;
        }
        else
        {
            Debug.LogError("Camera[3] does not exist or is not set.");
        }
    }

    public void RotateCameraToYRotation(float targetYRotation)
    {
        if (!isRotating)
            StartCoroutine(SmoothRotateCameraToYRotation(targetYRotation));
    }

    public void beachShortCut()
    {
        RotateCameraToYRotation(225f);
    }

    public void lakeShortCut()
    {
        RotateCameraToYRotation(361f);
    }

    public void docksShortCut()
    {
        RotateCameraToYRotation(88f);
    }
}

