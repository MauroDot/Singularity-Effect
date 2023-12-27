using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spaceflight : MonoBehaviour
{
    public Transform hull;
    public float maxTilt = 20f;

    public float MaxSpeed = 40f;
    public float MaxAngularAcceleration = 30f;
    public float MaxAcceleration = 4f;

    public float TurnFactor = 1f;

    internal float ControlHorizontal;
    internal float ControlVertical;
    internal float ControlThrust = 0f;

    internal float stunned = 0f;

    public Slider thrustSlider;
    public Text thrustText;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Control forward thrust with the left mouse button
        if (Input.GetMouseButton(0))
        {
            ControlThrust = Mathf.Clamp(ControlThrust + Time.deltaTime, 0, 1);
        }
        // Control reverse thrust with the right mouse button
        else if (Input.GetMouseButton(1))
        {
            ControlThrust = Mathf.Clamp(ControlThrust - Time.deltaTime, -1, 0);
        }
        else
        {
            // Gradually stop the ship when neither forward nor reverse thrust is applied
            ControlThrust = Mathf.MoveTowards(ControlThrust, 0, Time.deltaTime);
        }

        // Update UI elements for thrust
        if (thrustSlider != null) thrustSlider.value = ControlThrust;
        if (thrustText != null) thrustText.text = Mathf.RoundToInt(ControlThrust * 100) + "%";

        // Increased sensitivity for rotation control with Q and E
        float rotationSensitivity = 65.0f; // Adjust this value to control rotation speed

        if (Input.GetKey(KeyCode.Q))
        {
            rb.AddTorque(transform.up * MaxAngularAcceleration * rotationSensitivity * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            rb.AddTorque(-transform.up * MaxAngularAcceleration * rotationSensitivity * Time.deltaTime);
        }
    }
    void FixedUpdate()
    {
        // Check if stunned
        if (stunned > 1f)
            stunned = 1f;
        else if (stunned > 0.85f)
            stunned -= Time.fixedDeltaTime * 0.05f;
        else if (stunned > 0f)
            stunned -= Time.fixedDeltaTime * 0.5f;
        else
            stunned = 0f;

        // Player control for turning
        ControlHorizontal = Input.GetAxis("Horizontal");
        ControlVertical = Input.GetAxis("Vertical");

        // Player control for strafing left and right with A and D
        float strafeInput = Input.GetAxis("Horizontal");

        // Apply strafing force
        Vector3 strafingForce = transform.right * strafeInput * MaxSpeed * Time.fixedDeltaTime;
        rb.AddForce(strafingForce, ForceMode.VelocityChange);

        // Apply acceleration
        Vector3 vDiff = transform.up * MaxSpeed * ControlThrust - rb.velocity;
        if (vDiff.magnitude > MaxAcceleration * (1f - stunned))
            vDiff *= MaxAcceleration * (1f - stunned) / vDiff.magnitude;
        rb.AddForce(vDiff, ForceMode.VelocityChange);

        // Apply turning torque
        Vector3 avDiff = -1 * (TurnFactor * (transform.forward * ControlHorizontal + transform.right * ControlVertical) + rb.angularVelocity);
        float mag = avDiff.magnitude;
        avDiff.Normalize();
        rb.AddTorque(avDiff * Mathf.Clamp(mag, 0, MaxAngularAcceleration * Time.fixedDeltaTime * (1f - stunned)), ForceMode.VelocityChange);

        // Apply visual tilt to the hull
        if (hull != null)
        {
            hull.localRotation = Quaternion.Euler(0f, ControlHorizontal * -1f * maxTilt, 0f);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        stunned = 1f;
    }
}

