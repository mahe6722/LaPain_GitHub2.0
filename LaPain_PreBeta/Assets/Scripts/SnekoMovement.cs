using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnekoMovement : MonoBehaviour
{
    public Animator animator_Sneko;
    public SpriteRenderer snekoSprite;

    GameObject sneko;

    GameObject snekoHead;

    ManagerEnemy enemyManager;
    

    public float snekoSpeed;
    public float retreatSpeed;
    public float currentSpeed;

    public int direction = -1;

    public bool retreating = false;
    //This value counts how many times the carrot almost got caught by Spitfire. Use this value to change the behavior of Sneko after 3 "Close Calls". Boss fight will now begin when all enemies are cleared! 
    public int stageCounter = 1;
    public int numberOfStages = 4;

    //Maximum travel distance towards middle of the screen
    public int leftBorder = 2;

    //Maximum travel distance towards the right endge of the screen.
    public int rightBorder = 10;

    //Use this to Progress Boss movement towards player. Decrement as Enemies die!
    public int currentBorder;

    public bool bossFightWaiting = false;
    public bool bossFightComencing = false;

    public int tempHealth;

    void Start ()
    {
        currentSpeed = snekoSpeed;
        sneko = GameObject.Find("Sneko");

        enemyManager = GameObject.Find("EnemyManager").GetComponent<ManagerEnemy>();

        snekoHead = GameObject.Find("SnekoHead");
        snekoHead.SetActive(false);
    }
	
	void Update()
    {
        if (tempHealth <= 0)
        {
            
            sneko.SetActive(false);
            
        }


        if (stageCounter == numberOfStages)
        {
            rightBorder = 20;
        }

        if (stageCounter == numberOfStages && enemyManager.currentHamsters == 0 && enemyManager.currentTurtles == 0)
        {
            bossFightWaiting = false;
            bossFightComencing = true;
            rightBorder = 10;
        }

        if (bossFightComencing)
        {
            if (transform.position.x > rightBorder)
            {
                transform.Translate(Vector2.right * retreatSpeed * Time.deltaTime);
            }
            else
            {
                retreatSpeed = 0;
            }
            snekoHead.SetActive(true);
            animator_Sneko.SetBool("BossFight", true);
            snekoSprite.flipX = true;
        }
    }

	void FixedUpdate ()
    {

        //if boss is going to start retreating we want fast speed and set retreating to true
        if (direction > 0) 
        {
            currentSpeed = retreatSpeed;
            retreating = true;
        }
        else
        {
            currentSpeed = snekoSpeed;
        }

        if (transform.position.x > leftBorder)
        {       
            //reset direction and stop retreating when boss hits right border.
            if (transform.position.x > rightBorder) 
            {
                if (stageCounter != numberOfStages)
                {
                    direction = -direction;
                    retreating = false;
                }
                else
                {
                    currentSpeed = 0;
                    retreating = false;
                    sneko.transform.localRotation = Quaternion.Euler(0, 180, 0);
                    bossFightWaiting = true;
                }
                
            }

            //Gradually Approaching leftBorder, currentBorder is changed as the player damages the enemies. (Done in Player Projectile script)
            if (transform.position.x > currentBorder)
            {
            //Moving the Boss
            transform.Translate(direction * currentSpeed * Time.deltaTime, 0, 0);
            }
        }
    }

    private void LateUpdate()
    {
        if (retreating == true) {
            print("Boss is Retreating!");
            //Moving the Boss
            transform.Translate(Vector2.right * currentSpeed * Time.deltaTime);
        }
    }
}
