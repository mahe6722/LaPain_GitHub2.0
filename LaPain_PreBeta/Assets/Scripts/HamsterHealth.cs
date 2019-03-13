using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterHealth : MonoBehaviour {

    public int startingHealth;
    public int currentHealth;

    ManagerEnemy managerEnemy;
    HamsterMovement hamsterMovement;
    SpriteRenderer hamsterSprite;
    Color startColor;
    float flashSpeed = 5f;

    // Use this for initialization
    void Start () {
        currentHealth = startingHealth;
        managerEnemy = GameObject.Find("EnemyManager").GetComponent<ManagerEnemy>();
        hamsterMovement = GetComponent<HamsterMovement>();
        hamsterSprite = GetComponent<SpriteRenderer>();
        startColor = hamsterSprite.color;
    }
	
	// Update is called once per frame
	void Update () {
        if (currentHealth <= 0) {
            Death();
            managerEnemy.currentHamsters--;
        }

        //Player Projectiles will on collision make the enemies Red. If they are red, next frame they will lerp towards their original color!
        if (hamsterSprite.color != startColor) {
            hamsterSprite.color = Color.Lerp(hamsterSprite.color, startColor, flashSpeed * Time.deltaTime);
        }
    }

    void Death()
    {
        //Tell the game that the lane this Hamster occupied now is free!
        if (hamsterMovement.laneID == 1) {
            managerEnemy.hamsterLane1 = false;
        } else if (hamsterMovement.laneID == 2) {
            managerEnemy.hamsterLane2 = false;
        }
        Destroy(gameObject);

    }
}
