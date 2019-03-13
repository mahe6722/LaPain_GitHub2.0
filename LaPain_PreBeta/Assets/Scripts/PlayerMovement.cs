using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Boundary
{
    public float yMin, yMax;
}

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rigidBody;
    public float movementSpeed;
    public float tilt;
    public float resetTilt;

    public Boundary boundary;
    
    
	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        
        float moveVertical = Input.GetAxis("Vertical");
        //float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(0.0f, moveVertical);
        rigidBody.velocity = movement * movementSpeed;

        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rigidBody.velocity.y * resetTilt);

        //Restrict Movement Outside of Screen
        rigidBody.position = new Vector2(rigidBody.position.x, Mathf.Clamp(rigidBody.position.y, boundary.yMin, boundary.yMax));

        //If Touching This Border
        if (rigidBody.position == new Vector2(-8f, -4f) || rigidBody.position == new Vector2(-8, 4)) {

            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f * resetTilt); //TODO: Make an axis that goes from 1-0
            
        }
    }
}
