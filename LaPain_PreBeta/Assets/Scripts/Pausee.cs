using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausee : MonoBehaviour
{

    bool Pause = false;

    void Update()
    {

        if (Pause == false)
        {
            Time.timeScale = 1;
        }

        else
        {
            Time.timeScale = 0;
        }


        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Pause == true)
            {
                Pause = false;
            }

            else
            {
                Pause = true;
            }
        }


    }


}