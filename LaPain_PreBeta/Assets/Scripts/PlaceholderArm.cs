using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceholderArm : MonoBehaviour {

    public float armReach;
    SnekoMovement snekoMovement;

    private int borderReset;

	
	void Start () {
        snekoMovement = GameObject.Find("Sneko").GetComponent<SnekoMovement>();

        //Store the value of currentBorder on start. This is to make sure this script works if currentBorder is changed in the inspector.
        borderReset = snekoMovement.currentBorder;

	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, armReach);

            if (hitInfo.collider != null) {

                if (hitInfo.collider.CompareTag("Carrot")) {
                    print("RayCast Found Carrot");

                    //Accessing the movement script for Sneko. This tells Sneko to retreat because the arm would reach his carrot.
                    snekoMovement.direction = 1;
                    snekoMovement.currentBorder = borderReset;
                    //Counting how many times Spitfire almost caught the carrot with "stageCounter". After 3 "Close Calls" Sneko will change his behavior. Boss fight is not imminent. 
                    snekoMovement.stageCounter++;
                }
            }
        }
    }
}
