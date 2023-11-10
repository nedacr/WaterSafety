using UnityEngine;
//using System.Collections.Generic;

public class CameraMovement : MonoBehaviour
{
    private float moveSpeed = 5.0f;
    public float maxForwardPosition = 10.0f;  // Adjust as needed
    public float maxBackwardPosition = -10.0f;  // Adjust as needed
    public float radius = 5.0f;
    private float velocity = 0;

    public GameObject mainCamera;
    public bool isActive;
    //public static List<GameObject> cameras;

    // Add variables for camera acceleration
    public float acceleration = 2.0f;
    private float maxSpeed = 30.0f;

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

        //foreach (Transform t in transform)
        //{
        //    cameras.Add(t.gameObject);

        //
        if (gameObject.tag == "MainCamera")
        {
            mainCamera = gameObject;
            isActive = true;
        }
        //mainCheck();
        
    }



    // Update is called once per frame
    void Update()
    {

        if(moveSpeed > movementSpeed)
        {
            //Debug.Log("Acceleration applied");
        }
        

        if (isMovingForward)
        {
            //mainCheck(); 
            MoveCameraForward();
        }

        if (isMovingBackward)
        {
            //mainCheck(); 
            MoveCameraBackward();
        }

        if (isMovingPositve)
        {
            //mainCheck(); 
            MoveCameraPositveAngle();
        }

        if (isMovingNegative)
        {
            //mainCheck(); 
            MoveCameraNegativeAngle();
        }
        if (beachIsMovingLeft)
        {
            //mainCheck(); 
            MoveCamera(targetPoint1, targetRotationPoint1);
        }

        if (BeachIsMovingRight)
        {
            //mainCheck(); 
            MoveCamera(targetPoint2, targetRotationPoint2);
        }
        if (LakeIsMovingLeft)
        {
            //mainCheck(); 
            MoveCameraLakeLeft();
        }
        if (LakeIsMovingRight)
        {
            //mainCheck(); 
            MoveCameraLakeRight();
        }
        if (BeachisMovingForward)
        {
            //mainCheck(); 
            MoveCameraBeachFoward();
        }
        if (BeachisMovingBackward)
        {
            //mainCheck(); 
            MoveCameraBackward();
        }
        
        //Debug.Log("Main Camera active in Scene: " + isActive);
        //Debug.Log("Current Speed is " + moveSpeed);
    }

    // Accelerating camera movement
    //private float AccelerateCameraMovement()
    //{
    //    // Accelerate the camera if it's the main camera
    //    if (maxSpeed > moveSpeed)
    //    {
    //        moveSpeed += acceleration;
    //    }

    //    return moveSpeed;
    //}

    public void mainCheck()
    {
        //acceleration? but its reversed for some reason
        if (gameObject.tag == "MainCamera")
        {
            if (moveSpeed > maxSpeed)
            {
                moveSpeed = maxSpeed;
                //Debug.Log("Speed Maxed");
            }
            else
            {
                // Gradually increase the moveSpeed up to the maxSpeed
                velocity = 0;
                velocity += acceleration * Time.deltaTime;
                moveSpeed += velocity * Time.deltaTime;
                //print(moveSpeed);
            }
            
            //this is supposed to work on zoom out and at the very beginning, but only activates on zoom in
            //Debug.Log("Zoomed Out");
        }
        else
        {
            moveSpeed = movementSpeed;
            //Debug.Log("Zoomed In");
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
        moveSpeed = movementSpeed;
    }
    public void StopMovingNegative()
    {
        isMovingNegative = false;
        moveSpeed = movementSpeed;
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
        mainCheck();
        Vector3 movement = Vector3.forward * moveSpeed * Time.deltaTime;
        Vector3 newPosition = transform.position + movement;
        //AccelerateCameraMovement(ref movement);
        //Debug.Log("Acceleration Used");

        // Clamp the new position within the specified range
        newPosition.z = Mathf.Clamp(newPosition.z, maxBackwardPosition, maxForwardPosition);
        transform.position = newPosition;
        
    }

    private void MoveCameraBackward()
    {
        
        mainCheck();
        Vector3 movement = Vector3.back * moveSpeed * Time.deltaTime;
        Vector3 newPosition = transform.position + movement;
        //AccelerateCameraMovement(ref movement);
       // Debug.Log("Acceleration Used");

        // Clamp the new position within the specified range
        newPosition.z = Mathf.Clamp(newPosition.z, maxBackwardPosition, maxForwardPosition);
        transform.position = newPosition;
        
    }

    private void MoveCameraPositveAngle()
    {
        
        mainCheck();
        // Store the initial x and z rotations
        float initialXRotation = transform.rotation.eulerAngles.x;
        float initialZRotation = transform.rotation.eulerAngles.z;

        float angle = 360.0f * 0.03f * Time.deltaTime * moveSpeed;  // 360 degrees per second

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
        //print("Testing");
        mainCheck();
        // Store the initial x and z rotations
        float initialXRotation = transform.rotation.eulerAngles.x;
        float initialZRotation = transform.rotation.eulerAngles.z;

        float angle = -360.0f * 0.03f * Time.deltaTime * moveSpeed;  // -360 degrees per second

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
        mainCheck();
        Vector3 direction = (targetPosition - transform.position).normalized;
        Vector3 movement = direction * moveSpeed * Time.deltaTime;
        //Debug.Log("Acceleration Used");

        // Store the initial x and z rotations
        float initialXRotation = transform.rotation.eulerAngles.x;
        float initialZRotation = transform.rotation.eulerAngles.z;

        // Check if we have reached or passed the target position
        if ((targetPosition - transform.position).sqrMagnitude < movement.sqrMagnitude)
        {
            transform.position = targetPosition;

            // Maintain the initial x and z rotations
            //Quaternion targetRotationQuaternion = Quaternion.Euler(initialXRotation, targetRotation * moveSpeed, initialZRotation);
            //transform.rotation = targetRotationQuaternion;

            beachIsMovingLeft = false;
            BeachIsMovingRight = false;
        }
        else
        {
            transform.position += movement;

            // Rotate only on the y-axis towards the target rotation
            //Quaternion targetRotationQuaternion = Quaternion.Euler(initialXRotation, targetRotation * moveSpeed, initialZRotation);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotationQuaternion, moveSpeed);
        }
        
    }

    private void MoveCameraLakeLeft()
    {
        mainCheck();
        Vector3 movement = Vector3.left * moveSpeed * Time.deltaTime;
        Vector3 newPosition = transform.position + movement;
        //Debug.Log("Acceleration Used");

        // Clamp the new position within the specified range
        newPosition.x = Mathf.Clamp(newPosition.x, maxBackwardPosition, maxForwardPosition);
        transform.position = newPosition;
        
    }

    private void MoveCameraLakeRight()
    {
        mainCheck();
        Vector3 movement = Vector3.right * moveSpeed * Time.deltaTime;
        Vector3 newPosition = transform.position + movement;
        //Debug.Log("Acceleration Used");

        // Clamp the new position within the specified range
        newPosition.x = Mathf.Clamp(newPosition.x, maxBackwardPosition, maxForwardPosition);
        transform.position = newPosition;
        
    }

    private void MoveCameraBeachFoward()
    {
        mainCheck();
        Vector3 movement = Vector3.forward * moveSpeed * Time.deltaTime;
        Vector3 newPosition = transform.position + movement;
        //Debug.Log("Acceleration Used");

        // Clamp the new position within the specified range
        newPosition.z = Mathf.Clamp(newPosition.z, maxBackwardPosition, maxForwardPosition);
        transform.position = newPosition;
        
    }
    private void MoveCameraBeachBackward()
    {
        mainCheck();
        Vector3 movement = Vector3.back * moveSpeed * Time.deltaTime;
        Vector3 newPosition = transform.position + movement;
        //Debug.Log("Acceleration Used");

        // Clamp the new position within the specified range
        newPosition.z = Mathf.Clamp(newPosition.z, maxBackwardPosition, maxForwardPosition);
        transform.position = newPosition;
        
    }

}




