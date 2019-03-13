using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : MonoBehaviour
{
    public float playerHealth = 4;

    void OnTriggerEnter2D(Collider2D other)
    {
        while (playerHealth > 1)
        {
            if (other.tag == "laserBeam")
            {
                playerHealth--;
                Gun.startTimeBtwShots = Gun.startTimeBtwShots - 0.2f;
                break;
            }
        }
    }
}
