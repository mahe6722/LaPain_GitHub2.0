using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterShooting : MonoBehaviour {

    public GameObject hamsterBullet;
    public Transform hamsterGun;
    public GameObject player;
    

    public float timeBetweenBullets;
    public float timerFireRate;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {

        timerFireRate += Time.deltaTime;

        if (timerFireRate >= timeBetweenBullets && Time.timeScale != 0 && player != null) {

                Shoot();           
        }
    }

    void Shoot()
    {
        timerFireRate = 0;

        // Spawn Projectiles from the Gun on the Turtle.           
        Instantiate(hamsterBullet, hamsterGun.position, hamsterGun.rotation);
    }
}
