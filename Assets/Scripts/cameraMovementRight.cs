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
    private bool beachIsMovingLeft = false;
    private bool BeachIsMovingRight = false;
    private bool LakeIsMovingLeft = false;
    private bool LakeIsMovingRight = false;


    //temp beach values
    private bool BeachisMovingForward = false;
    private bool BeachisMovingBackward = false;


    //beach settings
    private Vector3 targetPoint1 = new Vector3(-58, 9, 39);
    private Vector3 targetPoint2 = new Vector3(-107, 9, 112);
    private float movementSpeed = 5.0f;
    private float targetRotationPoint1 = -154.469f;
    private float targetRotationPoint2 = -70.0f;

    private Quaternion initialRotation;


    //beach test settings


    private void Start()
    {
        initialRotation = transform.rotation;
    }



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
        if (beachIsMovingLeft)
        {
            MoveCamera(targetPoint1, targetRotationPoint1);
        }

        if (BeachIsMovingRight)
        {
            MoveCamera(targetPoint2, targetRotationPoint2);
        }
        if (LakeIsMovingLeft)
        {
            MoveCameraLakeLeft();
        }
        if (LakeIsMovingRight)
        {
            MoveCameraLakeRight();
        }
        if (BeachisMovingForward)
        {
            MoveCameraBeachFoward();
        }
        if (BeachisMovingBackward)
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

    public void StartMovingBeachLeft()
    {
        beachIsMovingLeft = true;
    }

    public void StopMovingBeachLeft()
    {
        beachIsMovingLeft = false;
    }

    public void StartMovingBeachRight()
    {
        BeachIsMovingRight = true;
    }

    public void StopMovingBeachRight()
    {
        BeachIsMovingRight = false;
    }

    public void StartMovinglakeLeft()
    {
        LakeIsMovingLeft = true;
    }

    public void StartMovingLakeRight()
    {
        LakeIsMovingRight = true;
    }

    public void StopMovingLakeLeft()
    {
        LakeIsMovingLeft = false;
    }

    public void StopMovingLakeRight()
    {
        LakeIsMovingRight = false;
    }

    public void StartMovingBeachForward()
    {
        BeachisMovingForward = true;
    }
    public void StopMovingBeachForward()
    {
        BeachisMovingForward = false;
    }
    public void StartMovingBeachBackwards()
    {
        BeachisMovingBackward = true;
    }
    public void StopMovingBeachBackwards()
    {
        BeachisMovingBackward = false;
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
        // Store the initial x and z rotations
        float initialXRotation = transform.rotation.eulerAngles.x;
        float initialZRotation = transform.rotation.eulerAngles.z;

        float angle = 360.0f * 0.03f * Time.deltaTime;  // 360 degrees per second

        // Rotate the camera around the y-axis only
        transform.Rotate(0, angle, 0);

        // Restore the initial x and z rotations
        Vector3 currentRotation = transform.rotation.eulerAngles;
        currentRotation.x = initialXRotation;
        currentRotation.z = initialZRotation;
        transform.rotation = Quaternion.Euler(currentRotation);
    }

    private void MoveCameraNegativeAngle()
    {
        // Store the initial x and z rotations
        float initialXRotation = transform.rotation.eulerAngles.x;
        float initialZRotation = transform.rotation.eulerAngles.z;

        float angle = -360.0f * 0.03f * Time.deltaTime;  // -360 degrees per second

        // Rotate the camera around the y-axis only
        transform.Rotate(0, angle, 0);

        // Restore the initial x and z rotations
        Vector3 currentRotation = transform.rotation.eulerAngles;
        currentRotation.x = initialXRotation;
        currentRotation.z = initialZRotation;
        transform.rotation = Quaternion.Euler(currentRotation);
    }

    //beach - includes moving angle, might have to rewrite this to be straight line??
    private void MoveCamera(Vector3 targetPosition, float targetRotation)
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        Vector3 movement = direction * movementSpeed * Time.deltaTime;

        // Store the initial x and z rotations
        float initialXRotation = transform.rotation.eulerAngles.x;
        float initialZRotation = transform.rotation.eulerAngles.z;

        // Check if we have reached or passed the target position
        if ((targetPosition - transform.position).sqrMagnitude < movement.sqrMagnitude)
        {
            transform.position = targetPosition;

            // Maintain the initial x and z rotations
            Quaternion targetRotationQuaternion = Quaternion.Euler(initialXRotation, targetRotation, initialZRotation);
            transform.rotation = targetRotationQuaternion;

            beachIsMovingLeft = false;
            BeachIsMovingRight = false;
        }
        else
        {
            transform.position += movement;

            // Rotate only on the y-axis towards the target rotation
            Quaternion targetRotationQuaternion = Quaternion.Euler(initialXRotation, targetRotation, initialZRotation);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotationQuaternion, movementSpeed * Time.deltaTime);
        }
    }

    private void MoveCameraLakeLeft()
    {
        Vector3 movement = Vector3.left * moveSpeed * Time.deltaTime;
        Vector3 newPosition = transform.position + movement;

        // Clamp the new position within the specified range
        newPosition.x = Mathf.Clamp(newPosition.x, maxBackwardPosition, maxForwardPosition);
        transform.position = newPosition;
    }

    private void MoveCameraLakeRight()
    {
        Vector3 movement = Vector3.right * moveSpeed * Time.deltaTime;
        Vector3 newPosition = transform.position + movement;

        // Clamp the new position within the specified range
        newPosition.x = Mathf.Clamp(newPosition.x, maxBackwardPosition, maxForwardPosition);
        transform.position = newPosition;
    }

    private void MoveCameraBeachFoward()
    {
        Vector3 movement = Vector3.forward * moveSpeed * Time.deltaTime;
        Vector3 newPosition = transform.position + movement;

        // Clamp the new position within the specified range
        newPosition.z = Mathf.Clamp(newPosition.z, maxBackwardPosition, maxForwardPosition);
        transform.position = newPosition;
    }
    private void MoveCameraBeachBackward()
    {
        Vector3 movement = Vector3.back * moveSpeed * Time.deltaTime;
        Vector3 newPosition = transform.position + movement;

        // Clamp the new position within the specified range
        newPosition.z = Mathf.Clamp(newPosition.z, maxBackwardPosition, maxForwardPosition);
        transform.position = newPosition;
    }

}




