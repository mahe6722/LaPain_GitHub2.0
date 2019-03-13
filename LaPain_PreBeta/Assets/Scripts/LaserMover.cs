using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMover : MonoBehaviour {

    public float laserSpeed;

	// Use this for initialization
	void Start () {
        transform.position = transform.forward * laserSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
