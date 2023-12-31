using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystemGenerator : MonoBehaviour
{
    public GameObject starPrefab;
    public GameObject[] planetPrefabs;
    public GameObject[] moonPrefabs;
    public GameObject[] asteroidPrefabs;
    public float minOrbitRadius = 10f;
    public float maxOrbitRadius = 50f;
    public int maxMoonsPerPlanet = 3;

    // Call this method to generate the solar system
    public void GenerateSolarSystem()
    {
        // Instantiate the star at the center
        Instantiate(starPrefab, Vector3.zero, Quaternion.identity);

        for (int i = 0; i < planetPrefabs.Length; i++)
        {
            // Calculate orbit radius and position for each planet
            float orbitRadius = Random.Range(minOrbitRadius, maxOrbitRadius);
            Vector3 planetPosition = new Vector3(orbitRadius, 0, 0);

            // Instantiate planet
            GameObject planet = Instantiate(planetPrefabs[i], planetPosition, Quaternion.identity);

            // Assign orbit script to planet
            Orbit orbitScript = planet.AddComponent<Orbit>();
            orbitScript.orbitPathCenter = Vector3.zero; // Assuming star is at the center

            // Generate moons for this planet
            int moonCount = Random.Range(1, maxMoonsPerPlanet + 1);
            for (int j = 0; j < moonCount; j++)
            {
                // Calculate moon position
                Vector3 moonPosition = planetPosition + new Vector3(Random.Range(1, 5), 0, 0);

                // Instantiate moon
                GameObject moon = Instantiate(moonPrefabs[j % moonPrefabs.Length], moonPosition, Quaternion.identity);

                // Assign orbit script to moon
                Orbit moonOrbitScript = moon.AddComponent<Orbit>();
                moonOrbitScript.orbitPathCenter = planet.transform.position; // Planet's position is the moon's orbit center
            }
        }
    }
}