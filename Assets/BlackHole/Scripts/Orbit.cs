using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public Vector3 orbitPathCenter;
    public float orbitSpeed = 5f;
    public float orbitRadius = 10f;
    private float orbitAngle;

    void Start()
    {
        // Set a random starting angle
        orbitAngle = Random.Range(0f, 360f);
        UpdatePosition();
    }

    void Update()
    {
        // Increment the angle based on the speed and time
        orbitAngle += orbitSpeed * Time.deltaTime;
        orbitAngle %= 360f;
        UpdatePosition();
    }

    void UpdatePosition()
    {
        // Calculate the new position based on the angle
        Vector3 offset = new Vector3(Mathf.Sin(orbitAngle * Mathf.Deg2Rad), 0, Mathf.Cos(orbitAngle * Mathf.Deg2Rad)) * orbitRadius;
        transform.position = orbitPathCenter + offset;
    }
}
