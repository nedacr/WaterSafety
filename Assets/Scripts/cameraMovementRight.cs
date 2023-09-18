using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float maxRightPosition = 10.0f;  // Adjust as needed
    public float maxLeftPosition = -10.0f;  // Adjust as needed
    private bool isMovingRight = false;
    private bool isMovingLeft = false;

    // Update is called once per frame
    void Update()
    {
        if (isMovingRight)
        {
            MoveCameraRight();
        }

        if (isMovingLeft)
        {
            MoveCameraLeft();
        }
    }

    public void StartMovingRight()
    {
        isMovingRight = true;
    }

    public void StopMovingRight()
    {
        isMovingRight = false;
    }

    public void StartMovingLeft()
    {
        isMovingLeft = true;
    }

    public void StopMovingLeft()
    {
        isMovingLeft = false;
    }

    private void MoveCameraRight()
    {
        Vector3 movement = Vector3.right * moveSpeed * Time.deltaTime;
        Vector3 newPosition = transform.position + movement;

        // Clamp the new position within the specified range
        newPosition.x = Mathf.Clamp(newPosition.x, transform.position.x, maxRightPosition);
        transform.position = newPosition;
    }

    private void MoveCameraLeft()
    {
        Vector3 movement = Vector3.left * moveSpeed * Time.deltaTime;
        Vector3 newPosition = transform.position + movement;

        // Clamp the new position within the specified range
        newPosition.x = Mathf.Clamp(newPosition.x, maxLeftPosition, transform.position.x);
        transform.position = newPosition;
    }
}



