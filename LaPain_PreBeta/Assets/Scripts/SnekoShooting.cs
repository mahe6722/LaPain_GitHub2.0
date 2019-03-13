using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnekoShooting : MonoBehaviour
{ 
    public GameObject snekoSpit;
    public Transform spitPoint;

    private float timeBtwShots;
    public float startTimeBtwShots;

    private void Update()
    {
        if (timeBtwShots <= 0 && GameObject.Find("Player") != null)
        {
            Instantiate(snekoSpit, spitPoint.position, transform.rotation);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
