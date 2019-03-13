using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpitFire_Shield : MonoBehaviour {

    public GameObject barrier;
    public GameObject uiSlider;
    public Slider shieldSlider;

    public float cooldown_barrier;
    public float timer_cooldown_barrier;

    //Duration Mechanic
    //public float duration_barrier;
    //public float timer_duration_barrier;


    // Update is called once per frame
    void Update()
    {
        timer_cooldown_barrier += Time.deltaTime;

        if (barrier.activeInHierarchy) {
           // timer_duration_barrier += Time.deltaTime;
        }

        if (barrier.activeInHierarchy == false && Input.GetKeyDown(KeyCode.Mouse1) && timer_cooldown_barrier >= cooldown_barrier) {
            barrier.SetActive(true);
        }

        else if (Input.GetKeyDown(KeyCode.Mouse1) && barrier.activeInHierarchy == true /* || timer_duration_barrier >= duration_barrier */ ){
            barrier.SetActive(false);
            timer_cooldown_barrier = 0f;
           // timer_duration_barrier = 0f;
        }

        //Shield UI
        if (barrier.activeInHierarchy) {
        shieldSlider.value -= 1f;
        }
        else if (barrier.activeInHierarchy == false && shieldSlider.value != 100) {
            shieldSlider.value += 0.5f;
        }
        if (shieldSlider.value <= 0) {
            cooldown_barrier = 5;
            barrier.SetActive(false);
        } else if (shieldSlider.value >= 50) {
            cooldown_barrier = 0.1f;
        }
    }
}
