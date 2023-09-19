using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float maxForwardPosition = 10.0f;  // Adjust as needed
    public float maxBackwardPosition = -10.0f;  // Adjust as needed
    private bool isMovingForward = false;
    private bool isMovingBackward = false;

    // Update is called once per frame
    void Update()
    {
        if (isMovingForward)
        {
            MoveCameraForward();
        }

        if (isMovingBackward)
        {
            MoveCameraBackward();
        }
    }

    public void StartMovingForward()
    {
        isMovingForward = true;
    }

    public void StopMovingForward()
    {
        isMovingForward = false;
    }

    public void StartMovingBackward()
    {
        isMovingBackward = true;
    }

    public void StopMovingBackward()
    {
        isMovingBackward = false;
    }

    private void MoveCameraForward()
    {
        Vector3 movement = Vector3.forward * moveSpeed * Time.deltaTime;
        Vector3 newPosition = transform.position + movement;

        // Clamp the new position within the specified range
        newPosition.z = Mathf.Clamp(newPosition.z, maxBackwardPosition, maxForwardPosition);
        transform.position = newPosition;
    }

    private void MoveCameraBackward()
    {
        Vector3 movement = Vector3.back * moveSpeed * Time.deltaTime;
        Vector3 newPosition = transform.position + movement;

        // Clamp the new position within the specified range
        newPosition.z = Mathf.Clamp(newPosition.z, maxBackwardPosition, maxForwardPosition);
        transform.position = newPosition;
    }
}




