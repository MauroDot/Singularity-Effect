using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystemManager : MonoBehaviour {
    public float GlobalSpeed=1;
    public GameObject Paths;
    public GameObject Labels;
    public bool ShowPaths = true;
    public bool ShowLabels = true;
    
	
	// Update is called once per frame
	void Update () {
        Paths.SetActive(ShowPaths);
        Labels.SetActive(ShowLabels);
	}
}
