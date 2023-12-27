using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineCameraSwitcher : MonoBehaviour
{
    public CinemachineVirtualCamera thirdPersonCamera;
    public CinemachineVirtualCamera firstPersonCamera;

    private int thirdPersonPriority;
    private int firstPersonPriority;

    private void Start()
    {
        // Store the original priorities
        thirdPersonPriority = thirdPersonCamera.Priority;
        firstPersonPriority = firstPersonCamera.Priority;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (thirdPersonCamera.Priority > firstPersonCamera.Priority)
            {
                thirdPersonCamera.Priority = firstPersonPriority;
                firstPersonCamera.Priority = thirdPersonPriority;
            }
            else
            {
                thirdPersonCamera.Priority = thirdPersonPriority;
                firstPersonCamera.Priority = firstPersonPriority;
            }
        }
    }
}
