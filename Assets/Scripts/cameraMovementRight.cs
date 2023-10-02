using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float maxForwardPosition = 10.0f;  // Adjust as needed
    public float maxBackwardPosition = -10.0f;  // Adjust as needed
    public float radius = 5.0f;
    private bool isMovingForward = false;
    private bool isMovingBackward = false;
    private bool isMovingPositve = false;
    private bool isMovingNegative = false;


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

        if (isMovingPositve)
        {
            MoveCameraPositveAngle();
        }
        
        if (isMovingNegative)
        {
            MoveCameraNegativeAngle();
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
    
    public void StartMovingPositive()
    {
        isMovingPositve = true;
    }
    public void StartMovingNegative()
    {
        isMovingNegative = true;
    }

    public void StopMovingPositive()
    {
        isMovingPositve = false;
    }
    public void StopMovingNegative()
    {
        isMovingNegative = false;
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

    private void MoveCameraPositveAngle()
    {
        float angle = 0.005f; // Adjust the angle as needed

        // Preserve the existing x rotation and modify the y rotation
        Quaternion currentRotation = transform.rotation;
        Quaternion newRotation = Quaternion.Euler(currentRotation.eulerAngles.x, currentRotation.eulerAngles.y + angle, currentRotation.eulerAngles.z);

        // Clamp the y rotation between 68 and 117 degrees
        Vector3 eulerAngles = newRotation.eulerAngles;
        eulerAngles.y = Mathf.Clamp(eulerAngles.y, 68f, 117f);
        newRotation = Quaternion.Euler(eulerAngles);

        // Apply the new rotation
        transform.rotation = newRotation;
    }

    private void MoveCameraNegativeAngle()
    {
        float angle = -0.005f; // Adjust the angle as needed

        // Preserve the existing x rotation and modify the y rotation
        Quaternion currentRotation = transform.rotation;
        Quaternion newRotation = Quaternion.Euler(currentRotation.eulerAngles.x, currentRotation.eulerAngles.y + angle, currentRotation.eulerAngles.z);

        // Clamp the y rotation between 68 and 117 degrees
        Vector3 eulerAngles = newRotation.eulerAngles;
        eulerAngles.y = Mathf.Clamp(eulerAngles.y, 68f, 117f);
        newRotation = Quaternion.Euler(eulerAngles);

        // Apply the new rotation
        transform.rotation = newRotation;
    }
}




