using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingularityToggle : MonoBehaviour
{
    public Toggle singularityToggle; // Assign this in the inspector
    public SingularityPullable playerSingularityPullable; // Assign the player's SingularityPullable script in the inspector

    void Start()
    {
        if (singularityToggle != null && playerSingularityPullable != null)
        {
            // Initially disable the SingularityPullable script
            playerSingularityPullable.enabled = false;

            // Set the Toggle to reflect this initial state
            singularityToggle.isOn = false;

            // Add listener for future changes
            singularityToggle.onValueChanged.AddListener(ToggleSingularityPullable);
        }
    }

    void ToggleSingularityPullable(bool isOn)
    {
        playerSingularityPullable.enabled = isOn;
    }
}
