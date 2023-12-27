using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public GameObject[] shotSpawns;
    public GameObject shot;

    void Update()
    {
        // Fire weapon with space bar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (GameObject ss in shotSpawns)
            {
                Instantiate(shot, ss.transform.position, ss.transform.rotation);
            }
        }
    }
}
