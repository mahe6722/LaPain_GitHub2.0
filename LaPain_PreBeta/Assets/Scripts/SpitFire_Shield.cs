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
    public float duration_barrier;
    public float timer_duration_barrier;

  
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer_cooldown_barrier += Time.deltaTime;

        if (barrier.activeInHierarchy) {
            timer_duration_barrier += Time.deltaTime;
        }

        if (barrier.activeInHierarchy == false && Input.GetKeyDown(KeyCode.Mouse1) && timer_cooldown_barrier >= cooldown_barrier) {
            barrier.SetActive(true);
        }

        else if (Input.GetKeyDown(KeyCode.Mouse1) && barrier.activeInHierarchy == true || timer_duration_barrier >= duration_barrier) {
            barrier.SetActive(false);
            timer_cooldown_barrier = 0f;
            timer_duration_barrier = 0f;
        }

        //Shield UI
        if (barrier.activeInHierarchy) {
        shieldSlider.value -= 0.16f;
        }
        if(shieldSlider.value <= 0) {
            uiSlider.SetActive(false);
            barrier.SetActive(false);
        }
    }
}
