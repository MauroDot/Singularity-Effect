using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {
    public GameObject target;
    public float delay=0.1f;
    public float Ytranslation = 1f;
    Vector3 tmp;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, delay);
        tmp = transform.position;
        tmp.y= tmp.y + Ytranslation;
        transform.position = tmp;
    }
}
