using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingularityTracker3D : MonoBehaviour
{
    public Transform player; // Assign the player transform
    public Transform singularity; // Assign the singularity transform
    public Transform arrowIndicator; // Assign the 3D arrow transform
    [SerializeField]
    public float visibilityDistanceThreshold = 150f;
    void Update()
    {
        Vector3 directionToSingularity = (singularity.position - player.position);
        float distance = directionToSingularity.magnitude;
        arrowIndicator.gameObject.SetActive(distance > visibilityDistanceThreshold);

        if (arrowIndicator.gameObject.activeSelf)
        {
            // Set the arrow's rotation to point towards the singularity
            arrowIndicator.rotation = Quaternion.LookRotation(directionToSingularity);

            // Position the arrow above the player or in front of the camera
            arrowIndicator.position = player.position + new Vector3(0, 5, 0); // Example: 2 units above the player
        }
    }
}
