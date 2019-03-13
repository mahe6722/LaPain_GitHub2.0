using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLaser : MonoBehaviour {

    Rigidbody2D rigidBody;

    public float laserSpeed;
  


    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody2D>();

        //Version 2 Movement LaserBeam
        rigidBody.velocity = -transform.right * laserSpeed;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Version 1 Movement LaserBeam
        // transform.Translate(laserSpeed * direction * Time.deltaTime, 0, 0);
        
    }
}
