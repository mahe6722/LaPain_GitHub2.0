using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterMovement : MonoBehaviour {

    public float hamsterSpeed;

    float direction = -1; //Start Moving the Hamster Left
    int leftBorder = 2;
    int rightBorder = 5;

    public int laneID;
    float unitID;
    public float frequency;

    GameObject target;
    private Vector3 targetLocation;
    private Vector3 lookAngle;

    public GameObject hamsterLane1;
    public GameObject hamsterLane2;
    ManagerEnemy managerEnemy;
    private bool justSpawned;

    // Use this for initialization
    void Start () {
        unitID = Random.Range(1, 10);
        target = GameObject.Find("Player");

        managerEnemy = GameObject.Find("EnemyManager").GetComponent<ManagerEnemy>();
        hamsterLane1 = GameObject.Find("HamsterLane1");
        hamsterLane2 = GameObject.Find("HamsterLane2");

        justSpawned = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position.x <= 5f) {
            justSpawned = false;
        }

        if (transform.position.y == hamsterLane1.transform.position.y) {
            managerEnemy.hamsterLane1 = true;
            laneID = 1;
        }
        else if (transform.position.y == hamsterLane2.transform.position.y) {
            managerEnemy.hamsterLane2 = true;
            laneID = 2;
        }

        lookAngle = new Vector3(0, 0, 0);
        if (target != null) {
        targetLocation = -(transform.position - target.transform.position);
        }
        
        if (justSpawned) {
            SpawnMovement();
        } else {
            MainMovement();
        }
    }

    void SpawnMovement()
    {
        if (transform.position.x >= rightBorder) {
            direction = -1;
        } else if (transform.position.x <= leftBorder) {
            direction = 1;
        }

        transform.Translate(0.5f * hamsterSpeed * direction * Time.deltaTime, 0, 0, Space.World);

        if (target != null) {

            Vector3 difference = -(target.transform.position - transform.position);
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            // -90 <= z <= 90

            transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
        }
    }

    private void MainMovement()
    {
        
            if (transform.position.x <= leftBorder || transform.position.x >= rightBorder) {
                transform.position = new Vector2(Mathf.Clamp(transform.position.x, leftBorder, rightBorder), transform.position.y);
            }
            //Use Sinus Curve to Shift the direction of the Enemies with the offset of unitID
            direction = Mathf.Sin((Time.time + unitID) * frequency);
        
       if (target != null) {

        Vector3 difference = -(target.transform.position - transform.position);
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        // -90 <= z <= 90
       
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
        }

        transform.Translate(0.5f * hamsterSpeed * direction * Time.deltaTime, 0, 0, Space.World);
    }

}
