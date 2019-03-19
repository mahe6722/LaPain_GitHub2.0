using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpitFire_Shield : MonoBehaviour {

    PauseMenu pauseScript;

    public GameObject barrier;
    public GameObject uiSlider;
    public Slider shieldSlider;

    public float cooldown_barrier;
    public float timer_cooldown_barrier;
    int loopCounter = 0;
    //Duration Mechanic
    //public float duration_barrier;
    //public float timer_duration_barrier;

    private void Start()
    {
        pauseScript = GameObject.Find("PauseCanvas").GetComponent<PauseMenu>();

    }

    // Update is called once per frame
    void Update()
    {
        timer_cooldown_barrier += Time.deltaTime;

        if (barrier.activeInHierarchy) {
            // timer_duration_barrier += Time.deltaTime;
        }

        if (barrier.activeInHierarchy == false && Input.GetKeyDown(KeyCode.Mouse1) && timer_cooldown_barrier >= cooldown_barrier && !pauseScript.GameIsPaused) {
            barrier.SetActive(true);
        } else if (Input.GetKeyDown(KeyCode.Mouse1) && barrier.activeInHierarchy == true && !pauseScript.GameIsPaused /* || timer_duration_barrier >= duration_barrier */ ) {
            barrier.SetActive(false);
            timer_cooldown_barrier = 0f;
            // timer_duration_barrier = 0f;
        }

        //Shield UI
        if (barrier.activeInHierarchy && !pauseScript.GameIsPaused) {
            if (loopCounter < 1) {
                shieldSlider.value -= 2f;
                loopCounter++;
            }
            shieldSlider.value -= 1.2f;

        } else if (barrier.activeInHierarchy == false && shieldSlider.value != 100 && !pauseScript.GameIsPaused) {
            loopCounter = 0;
            shieldSlider.value += 0.3f;
        }
        if (shieldSlider.value <= 0) {
            barrier.SetActive(false);
           
        }
        
    }
}
