using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraAroundPlaneArea : MonoBehaviour
{
    [SerializeField] private GameObject planeToFollow;
    private BoxCollider planeBoxCollider;
    private Camera mainCamera;
    
    [SerializeField] private float cameraMovement;

    public SampleUserPolling_JustRead arduinoInput;

    public float speedMultiplier = 1;

    public float deadZone = 1.0f;

    private void Start()
    {
        planeBoxCollider = GetComponent<BoxCollider>();
        
        mainCamera = Camera.main;
    }

    private void Update()
    {
        Vector3 movementVector = Vector3.zero;

        // Deadzone
        /*
        if (Mathf.Abs(arduinoInput.xValue) > deadZone)
            movementVector.x = arduinoInput.xValue / 5.0f; // Normalize The Input

        if (Mathf.Abs(arduinoInput.yValue) > deadZone)
            movementVector.y = arduinoInput.yValue / 5.0f; // Normalize The Input

        movementVector *= speedMultiplier;
        */

        
        if (Input.GetKey(KeyCode.UpArrow))
            movementVector.y += 1;
        
        if (Input.GetKey(KeyCode.DownArrow))
            movementVector.y -= 1;
        
        if (Input.GetKey(KeyCode.LeftArrow))
            movementVector.x -= 1;
        
        if (Input.GetKey(KeyCode.RightArrow))
            movementVector.x += 1;
        

        // This part could just be bounds checks ... :l
        Vector3 predictedNewPosition = transform.position + movementVector.normalized * cameraMovement;
        bool isMovementVectorAltered = false;
        if (movementVector.x != 0.0f)
        {
            float width = mainCamera.orthographicSize * mainCamera.aspect;
            float offset = width * movementVector.x;

            Vector3 rayLocation = predictedNewPosition;
            rayLocation.x += offset;

            Ray ray = new Ray(rayLocation, Vector3.forward);
            if (!Physics.Raycast( ray, 100.0f ))
            {
                // On No! Let's Negate This Movement Then!
                movementVector.x = 0;
                isMovementVectorAltered = true;
            }
       }

        if (movementVector.y != 0.0f)
        {
            float height = mainCamera.orthographicSize;
            float offset = height * movementVector.y;

            Vector3 rayLocation = predictedNewPosition;
            rayLocation.y += offset;

            Ray ray = new Ray(rayLocation, Vector3.forward);
            if (!Physics.Raycast( ray, 100.0f ))
            {
                // On No! Let's Negate This Movement Then!
                movementVector.y = 0;
                isMovementVectorAltered = true;
            }
        }

        if (isMovementVectorAltered)
        {
            transform.position += movementVector.normalized * cameraMovement;
        }
        else
        {
            transform.position = predictedNewPosition;
        }


    }
}
