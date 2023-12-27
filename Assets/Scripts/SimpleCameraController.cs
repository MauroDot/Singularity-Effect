using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraController : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float mouseSensitivity = 100f;
    public float boostMultiplier = 2f; // Multiplier for speed boost

    private float xRotation = 0f;
    private Transform playerBody;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
        playerBody = this.transform.parent; // Assuming the camera is a child of the player object
    }

    void Update()
    {
        MoveCamera();
        MouseLook();
        BoostSpeed();
    }

    void MoveCamera()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        playerBody.Translate(move * movementSpeed * Time.deltaTime);
    }

    void MouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Adjust the pitch (up and down rotation)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Adjust the yaw (left and right rotation) on the player body
        // This ensures that the yaw is independent of the camera's pitch angle
        playerBody.Rotate(Vector3.up * mouseX);
    }

    void BoostSpeed()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            movementSpeed *= boostMultiplier;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            movementSpeed /= boostMultiplier;
        }
    }
}
