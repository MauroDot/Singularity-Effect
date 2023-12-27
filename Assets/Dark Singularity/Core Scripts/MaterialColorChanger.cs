using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialColorChanger : MonoBehaviour
{
    public Material materialToChange;
    public float transitionDuration = 2f;

    void Start()
    {
        if (materialToChange != null)
        {
            StartCoroutine(ChangeColor());
        }
    }

    IEnumerator ChangeColor()
    {
        while (true) // Loop indefinitely
        {
            Color originalColor = materialToChange.color;
            Color targetColor = new Color(Random.value, Random.value, Random.value); // Random color
            float elapsedTime = 0;

            while (elapsedTime < transitionDuration)
            {
                elapsedTime += Time.deltaTime;
                float blend = Mathf.Clamp01(elapsedTime / transitionDuration);
                materialToChange.color = Color.Lerp(originalColor, targetColor, blend);
                yield return null;
            }

            materialToChange.color = targetColor;
        }
    }
}
