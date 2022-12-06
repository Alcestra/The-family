using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.EventSystems;

public class CombatCamera : MonoBehaviour
{
    private const float minFollowYoffset = 2f;
    private const float maxFollowYoffset = 10f;

    private Vector3 targetFollowOffset;
    private CinemachineTransposer cinemachineTransposer;

    [SerializeField] private CinemachineVirtualCamera CinemachineVirtualcam;

    float moveSpeed = 10f;
    float rotationSpeed = 100f;
    float zoomSpeed = 5;
    float zoomAmout = 1f;


    private void Start()
    {        
        cinemachineTransposer = CinemachineVirtualcam.GetCinemachineComponent<CinemachineTransposer>();
        targetFollowOffset = cinemachineTransposer.m_FollowOffset;
    }

    private void Update()
    {

        HandleMovement();
        HandleRotation();
        HandleZoome();

    }

    private void HandleMovement()
    {
        //WASD movement for camera
        Vector3 inputMoveDir = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            inputMoveDir.z = +1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputMoveDir.z = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputMoveDir.x = +1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputMoveDir.x = -1f;
        }
        Vector3 moveVector = transform.forward * inputMoveDir.z + transform.right * inputMoveDir.x;
        transform.position += moveVector * moveSpeed * Time.deltaTime;

    }

    private void HandleRotation()
    {
        //Camera rotation controlles
        Vector3 rotationVector = new Vector3(0,0,0);

        if (Input.GetKey(KeyCode.Q))
        {
            rotationVector.y = +1f;
        }
        if (Input.GetKey(KeyCode.E))
        {
            rotationVector.y = -1f;
        }
        transform.eulerAngles += rotationVector * rotationSpeed * Time.deltaTime;
    }
    private void HandleZoome()
    {
        //Zoooming in the camera

        if (Input.mouseScrollDelta.y > 0)
        {
            targetFollowOffset.y -= zoomAmout;
        }
        //Zooming out the camera
        if (Input.mouseScrollDelta.y < 0)
        {
            targetFollowOffset.y += zoomAmout;
        }
        targetFollowOffset.y = Mathf.Clamp(targetFollowOffset.y, minFollowYoffset, maxFollowYoffset);

        cinemachineTransposer.m_FollowOffset = Vector3.Lerp(cinemachineTransposer.m_FollowOffset, targetFollowOffset, Time.deltaTime * zoomSpeed);

    }
}
