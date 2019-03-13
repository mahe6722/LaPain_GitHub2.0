using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {

    public float speed = 1f;

    SnekoMovement snekoMovement;

    // Use this for initialization
    void Start () {
        snekoMovement = GameObject.Find("Sneko").GetComponent<SnekoMovement>();
	}
	
	// Update is called once per frame
	void Update () {

        if(snekoMovement.stageCounter == 2) {
            speed = 0.4f;
        }
        else if (snekoMovement.stageCounter == 3) {
            speed = 0.6f;
        }
        else if (snekoMovement.bossFightComencing == true) {
            speed = 0.4f;
        }

        Vector2 Offset = new Vector2(Time.time * speed, 0);

        GetComponent<Renderer>().material.mainTextureOffset = Offset;
    }
}
