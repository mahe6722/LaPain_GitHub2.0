using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerEnemy : MonoBehaviour {

    public int turtleCount;
    public int currentTurtles;
    public int hamsterCount;
    public int currentHamsters;

    public bool bossFight = false;

    public bool spawnLane1 = false;
    public bool spawnLane2 = false;
    public bool spawnLane3 = false;

    public bool hamsterLane1 = false;
    public bool hamsterLane2 = false;

    public GameObject hoveringTurtle;
    TurtleMovement turtleMovement;

    GameObject hamsterSpawnLane1;
    GameObject hamsterSpawnLane2;
    public GameObject hamsterEnemy;

    private float timerHamsterSpawn;
    public float respawnTimeHamster = 1;

    SnekoMovement snekoMovementScript;
  


    // Use this for initialization
    void Start () {
        currentTurtles = turtleCount;
        currentHamsters = hamsterCount;
        turtleMovement = GameObject.Find("Hovering Turtle").GetComponent<TurtleMovement>();
        hamsterSpawnLane1 = GameObject.Find("HamsterLane1");
        hamsterSpawnLane2 = GameObject.Find("HamsterLane2");
        snekoMovementScript = GameObject.Find("Sneko").GetComponent<SnekoMovement>();
	}
	
    void Update()
    {
        
        if (snekoMovementScript.bossFightWaiting)
        {
            bossFight = true;
        }
    }

	void LateUpdate () {

        if (snekoMovementScript.stageCounter == 1) {
            turtleCount = 2;
        } else if (snekoMovementScript.stageCounter == 2) {
            hamsterCount = 2;
        } else if (snekoMovementScript.stageCounter == 3) {
            turtleCount = 3;
        }

        if (!bossFight) {

            SpawnTurtles();

            SpawnHamsters();
        }

        

    }

    private void SpawnHamsters()
    {
        if (currentHamsters < hamsterCount && hamsterLane1 == false) {
            timerHamsterSpawn += Time.deltaTime;

            if (timerHamsterSpawn > respawnTimeHamster) {
                Instantiate(hamsterEnemy, hamsterSpawnLane1.transform.position, hamsterSpawnLane1.transform.rotation);
                currentHamsters++;
                timerHamsterSpawn = 0;
            }
        }
        else if (currentHamsters < hamsterCount && hamsterLane2 == false) {
            timerHamsterSpawn += Time.deltaTime;

            if (timerHamsterSpawn > respawnTimeHamster) {
                Instantiate(hamsterEnemy, hamsterSpawnLane2.transform.position, hamsterSpawnLane2.transform.rotation);
                currentHamsters++;
                timerHamsterSpawn = 0;
            }
        }
    }

    private void SpawnTurtles()
    {
       

        if (currentTurtles < turtleCount && spawnLane1 == false) {
            print("Spawning in Lane 1");
            Instantiate(hoveringTurtle, turtleMovement.SpawnLane1.transform.position, turtleMovement.SpawnLane1.transform.rotation);
            currentTurtles++;
        }
        if (currentTurtles < turtleCount && spawnLane2 == false) {
            print("Spawning in Lane 2");
            Instantiate(hoveringTurtle, turtleMovement.SpawnLane2.transform.position, turtleMovement.SpawnLane1.transform.rotation);
            currentTurtles++;
        }

        if (snekoMovementScript.stageCounter >= 3) {
            if (currentTurtles < turtleCount && spawnLane3 == false) {
                print("Spawning in Lane 3");
                Instantiate(hoveringTurtle, turtleMovement.SpawnLane3.transform.position, turtleMovement.SpawnLane1.transform.rotation);
                currentTurtles++;
            }
        }
    }
}
