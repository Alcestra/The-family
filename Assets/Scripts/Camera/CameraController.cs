using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cameraTransform;

    public float MinZ;
    public float MaxZ;
    public float MinX;
    public float MaxX;

    public float normalSpeed;
    public float fastSpeed;
    public float movementSpeed;
    public float movementTime;
    public float rotationAmount;

    public Vector3 newPosition;
    public Quaternion newRotation;

    public Vector3 rotationStartPosition;
    public Vector3 rotationCurrentPosition;


   
    void Start()
    {
        newPosition = transform.position;
        newRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovementInpout();
        InputManeger();
    }

    private void InputManeger()
    {

        //camera rotations with RMB and edge rotation
        if (Input.GetMouseButtonDown(1))
        {
            rotationStartPosition = Input.mousePosition;
        }
        if (Input.GetMouseButton(1))
        {
            rotationCurrentPosition = Input.mousePosition;

            Vector3 difference = rotationStartPosition - rotationCurrentPosition;

            rotationStartPosition = rotationCurrentPosition;

            
            if (Input.mousePosition.x >= Screen.width * .99f)
            {
                 newRotation *= Quaternion.Euler(Vector3.up * (2f / 2f));
            }
            else if(Input.mousePosition.x <=  0f)
            {
                newRotation *= Quaternion.Euler(Vector3.up * (-2 / 2f));
            }
            else
                newRotation *= Quaternion.Euler(Vector3.up * (-difference.x / 5f));
        }
    }

    private void HandleMovementInpout()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = fastSpeed;
        }
        else
        {
            movementSpeed = normalSpeed;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            newPosition += (transform.forward * movementSpeed);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            newPosition += (-transform.forward * movementSpeed);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            newPosition += (transform.right * movementSpeed);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition += (transform.right * -movementSpeed);
        }
        //cam rotation
        if (Input.GetKey(KeyCode.Q))
        {
            newRotation *= Quaternion.Euler(Vector3.up * -rotationAmount);
        }
        if (Input.GetKey(KeyCode.E))
        {
            newRotation *= Quaternion.Euler(Vector3.up * rotationAmount);
        }


        newPosition.x = Mathf.Clamp(newPosition.x, MinX, MaxX);
        newPosition.z = Mathf.Clamp(newPosition.z, MinZ, MaxZ);


        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * movementTime);
    }
}
