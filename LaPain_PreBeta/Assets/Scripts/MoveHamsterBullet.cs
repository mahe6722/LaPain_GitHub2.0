using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHamsterBullet : MonoBehaviour {

    GameObject target;
    public float bulletSpeed;
    private Vector3 targetLocation;

	// Use this for initialization
	void Start () {
        target = GameObject.Find("Player");

        targetLocation = -(transform.position - target.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
        
        transform.Translate(targetLocation * bulletSpeed * Time.deltaTime, Space.World);
	}
}
