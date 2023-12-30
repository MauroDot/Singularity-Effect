using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingularityTracker : MonoBehaviour
{
    public Transform player; // Assign the player transform
    public Transform singularity; // Assign the singularity transform
    public Image arrowIndicator; // Assign the UI arrow image
    public float visibilityDistanceThreshold = 50f; // Distance at which the arrow becomes visible

    void Update()
    {
        // Calculate direction and distance to the singularity
        Vector3 directionToSingularity = singularity.position - player.position;
        float distance = directionToSingularity.magnitude;
        directionToSingularity.y = 0; // Ignore Y axis for 2D arrow rotation

        // Show or hide the arrow based on distance
        arrowIndicator.enabled = distance > visibilityDistanceThreshold;

        if (arrowIndicator.enabled)
        {
            // Calculate and set the arrow's rotation
            float angle = Mathf.Atan2(directionToSingularity.z, directionToSingularity.x) * Mathf.Rad2Deg;
            arrowIndicator.rectTransform.localRotation = Quaternion.Euler(0, 0, -angle);
        }
    }
}
