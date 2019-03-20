using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlaceHolder_Health : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;
    public int actualHealth;

    public GameObject GameOverPanel;
    public Text gameOverText;

    //public Slider healthSlider;
    public Image enrageImage;
    public Sprite enrageState2;
    public Sprite enrageState3;

    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColor = new Color(1f, 0f, 0f, 1f);

    bool isDead;
    bool takesDamage;

    public Image carrotHealthBar;
    //healthbar in percentage!!
    public Sprite carrot80;
    public Sprite carrot60;
    public Sprite carrot40;
    public Sprite carrot20;
    Color healthBarStartColor;
    private float flashTimer;
    private float flashDuration = 0.3f;


    void Awake () {
        currentHealth = startingHealth;
        actualHealth = startingHealth + 50;

        healthBarStartColor = carrotHealthBar.color;

        GameOverPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (takesDamage) {
            damageImage.color = flashColor;
        } else {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        CarrotHealthBar();

        EnrageImageUpdate();

        takesDamage = false;
    }

    private void CarrotHealthBar()
    {
        if (actualHealth <= 125) {
            carrotHealthBar.sprite = carrot80;
        }
        if (actualHealth <= 100) {
            carrotHealthBar.sprite = carrot60;
        }
        if (actualHealth <= 75) {
            carrotHealthBar.sprite = carrot40;
        }
        if (actualHealth <= 50) {
            carrotHealthBar.sprite = carrot20;

            flashTimer += Time.deltaTime;

            if (carrotHealthBar.color == healthBarStartColor) {
                
                carrotHealthBar.color = new Color(1f, 0f, 0f, 1);
                
            }

            if (carrotHealthBar.color != healthBarStartColor && flashTimer >= flashDuration) {
                carrotHealthBar.color = Color.Lerp(carrotHealthBar.color, healthBarStartColor, (flashSpeed * 4) * Time.deltaTime);

                if (carrotHealthBar.color == healthBarStartColor) {
                    flashTimer = 0f;
                }
            }
        }
    }

    private void EnrageImageUpdate()
    {
        //Switching Between Enrage Sprites based on current health.
        if (currentHealth <= 75 && currentHealth > 25) {
            enrageImage.sprite = enrageState2;
            Gun.startTimeBtwShots = 0.4f;

        }
        if (currentHealth <= 25) {
            enrageImage.sprite = enrageState3;
            Gun.startTimeBtwShots = 0.2f;
        }
    }

    //Access this Script from DestroyByContact on the Laser_Projectiles. This will pass the damage value of the Turtle to "TakeDamage"
    public void TakeDamage (int amount)
    {
        takesDamage = true;

        AudioSource sound = gameObject.GetComponent<AudioSource>();
        sound.Play();

        if (currentHealth > 25) {
        currentHealth -= amount;
        }

        actualHealth -= amount;
        
        if (actualHealth > 25) {
       // healthSlider.value = currentHealth;
        }
        else {
           // healthSlider.value = actualHealth;
        }

        if(actualHealth <= 0 && !isDead) 
        {
            currentHealth = 0;
            //Make sure that Healthbar disappears when dying!
            carrotHealthBar.enabled = false;
            //Call the Function that takes care of the Death of the Player
            Death();
            
        }
    }

    //Kill the Player. Remove the Player GameObject from the Scene.
    void Death ()
    {
        isDead = true;

        Destroy(gameObject);

        GameOverPanel.SetActive(true);


    }
}
