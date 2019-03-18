using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform MuzzleFlashPrefab;
    public float offset;

    public GameObject projectile;
    public Transform shotPoint;

    private float timeBtwShots;
    public static float startTimeBtwShots;

    private void Start()
    {
        
        startTimeBtwShots = 0.7f;
    }

    void Effect ()
    {
        Transform clone = (Transform)Instantiate(MuzzleFlashPrefab, shotPoint.position, shotPoint.rotation);
        clone.parent = shotPoint;
        float size = Random.Range(0.6f, 0.9f);
        clone.localScale = new Vector3(size, size, size);
        Destroy (clone.gameObject, 0.02f);
    }

    private void Update()
    {   
        //If TimeScale is not equal to pause (as in "0")
        if(Time.timeScale == 1) {

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        // -90 <= z <= 90
        rotZ = Mathf.Clamp(rotZ, -60, 60);
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(projectile, shotPoint.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;

                   
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
        }
    }

}




