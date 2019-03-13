using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleShooting : MonoBehaviour {

    float timerFireRate;
    
    public GameObject laserBeam;
    public Transform gunBarrelEnd;

    public float timeBetweenShots;
    public float safeToFire;

    public GameObject player;
    
    bool friendlyFire = false;

	// Use this for initialization
	void Awake () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {

        timerFireRate += Time.deltaTime;              
                
        if (timerFireRate >= timeBetweenShots && Time.timeScale != 0 && !friendlyFire) {

            //Check if allowed to Fire based on FirRate and FriendlyFire, Further make sure that if the Player is Dead, Stop Shooting!
            if (timerFireRate >= safeToFire && player != null) {
            Shoot();
            }
        }       

    }

    void FixedUpdate()
    {
       CheckFriendlyFire();

    }

    void CheckFriendlyFire()
    {

        RaycastHit2D hit = Physics2D.BoxCast(transform.position, new Vector2(.2f, .2f), 0f, Vector2.left);


        if (hit == true) {
            if (hit.collider.gameObject.tag == "Enemy") 
            {
            timerFireRate = 0;
            friendlyFire = true;
            //Debug Friendly Fire
            print("Friendly Fire!!");
            } 
            else {
                friendlyFire = false;
                //Debug Friendly Fire
                print("Fire At Will!");
            }
        }
     
    }

    void Shoot()
    {
        timerFireRate = 0;

       // Spawn Projectiles from the Gun on the Turtle.           
        Instantiate(laserBeam, gunBarrelEnd.position, gunBarrelEnd.rotation);

    }
}
