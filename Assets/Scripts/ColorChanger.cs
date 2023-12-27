using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class ParticleColorChanger : MonoBehaviour
{
    public ParticleSystem particleSystemToChange;
    public float changeInterval = 2.0f;

    void Start()
    {
        if (particleSystemToChange != null)
        {
            StartCoroutine(ChangeColor());
        }
    }

    IEnumerator ChangeColor()
    {
        while (true)
        {
            Color newColor = new Color(Random.value, Random.value, Random.value);
            float startTime = Time.time;
            ParticleSystem.MainModule mainModule = particleSystemToChange.main;

            while (Time.time - startTime < changeInterval)
            {
                mainModule.startColor = Color.Lerp(mainModule.startColor.color, newColor, (Time.time - startTime) / changeInterval);
                yield return null;
            }

            yield return new WaitForSeconds(changeInterval);
        }
    }
}
