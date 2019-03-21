using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShieldParticle : MonoBehaviour {

    public GameObject ImpactEffect;

    void OnTriggerEnter2D(Collider2D other)
    {
        // If anything with tag laserbeam hits shield Particleeffect Plays
        if (other.tag == "laserBeam")
        {
            GameObject effectIns = (GameObject)Instantiate(ImpactEffect, transform.position, transform.rotation);
        }
    }
}
